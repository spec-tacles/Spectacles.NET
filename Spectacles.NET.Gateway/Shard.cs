// ReSharper disable MemberCanBePrivate.Global

using System;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RateLimiter;
using Spectacles.NET.Gateway.Logging;
using Spectacles.NET.Gateway.Websocket;
using Spectacles.NET.Types;

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
		public event EventHandler<dynamic> Dispatch;

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
		/// The State of the WebSocket Connection.
		/// </summary>
		public WebSocketState? State 
			=> WebSocketClient?.Status;

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
		private int Sequence { get; set; }
		
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
		private int CloseSequence { get; set; }
		
		/// <summary>
		/// If the client is Initialized
		/// </summary>
		private bool Initialized { get; set; }
		
		/// <summary>
		/// The Ratelimiter for this Shard.
		/// </summary>
		private readonly TimeLimiter _ratelimiter = TimeLimiter.GetFromMaxCountByInterval(120, TimeSpan.FromMinutes(1));

		private Thread _heartbeatThread;

		private bool _reconnecting;
		
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
		public Shard(string token, int id, int? shardCount)
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
			if (!Initialized)
			{
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
				
				Initialized = true;
			}
			
			_log(LogLevel.DEBUG, "Connecting to Websocket...");

			try
			{
				await WebSocketClient.ConnectAsync();
				_reconnecting = false;
			}
			catch (Exception e)
			{
				_log(LogLevel.ERROR, $"Websocket connection errored with {e.Message}, retrying...");
				// await ConnectAsync();
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
			return WebSocketClient.Status == WebSocketState.Open ? WebSocketClient.CloseAsync((WebSocketCloseStatus) closeCode, closeText) : Task.FromException(new Exception("The WebSocket Connection is not open."));
		}

		/// <summary>
		/// Queues a Message to be send to the WebSocket Server.
		/// </summary>
		/// <param name="opCode">The OPCode of this Message.</param>
		/// <param name="data">The Data of this Message.</param>
		/// <returns>Task</returns>
		public Task Send(OpCode opCode, dynamic data)
		{
			return _ratelimiter.Perform(() => _send(opCode, data));
		}

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
		private Task _send(OpCode opCode, dynamic data)
		{
			var packet = new SendPacket()
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
						case "READY":
							SessionID = packet.Data["session_id"];
							Trace = packet.Data["_trace"].ToObject<string[]>();
							_log(LogLevel.DEBUG, $"Ready {Trace[0]} -> {Trace[1]} {SessionID}");
							_log(LogLevel.INFO, $"Shard {ID} got ready");
							Identified?.Invoke(this, null);
							break;
						case "RESUMED":
						{
							Trace = packet.Data["_trace"].ToObject<string[]>();
							var replayed = CloseSequence - Sequence;
							_log(LogLevel.DEBUG,
								$"RESUMED {Trace[0]} -> {Trace[1]} {SessionID} | replayed {replayed} events.");
							_log(LogLevel.INFO, $"Shard {ID} resumed connection");
							break;
						}
					}

					if (packet.Seq != null && packet.Seq > Sequence)
					{
						Sequence = (int) packet.Seq;
					}
					Dispatch?.Invoke(this, packet.Data);
					//_log(LogLevel.DEBUG, $"Received Dispatch of type {packet.Type}");
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
					if (packet.Data)
					{
						DisconnectAsync((int) GatewayCloseCode.UNKNOWN_ERROR, "Session Invalidated").ConfigureAwait(false);
						break;
					}

					SessionID = null;
					Thread.Sleep(TimeSpan.FromSeconds(5));
					DisconnectAsync((int) WebSocketCloseStatus.NormalClosure, "Session Invalidated").ConfigureAwait(false);
					break;
				case OpCode.HELLO:
					_log(LogLevel.DEBUG, $"Received HELLO packet (OP {packet.OpCode}). Initializing keep-alive...");
					Trace = packet.Data["_trace"].ToObject<string[]>();
					var heartbeat = packet.Data["heartbeat_interval"].ToObject<int>();
					_heartbeatThread = new Thread(() => _heartbeatLoop(heartbeat));
					_heartbeatThread.Start();
					
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
		private async Task _queueIdentifyAsync()
		{
			await Cluster.Ratelimiter.Perform(_identifyAsync);
		}

		/// <summary>
		/// Sends an Identify Message to the WebSocket Server.
		/// </summary>
		/// <returns>Task.</returns>
		private Task _identifyAsync()
		{
			_log(LogLevel.DEBUG, "Identifying as a new session");

			// ReSharper disable once PossibleNullReferenceException
			var shardCount = (int) (Cluster?.Shards.Count ?? ProvidedShardCount);

			return Send(OpCode.IDENTIFY, new IdentifyPacket()
			{
				Token = Token,
				Properties = new IdentifyProperties()
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

			return Send(OpCode.RESUME, new ResumePacket()
			{
				Token = Token,
				SessionID = SessionID,
				Sequence = Sequence
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
		/// Creates a Heartbeat loop.
		/// </summary>
		/// <param name="interval">The interval this loop should Heartbeat with.</param>
		/// <returns>Task</returns>
		private async void _heartbeatLoop(int interval)
		{
			while (!_reconnecting)
			{
				Thread.Sleep(interval);
				if (State != WebSocketState.Open) return;
				if (!LastHeartbeatAcked)
				{
					await DisconnectAsync((int) GatewayCloseCode.UNKNOWN_ERROR,
						"Received no heartbeat acknowledged in time, assuming zombie connection.");
					return;
				}
				await _heartbeatAsync();	
			}
		}
		
		/// <summary>
		/// Gets the /Gateway/Bot response to determine the WebSocket URI to use.
		/// </summary>
		/// <returns>Task</returns>
		private async Task<GatewayBot> _getGatewayAsync()
		{
			var request = (HttpWebRequest)WebRequest.Create($"{API.BaseURL}{API.BotGateway}");
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			request.Headers.Add("Authorization", ProvidedToken);
			request.Headers.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");

			using(var response = (HttpWebResponse)await request.GetResponseAsync())
			using(var stream = response.GetResponseStream())
			using(var reader = new StreamReader(stream ?? throw new Exception("No Body Content")))
			{
				var res = await reader.ReadToEndAsync();
				return JsonConvert.DeserializeObject<GatewayBot>(res);
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

		private void _onOpen(object sender, EventArgs args)
		{
			_log(LogLevel.DEBUG, "Websocket connection opened");
		}

		private void _onMessage(object sender, string json)
		{
			_handleMessage(json);
		}

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
				_reconnecting = true;
				ConnectAsync().ConfigureAwait(false);
		}

		private void _onError(object sender, Exception error)
		{
			_log(LogLevel.WARN, $"Websocket encountered Exception {error.Message}, reconnecting...");
			_reconnecting = true;
			ConnectAsync().ConfigureAwait(false);
		}

		/// <summary>
		/// Emits something on the Log event in another Thread
		/// </summary>
		/// <param name="level">The LogLevel of this message</param>
		/// <param name="message">The message</param>
		private void _log(LogLevel level, string message)
		{
			Log?.Invoke(this, new LogEventArgs(level, $"[Shard {ID}] {message}"));
		}
	}
}