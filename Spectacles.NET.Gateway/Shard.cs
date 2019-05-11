// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RateLimiter;
using Spectacles.NET.Gateway.Logging;
using Spectacles.NET.Gateway.Websocket;
using Spectacles.NET.Types;
using Timer = System.Timers.Timer;

namespace Spectacles.NET.Gateway
{
	/// <inheritdoc />
	/// <summary>
	/// A Shard represent one connection to the Discord Gateway.
	/// </summary>
	public class Shard : IDisposable
	{
		/// <summary>
		/// Event emitted when Logs are created.
		/// </summary>
		public event EventHandler<LogEventArgs> Log;
		
		/// <summary>
		/// Event emitted when one Shard fails to Connect with an unrecoverable code.
		/// </summary>
		public event EventHandler<Exception> Error;
		
		/// <summary>
		/// Event emitted when Shards receive Dispatches.
		/// </summary>
		public event EventHandler<DispatchEventArgs> Dispatch;

		/// <summary>
		/// Event emitted when this Shard send there Identify packet.
		/// </summary>
		private event EventHandler Identified;
		
		/// <summary>
		/// The Cluster this Shard is part of.
		/// </summary>
		public Cluster Cluster { get; }
		
		/// <summary>
		/// The ID of this Shard.
		/// </summary>
		public int ID { get; }

		/// <summary>
		/// The WebSocketClient of this Shard.
		/// </summary>
		private WebSocketClient WebSocketClient { get; set; }
		
		/// <summary>
		/// If the last Heartbeat was acknowledged.
		/// </summary>
		private bool LastHeartbeatAcked { get; set; } = true;

		/// <summary>
		/// The Token this shard should use.
		/// </summary>
		private string Token 
			=> Cluster != null ? Cluster.Token : ProvidedToken;
		
		/// <summary>
		/// The Token provided in the constructor.
		/// </summary>
		private string ProvidedToken { get; }
		
		/// <summary>
		/// The ShardCount provided in the constructor.
		/// </summary>
		private int? ProvidedShardCount { get; set; }
		
		/// <summary>
		/// The current Sequence of this Shard.
		/// </summary>
		private int? Sequence { get; set; }
		
		/// <summary>
		/// The current SessionID of this Shard.
		/// </summary>
		private string SessionID { get; set; }
		
		/// <summary>
		/// The current Trace of this Shard.
		/// </summary>
		private string[] Trace { get; set; }

		/// <summary>
		/// The Sequence the connection closed with.
		/// </summary>
		private int? CloseSequence { get; set; }
		
		/// <summary>
		/// The Ratelimiter for this Shard.
		/// </summary>
		private readonly TimeLimiter _ratelimiter = TimeLimiter.GetFromMaxCountByInterval(120, TimeSpan.FromMinutes(1));

		/// <summary>
		/// The Timer which handles Heartbeats of this Shard.
		/// </summary>
		private Timer _heartbeatTimer;

		/// <summary>
		/// The delay which should be used between reconnect attempts in ms.
		/// </summary>
		private int _reconnectDelay;
		
		/// <summary>
		/// Creates an instance from a Cluster.
		/// </summary>
		/// <param name="cluster">The Cluster this Shard is part of.</param>
		/// <param name="id">The ID of this Shard.</param>
		public Shard(Cluster cluster, int id)
		{
			Cluster = cluster;
			ID = id;
		}

		/// <summary>
		/// Creates an instance of Shard.
		/// </summary>
		/// <param name="token">The Token to use.</param>
		/// <param name="id">The ID of this Shard.</param>
		/// <param name="shardCount">The ShardCount that is used.</param>
		// ReSharper disable once UnusedMember.Global
		public Shard(string token, int id, int shardCount)
		{
			ProvidedToken = token;
			ID = id;
			ProvidedShardCount = shardCount;
		}

		/// <summary>
		/// Connects this Shard to the Discord Gateway.
		/// </summary>
		/// <returns>Task</returns>
		public async Task ConnectAsync()
		{
			LastHeartbeatAcked = true;
			
			if (WebSocketClient != null)
			{
				_log(LogLevel.DEBUG, "Disposing old WebSocketClient...");
				WebSocketClient.Open -= _onOpen;
				WebSocketClient.Message -= _onMessage;
				WebSocketClient.Close -= _onClose;
				WebSocketClient.Error -= _onError;
				WebSocketClient.Dispose();
				_stopHeartbeatTimer();
			}
			
			if (Cluster != null)
			{
				WebSocketClient = new WebSocketClient(Cluster.Gateway.URL, null);
			} else {
				var res = await _getGatewayAsync();
				if (ProvidedShardCount == null) ProvidedShardCount = res.Shards;
				WebSocketClient = new WebSocketClient(res.URL, null);
			}

			WebSocketClient.Open += _onOpen;
			WebSocketClient.Message += _onMessage;
			WebSocketClient.Close += _onClose;
			WebSocketClient.Error += _onError;	
			
			
			_log(LogLevel.DEBUG, "Connecting to Websocket...");
			try
			{
				await WebSocketClient.ConnectAsync();
				_reconnectDelay = 0;
			}
			catch (Exception e)
			{
				if (_reconnectDelay == 0)
				{
					_reconnectDelay = 1000;
				}
				else
				{
					_reconnectDelay *= 2;	
				}
				_log(LogLevel.ERROR, $"Websocket connection errored with {e.Message}, retrying in {TimeSpan.FromMilliseconds(_reconnectDelay).TotalSeconds} seconds...");
				await Task.Delay(_reconnectDelay);
				await ConnectAsync();
				return;
			}

			await _waitForIdentify();
		}

		/// <summary>
		/// Disconnects from the Discord Gateway.
		/// </summary>
		/// <param name="closeCode">The Status this Connection should be closed with.</param>
		/// <param name="closeText">The Status text this Connection should be closed with.</param>
		/// <returns>Task</returns>
		public Task DisconnectAsync(int closeCode, string closeText)
		{
			_log(LogLevel.DEBUG, $"Disconnecting with reason {closeCode}: {closeText}...");
			return WebSocketClient.CloseAsync((WebSocketCloseStatus) closeCode, closeText);
		}

		/// <summary>
		/// Queues a Message to be send to the WebSocket Server.
		/// </summary>
		/// <param name="opCode">The OPCode of this Message.</param>
		/// <param name="data">The Data of this Message.</param>
		/// <returns>Task</returns>
		public Task Send(OpCode opCode, object data) 
			=> _ratelimiter.Perform(() => _send(opCode, data));

		/// <inheritdoc />
		public void Dispose()
		{
			WebSocketClient?.Dispose();
		}

		/// <summary>
		/// Sends a Message to the WebSocket Server.
		/// </summary>
		/// <param name="opCode">The OPCode of this Message.</param>
		/// <param name="data">The Data of this Message.</param>
		/// <returns>Task</returns>
		private Task _send(OpCode opCode, object data)
		{
			var packet = new SendPacket
			{
				OpCode = opCode,
				Data = data
			};

			return WebSocketClient.SendAsync(JsonConvert.SerializeObject(packet));
		}

		/// <summary>
		/// Handles incoming messages.
		/// </summary>
		/// <param name="json">the incoming json as string</param>
		private void _handleMessage(string json)
		{
			var packet = JsonConvert.DeserializeObject<ReceivePacket>(json);

			// ReSharper disable once SwitchStatementMissingSomeCases
			switch (packet.OpCode)
			{
				case OpCode.DISPATCH:
				{
					// ReSharper disable once SwitchStatementMissingSomeCases
					switch (packet.Type)
					{
						case GatewayEvent.READY:
							var readyDispatch = ((JObject) packet.Data).ToObject<ReadyDispatch>();
							Trace = readyDispatch.Trace;
							SessionID = readyDispatch.SessionID;
							_log(LogLevel.DEBUG, $"Ready {Trace[0]} -> {Trace[1]} {readyDispatch.SessionID}");
							_log(LogLevel.INFO, "Shard Ready");
							Identified?.Invoke(this, null);
							break;
						case GatewayEvent.RESUMED:
						{
							var resumedDispatch = ((JObject) packet.Data).ToObject<ResumedDispatch>();
							Trace = resumedDispatch.Trace;
							var replayed = CloseSequence - Sequence;
							_log(LogLevel.DEBUG,
								$"RESUMED {Trace[0]} -> {Trace[1]} {SessionID} | replayed {replayed} events.");
							_log(LogLevel.INFO, "Shard resumed connection");
							break;
						}
					}

					if (packet.Seq != null)
					{
						Sequence = (int) packet.Seq;
					}
					
					// ReSharper disable once PossibleInvalidOperationException
					Dispatch?.Invoke(this, new DispatchEventArgs(ID, ((JObject) packet.Data), (GatewayEvent) packet.Type));
					_log(LogLevel.DEBUG, $"Received Dispatch of type {packet.Type}");
					break;
				}
				case OpCode.HEARTBEAT:
					_log(LogLevel.DEBUG, $"Received Keep-Alive request  (OP {packet.OpCode}). Sending response...");
					_heartbeatAsync().ConfigureAwait(false);
					break;
				case OpCode.RECONNECT:
					_log(LogLevel.DEBUG, $"Received Reconnect request (OP {packet.OpCode}). Closing connection now...");
					break;
				case OpCode.INVALID_SESSION:
					_log(LogLevel.DEBUG, $"Received Invalidate request (OP {packet.OpCode}). Invalidating....");
					var data = (bool) packet.Data;
					if (data)
					{
						DisconnectAsync((int) GatewayCloseCode.UNKNOWN_ERROR, "Session Invalidated").ConfigureAwait(false);
						break;
					}

					SessionID = null;
					Sequence = null;
					Thread.Sleep(TimeSpan.FromSeconds(5));
					DisconnectAsync((int) WebSocketCloseStatus.NormalClosure, "Session Invalidated").ConfigureAwait(false);
					break;
				case OpCode.HELLO:
					_log(LogLevel.DEBUG, $"Received HELLO packet (OP {packet.OpCode}). Initializing keep-alive...");
					var helloData = ((JObject) packet.Data).ToObject<HelloPacket>();
					Trace = helloData.Trace;
					_startHeartbeatTimer(helloData.HeartbeatInterval);
					
					_authenticateAsync();
					break;
				case OpCode.HEARTBEAT_ACK:
					_log(LogLevel.DEBUG, $"Received Heartbeat Ack (OP {packet.OpCode})");
					LastHeartbeatAcked = true;
					break;
				default:
					_log(LogLevel.DEBUG, $"Received unknown op-code: {packet.OpCode}");
					break;
			}
		}

		/// <summary>
		/// Decide if we either Resume a Session or Identify as a new one.
		/// </summary>
		/// <returns>Task</returns>
		// ReSharper disable once UnusedMethodReturnValue.Local
		private Task _authenticateAsync()
		{
			_log(LogLevel.DEBUG, "Authenticate to Discord");

			return SessionID != null ? _resumeAsync() : _queueIdentifyAsync();
		}

		/// <summary>
		/// Queues an Identify Message.
		/// </summary>
		/// <returns>Task</returns>
		private Task _queueIdentifyAsync() 
			=> Cluster != null ? Cluster.Ratelimiter.Perform(_identifyAsync) : _identifyAsync();

		/// <summary>
		/// Sends an Identify Message to the WebSocket Server.
		/// </summary>
		/// <returns>Task.</returns>
		private Task _identifyAsync()
		{
			_log(LogLevel.DEBUG, "Identifying as a new session");

			// ReSharper disable once PossibleNullReferenceException
			var shardCount = (int) (Cluster?.Shards.Count ?? ProvidedShardCount);

			return Send(OpCode.IDENTIFY, new IdentifyPacket
			{
				Token = Token,
				Properties = new IdentifyProperties
				{
					OS = Enum.GetName(typeof(PlatformID), Environment.OSVersion.Platform),
					Browser = "Spectacles.NET",
					Device = "Spectacles.NET"
				},
				Shard = new []{ID, shardCount}
			});
		}

		/// <summary>
		/// Sends an Resume Message to the WebSocket Server.
		/// </summary>
		/// <returns>Task.</returns>
		private Task _resumeAsync()
		{
			_log(LogLevel.DEBUG, $"Attempting to resume session {SessionID}");

			
			return Send(OpCode.RESUME, new ResumePacket
			{
				Token = Token,
				SessionID = SessionID,
				// ReSharper disable once PossibleInvalidOperationException
				Sequence = (int) Sequence
			});
		}

		/// <summary>
		/// Sends a Heartbeat to the WebSocket Server.
		/// </summary>
		/// <returns>Task</returns>
		private Task _heartbeatAsync()
		{
			_log(LogLevel.DEBUG, "Sending a Heartbeat");
			LastHeartbeatAcked = false;

			return Send(OpCode.HEARTBEAT, Sequence);
		}

		/// <summary>
		/// Setups the Heartbeat Timer.
		/// </summary>
		private void _startHeartbeatTimer(long heartbeat)
		{
			_log(LogLevel.DEBUG, "Setup the Heartbeat Timer...");
			_heartbeatTimer = new Timer(heartbeat);
			_heartbeatTimer.Elapsed += _onHeartbeat;
			_heartbeatTimer.AutoReset = true;
			_heartbeatTimer.Enabled = true;
		}

		/// <summary>
		/// Stops the Heartbeat Timer and disposes it.
		/// </summary>
		private void _stopHeartbeatTimer()
		{
			if (_heartbeatTimer == null) return;
			_log(LogLevel.DEBUG, "Stop and dispose the Heartbeat Timer...");
			_heartbeatTimer.Stop();
			_heartbeatTimer.Dispose();
			_heartbeatTimer = null;
		}

		/// <summary>
		/// Called when the Heartbeat Timer fires.
		/// </summary>
		/// <param name="sender">The sender of this event.</param>
		/// <param name="args">The ElapsedEventArgs of this event.</param>
		private async void _onHeartbeat(object sender, ElapsedEventArgs args)
		{
			if (!LastHeartbeatAcked)
			{
				try
				{
					await DisconnectAsync((int) GatewayCloseCode.UNKNOWN_ERROR,
						"Received no heartbeat acknowledge in time, assuming zombie connection.");
					return;
				}
				catch (Exception e)
				{
					_log(LogLevel.WARN, $"Couldn't Disconnect the Connection with the reason: {e.Message}, Reconnecting...");
					ConnectAsync().ConfigureAwait(false);
				}
			}
			try
			{
				await _heartbeatAsync();
			}
			catch (Exception e)
			{
				_log(LogLevel.WARN, $"Couldn't send a Heartbeat with the reason: {e.Message}, Reconnecting...");
				ConnectAsync().ConfigureAwait(false);
			}
		}
		
		/// <summary>
		/// Gets the /Gateway/Bot response to determine the WebSocket URI to use.
		/// </summary>
		/// <returns>Task</returns>
		private async Task<GatewayBot> _getGatewayAsync()
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", Token);
				httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
				var res = await httpClient.GetAsync($"{APIEndpoints.APIBaseURL}/{APIEndpoints.BotGateway}");
				var body = await res.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<GatewayBot>(body);	
			}
		}

		/// <summary>
		/// Returns a Task which resolves when the shard sent the identify packet.
		/// </summary>
		/// <returns>Task</returns>
		private Task _waitForIdentify()
		{
			var tcs = new TaskCompletionSource<bool>();

			Identified += (sender, args) => tcs.TrySetResult(true);

			return tcs.Task;
		}

		/// <summary>
		/// Called when the WebSocket Connection opens.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="args">The EventArgs.</param>
		private void _onOpen(object sender, EventArgs args)
		{
			_log(LogLevel.DEBUG, "Websocket connection opened");
		}

		/// <summary>
		/// Called when the WebSocket Connection receives a Message.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="json">The json string received.</param>
		private void _onMessage(object sender, string json) 
			=> _handleMessage(json);

		/// <summary>
		/// Called when the WebSocket Connection Closes.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="args">The WebSocketCloseEventArgs.</param>
		private void _onClose(object sender, WebSocketCloseEventArgs args)
		{
			_log(LogLevel.WARN, $"Websocket disconnected with {args.CloseCode}: {args.Reason}");
			CloseSequence = Sequence;
			if ((GatewayCloseCode) args.CloseCode == GatewayCloseCode.INVALID_SHARD ||
			    (GatewayCloseCode) args.CloseCode == GatewayCloseCode.SHARDING_REQUIRED ||
			    (GatewayCloseCode) args.CloseCode == GatewayCloseCode.AUTHENTICATION_FAILED)
				Error?.Invoke(this,
					new Exception($"Websocket Disconnected with unrecoverable code {args.CloseCode}: {args.Reason}"));
			else
				ConnectAsync().ConfigureAwait(false);
		}

		/// <summary>
		/// Called when the WebSocket Connection encounters an error.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="error">The Exception.</param>
		private void _onError(object sender, Exception error)
		{
			_log(LogLevel.WARN, $"Websocket encountered Exception {error.Message}, reconnecting...");
			ConnectAsync().ConfigureAwait(false);
		}

		/// <summary>
		/// Emits something on the Log event
		/// </summary>
		/// <param name="level">The LogLevel of this log</param>
		/// <param name="message">The message of this log</param>
		private void _log(LogLevel level, string message) 
			=> Log?.Invoke(this, new LogEventArgs(level, $"Shard {ID}", message));
	}
}
