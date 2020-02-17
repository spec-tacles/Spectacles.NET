// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RateLimiter;
using Spectacles.NET.Gateway.EventArgs;
using Spectacles.NET.Types;
using Spectacles.NET.Util.Logging;
using WS.NET;
using Timer = System.Timers.Timer;

namespace Spectacles.NET.Gateway
{
	/// <inheritdoc />
	/// <summary>
	///     A Shard represent one connection to the Discord Gateway.
	/// </summary>
	public class Shard : IDisposable
	{
		/// <summary>
		///     Creates an instance from a Cluster.
		/// </summary>
		/// <param name="cluster">The Cluster this Shard is part of.</param>
		/// <param name="id">The Id of this Shard.</param>
		/// <param name="options">Options for the Connection of this Shard</param>
		public Shard(Cluster cluster, int id, ConnectionOptions options)
		{
			options ??= new ConnectionOptions();
			IdentifyOptions = options.IdentifyOptions;
			ReconnectStrategy = options.ReconnectStrategy;
			ReconnectValue = options.ReconnectValue == 5000 && options.ReconnectStrategy == ReconnectStrategy.FIBONACCI ? 1 : options.ReconnectValue;
			Cluster = cluster;
			Id = id;
		}

		/// <summary>
		///     Creates an instance of Shard.
		/// </summary>
		/// <param name="token">The Token to use.</param>
		/// <param name="id">The Id of this Shard.</param>
		/// <param name="shardCount">The shard count that is used.</param>
		/// <param name="options">Options for the Connection of this Shard</param>
		// ReSharper disable once UnusedMember.Global
		public Shard(string token, int id, int shardCount, ConnectionOptions options)
		{
			options ??= new ConnectionOptions();
			IdentifyOptions = options.IdentifyOptions;
			ShardGateway = Util.GetGateway(token, shardCount, options.ShardingSystem);
			ReconnectStrategy = options.ReconnectStrategy;
			ReconnectValue = options.ReconnectValue == 5000 && options.ReconnectStrategy == ReconnectStrategy.FIBONACCI ? 1 : options.ReconnectValue;
			DefaultReconnectValue = ReconnectValue;
			Id = id;
		}

		/// <summary>
		/// 	Options to send while Identifying
		/// </summary>
		private IdentifyOptions IdentifyOptions { get; }

		/// <summary>
		///     The Ratelimiter for this Shard.
		/// </summary>
		private TimeLimiter Ratelimiter { get; } = TimeLimiter.GetFromMaxCountByInterval(120, TimeSpan.FromMinutes(1));

		/// <summary>
		///     The Timer which handles Heartbeats of this Shard.
		/// </summary>
		private Timer HeartbeatTimer { get; set; }

		/// <summary>
		///     The delay which should be used between reconnect attempts in ms or the Fibonacci number.
		/// </summary>
		private int ReconnectValue { get; set; }
		
		/// <summary>
		/// 	The default value of <see cref="ReconnectValue"/>
		/// </summary>
		private int DefaultReconnectValue { get; set; }
		
		/// <summary>
		/// 	The Reconnect Strategy of this 
		/// </summary>
		private ReconnectStrategy ReconnectStrategy { get; }

		/// <summary>
		///     The Gateway of this Shard or of the Cluster this shard is part of.
		/// </summary>
		public IGateway Gateway
			=> Cluster.Gateway ?? ShardGateway;

		/// <summary>
		///     The Gateway of this Shard
		/// </summary>
		private IGateway ShardGateway { get; }

		/// <summary> 
		///     The Cluster this Shard is part of if any.
		/// </summary>
		public Cluster Cluster { get; }

		/// <summary>
		///     The Id of this Shard.
		/// </summary>
		public int Id { get; }

		/// <summary>
		///     The WebSocketClient of this Shard.
		/// </summary>
		private WebSocketClient WebSocketClient { get; set; }

		/// <summary>
		///     If the last Heartbeat was acknowledged.
		/// </summary>
		private bool LastHeartbeatAcked { get; set; } = true;
		
		/// <summary>
		/// 	When the Heartbeat was sent, used to calculate the latency.
		/// </summary>
		private DateTime HeartbeatSentAt { get; set; }

		/// <summary>
		///     The current Sequence of this Shard.
		/// </summary>
		private int? Sequence { get; set; }

		/// <summary>
		///     The current SessionId of this Shard.
		/// </summary>
		private string SessionId { get; set; }

		/// <summary>
		///     The Sequence the connection closed with.
		/// </summary>
		private int? CloseSequence { get; set; }

		/// <summary>
		///     If this Shard is disposed;
		/// </summary>
		private bool Disposed { get; set; }

		/// <inheritdoc />
		public void Dispose()
		{
			if (Disposed) return;
			WebSocketClient?.Dispose();
			Disposed = true;
		}

		/// <summary>
		///     Event emitted when Logs are received.
		/// </summary>
		public event EventHandler<LogEventArgs> Log;

		/// <summary>
		///     Event emitted when this Shard fails to Connect with an unrecoverable code.
		/// </summary>
		public event EventHandler<Exception> Error;

		/// <summary>
		///     Event emitted when this Shard receive Dispatches.
		/// </summary>
		public event EventHandler<DispatchEventArgs> Dispatch;

		/// <summary>
		///     Event emitted when this Shard send packets.
		/// </summary>
		public event EventHandler<SendEventArgs> Send;

		/// <summary>
		/// 	Event emitted when this Shard Heartbeat changes, Latency in ms.
		/// </summary>
		public event EventHandler<LatencyUpdateArgs> LatencyUpdate;

		/// <summary>
		///     Event emitted when this Shard send there Identify packet.
		/// </summary>
		private event EventHandler Identified;

		/// <summary>
		///     Connects this Shard to the Discord Gateway.
		/// </summary>
		/// <returns>Task</returns>
		public async Task ConnectAsync()
		{
			if (!Gateway.Ready) await Gateway.InitializeAsync();

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

			WebSocketClient = new WebSocketClient(Gateway.Url);

			WebSocketClient.Open += _onOpen;
			WebSocketClient.Message += _onMessage;
			WebSocketClient.Close += _onClose;
			WebSocketClient.Error += _onError;


			_log(LogLevel.DEBUG, "Connecting to Websocket...");
			try
			{
				await WebSocketClient.ConnectAsync();
			}
			catch (Exception)
			{
				int delay;
				switch (ReconnectStrategy)
				{
					case ReconnectStrategy.FIBONACCI:
						delay = Util.Fibonacci(ReconnectValue);
						ReconnectValue++;
						break;
					case ReconnectStrategy.EXPONENTIAL:
						delay = ReconnectValue;
						ReconnectValue *= 2;
						break;
					case ReconnectStrategy.PERIODICALLY:
						delay = ReconnectValue;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				await Task.Delay(delay);
				await ConnectAsync();
				return;
			}

			await _waitForIdentify();
		}

		/// <summary>
		///     Disconnects from the Discord Gateway.
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
		///     Queues a Message to be send to the WebSocket Server.
		/// </summary>
		/// <param name="opCode">The OPCode of this Message.</param>
		/// <param name="data">The Data of this Message.</param>
		/// <returns>Task</returns>
		public Task SendAsync(OpCode opCode, object data)
			=> Ratelimiter.Perform(() => _sendAsync(opCode, data));

		/// <summary>
		///     Sends a Message to the WebSocket Server.
		/// </summary>
		/// <param name="opCode">The OPCode of this Message.</param>
		/// <param name="data">The Data of this Message.</param>
		/// <returns>Task</returns>
		private Task _sendAsync(OpCode opCode, object data)
		{
			var packet = new SendPacket
			{
				OpCode = opCode,
				Data = data
			};

			Send?.Invoke(this, new SendEventArgs(Id, opCode, data));

			return WebSocketClient.SendAsync(JsonConvert.SerializeObject(packet));
		}

		/// <summary>
		///     Handles incoming messages.
		/// </summary>
		/// <param name="json">the incoming json as string</param>
		private async void _handleMessage(string json)
		{
			ReceivePacket packet;
			try
			{
				packet = JsonConvert.DeserializeObject<ReceivePacket>(json);
			}
			catch (Exception e)
			{
				_log(LogLevel.WARN, $"Couldn't parse Packet JSON, {e}");
				return;
			}

			try
			{
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
								SessionId = readyDispatch.SessionId;
								_log(LogLevel.DEBUG, $"Ready {readyDispatch.SessionId}");
								_log(LogLevel.INFO, "Shard Ready");
								Identified?.Invoke(this, null);
								break;
							case GatewayEvent.RESUMED:
							{
								var replayed = CloseSequence - Sequence;
								_log(LogLevel.DEBUG,
									$"RESUMED {SessionId} | replayed {replayed} events.");
								_log(LogLevel.INFO, "Shard resumed connection");
								break;
							}
						}

						if (packet.Seq != null) Sequence = (int) packet.Seq;

						if (packet.Type == null)
						{
							_log(LogLevel.WARN, $"Received Dispatch with missing type, {packet.Data}");
							break;
						}

						Dispatch?.Invoke(this, new DispatchEventArgs(Id, packet.Data, (GatewayEvent) packet.Type));
						_log(LogLevel.DEBUG, $"Received Dispatch of type {packet.Type}");
						break;
					}
					case OpCode.HEARTBEAT:
						_log(LogLevel.DEBUG, $"Received Keep-Alive request  (OP {packet.OpCode}). Sending response...");
						await _heartbeatAsync().ConfigureAwait(false);
						break;
					case OpCode.RECONNECT:
						_log(LogLevel.DEBUG,
							$"Received Reconnect request (OP {packet.OpCode}). Closing connection now...");
						break;
					case OpCode.INVALID_SESSION:
						_log(LogLevel.DEBUG, $"Received Invalidate request (OP {packet.OpCode}). Invalidating....");
						var data = (bool) packet.Data;
						if (data)
						{
							await DisconnectAsync((int) GatewayCloseCode.UNKNOWN_ERROR, "Session Invalidated")
								.ConfigureAwait(false);
							break;
						}

						SessionId = null;
						Sequence = null;
						await Task.Delay(TimeSpan.FromSeconds(5));
						await DisconnectAsync((int) WebSocketCloseStatus.NormalClosure, "Session Invalidated");
						break;
					case OpCode.HELLO:
						_log(LogLevel.DEBUG, $"Received HELLO packet (OP {packet.OpCode}). Initializing keep-alive...");
						var helloData = ((JObject) packet.Data).ToObject<HelloPacket>();
						_startHeartbeatTimer(helloData.HeartbeatInterval);

						await _authenticateAsync();
						break;
					case OpCode.HEARTBEAT_ACK:
						var latency = DateTime.Now - HeartbeatSentAt;
						var pingMs = (int) latency.TotalMilliseconds;
						_log(LogLevel.DEBUG, $"Received Heartbeat Ack (OP {packet.OpCode}), Latency of {pingMs}ms");
						LastHeartbeatAcked = true;
						LatencyUpdate?.Invoke(this, new LatencyUpdateArgs(Id, pingMs));
						break;
					default:
						_log(LogLevel.WARN, $"Received unknown op-code: {packet.OpCode}");
						break;
				}
			}
			catch (Exception e)
			{
				_log(LogLevel.ERROR, $"Exception in Shard#_handleMessage, {e}");
			}
		}

		/// <summary>
		///     Decide if we either Resume a Session or Identify as a new one.
		/// </summary>
		/// <returns>Task</returns>
		// ReSharper disable once UnusedMethodReturnValue.Local
		private Task _authenticateAsync()
		{
			_log(LogLevel.DEBUG, "Authenticate to Discord");

			return SessionId != null ? _resumeAsync() : _queueIdentifyAsync();
		}

		/// <summary>
		///     Queues an Identify Message.
		/// </summary>
		/// <returns>Task</returns>
		private Task _queueIdentifyAsync()
			=> Gateway.PerformIdentifyAsync(_identifyAsync, Id);

		/// <summary>
		///     Sends an Identify Message to the WebSocket Server.
		/// </summary>
		/// <returns>Task</returns>
		private Task _identifyAsync()
		{
			_log(LogLevel.DEBUG, "Identifying as a new session");

			return SendAsync(OpCode.IDENTIFY, new IdentifyPacket
			{
				Token = Gateway.Token,
				Properties = new IdentifyProperties
				{
					OS = Enum.GetName(typeof(PlatformID), Environment.OSVersion.Platform),
					Browser = "Spectacles.NET",
					Device = "Spectacles.NET"
				},
				Shard = new[] {Id, Gateway.ShardCount},
				GuildSubscription = IdentifyOptions?.GuildSubscriptions,
				Presence = IdentifyOptions?.Presence,
				LargeThreshold = IdentifyOptions?.LargeThreshold,
				Intents = IdentifyOptions?.Intents
			});
		}

		/// <summary>
		///     Sends an Resume Message to the WebSocket Server.
		/// </summary>
		/// <returns>Task</returns>
		private Task _resumeAsync()
		{
			_log(LogLevel.DEBUG, $"Attempting to resume session {SessionId}");


			return SendAsync(OpCode.RESUME, new ResumePacket
			{
				Token = Gateway.Token,
				SessionId = SessionId,
				// ReSharper disable once PossibleInvalidOperationException
				Sequence = (int) Sequence
			});
		}

		/// <summary>
		///     Sends a Heartbeat to the WebSocket Server.
		/// </summary>
		/// <returns>Task</returns>
		private Task _heartbeatAsync()
		{
			_log(LogLevel.DEBUG, "Sending a Heartbeat");
			LastHeartbeatAcked = false;
			HeartbeatSentAt = DateTime.Now;

			return SendAsync(OpCode.HEARTBEAT, Sequence);
		}

		/// <summary>
		///     Setups the Heartbeat Timer.
		/// </summary>
		private void _startHeartbeatTimer(long heartbeat)
		{
			_log(LogLevel.DEBUG, "Setup the Heartbeat Timer...");
			HeartbeatTimer = new Timer(heartbeat);
			HeartbeatTimer.Elapsed += _onHeartbeat;
			HeartbeatTimer.AutoReset = true;
			HeartbeatTimer.Enabled = true;
		}

		/// <summary>
		///     Stops the Heartbeat Timer and disposes it.
		/// </summary>
		private void _stopHeartbeatTimer()
		{
			if (HeartbeatTimer == null) return;
			_log(LogLevel.DEBUG, "Stop and dispose the Heartbeat Timer...");
			HeartbeatTimer.Stop();
			HeartbeatTimer.Dispose();
			HeartbeatTimer = null;
		}

		/// <summary>
		///     Called when the Heartbeat Timer fires.
		/// </summary>
		/// <param name="sender">The sender of this event.</param>
		/// <param name="args">The ElapsedEventArgs of this event.</param>
		private async void _onHeartbeat(object sender, ElapsedEventArgs args)
		{
			if (!LastHeartbeatAcked)
				try
				{
					await DisconnectAsync((int) GatewayCloseCode.UNKNOWN_ERROR,
						"Received no heartbeat acknowledge in time, assuming zombie connection.");
					return;
				}
				catch (Exception e)
				{
					_log(LogLevel.WARN,
						$"Couldn't Disconnect the Connection with the reason: {e.Message}, Reconnecting...");
					await ConnectAsync().ConfigureAwait(false);
					return;
				}

			try
			{
				await _heartbeatAsync();
			}
			catch (Exception e)
			{
				_log(LogLevel.WARN, $"Couldn't send a Heartbeat with the reason: {e.Message}, Reconnecting...");
				await ConnectAsync().ConfigureAwait(false);
			}
		}

		/// <summary>
		///     Returns a Task which resolves when the shard sent the identify packet.
		/// </summary>
		/// <returns>Task</returns>
		private Task _waitForIdentify()
		{
			var tcs = new TaskCompletionSource<bool>();

			Identified += (sender, args) => tcs.TrySetResult(true);

			return tcs.Task;
		}

		/// <summary>
		///     Called when the WebSocket Connection opens.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="args">The EventArgs.</param>
		private void _onOpen(object sender, System.EventArgs args)
			=> _log(LogLevel.DEBUG, "Websocket connection opened");

		/// <summary>
		///     Called when the WebSocket Connection receives a Message.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="json">The json string received.</param>
		private void _onMessage(object sender, string json)
			=> _handleMessage(json);

		/// <summary>
		///     Called when the WebSocket Connection Closes.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="args">The WebSocketCloseEventArgs.</param>
		private async void _onClose(object sender, WebSocketCloseEventArgs args)
		{
			_log(LogLevel.WARN, $"Websocket disconnected with {args.CloseCode}: {args.Reason}");
			CloseSequence = Sequence;
			var closeCode = (GatewayCloseCode) args.CloseCode;
			
			// ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
			switch (closeCode)
			{
				case GatewayCloseCode.AUTHENTICATION_FAILED:
				case GatewayCloseCode.INVALID_SHARD:
				case GatewayCloseCode.SHARDING_REQUIRED:
				case GatewayCloseCode.INVALID_INTENTS:
				case GatewayCloseCode.DISALLOWED_INTENTS:
					Error?.Invoke(this,
						new Exception($"Websocket Disconnected with unrecoverable code {args.CloseCode}: {args.Reason}"));
					return;
			}
			try
			{
				await ConnectAsync().ConfigureAwait(false);
			}
			catch (Exception)
			{
				// ignored
			}
		}

		/// <summary>
		///     Called when the WebSocket Connection encounters an error.
		/// </summary>
		/// <param name="sender">The sender of the Event.</param>
		/// <param name="error">The Exception.</param>
		private async void _onError(object sender, Exception error)
		{
			_log(LogLevel.WARN, $"Websocket encountered Exception {error.Message}, reconnecting...");
			await ConnectAsync().ConfigureAwait(false);
		}

		/// <summary>
		///     Emits something on the Log event
		/// </summary>
		/// <param name="level">The LogLevel of this log</param>
		/// <param name="message">The message of this log</param>
		private void _log(LogLevel level, string message)
			=> Log?.Invoke(this, new LogEventArgs(level, $"Shard {Id}", message));
	}
}
