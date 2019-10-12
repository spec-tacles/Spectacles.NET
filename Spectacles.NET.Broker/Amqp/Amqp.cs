// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable EventNeverSubscribedTo.Global

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;
using static Spectacles.NET.Util.Util;

namespace Spectacles.NET.Broker.Amqp
{
	/// <summary>
	///     Class representing ConnectOptions to Amqp.
	/// </summary>
	public class AmqpConnectOptions
	{
		/// <summary>
		///     The Username of the AMQP Server
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		///     The Password of the AMQP Server
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		///     The Virtual Host of the AMQP Server
		/// </summary>
		public string VirtualHost { get; set; }

		/// <summary>
		///     The Host Name of the AMQP Server
		/// </summary>
		public string HostName { get; set; }

		/// <summary>
		///     Optional Port for the AMQP Server
		/// </summary>
		public int? Port { get; set; }

		/// <summary>
		///     If the Client should try to Recover connections which disconnect.
		/// </summary>
		public bool? AutomaticRecoveryEnabled { get; set; }

		/// <summary>
		///     How long to wait before retrying to connect.
		/// </summary>
		public TimeSpan NetworkRecoveryInterval { get; set; }
	}

	/// <inheritdoc />
	/// <summary>
	///     Broker made for Amqp using RabbitMQ .NET Library.
	/// </summary>
	public class AmqpBroker : IBroker
	{
		/// <summary>
		///     The consumers that this broker has registered.
		/// </summary>
		private readonly Dictionary<string, string> _consumerTags = new Dictionary<string, string>();

		/// <summary>
		///     The AMQP channels for subscribing
		/// </summary>
		private readonly ConcurrentDictionary<string, IModel> _subscribeChannels =
			new ConcurrentDictionary<string, IModel>();

		/// <summary>
		///     Creates a new AMQPBroker instance.
		/// </summary>
		/// <param name="group">The AMQP exchange of this broker.</param>
		/// <param name="subgroup">
		///     The subgroup of this broker. Useful to setup multiple groups of queues that all receive the same
		///     data. Implemented internally as an extra identifier in the queue name.
		/// </param>
		public AmqpBroker(string group, string subgroup)
		{
			Group = group;
			Subgroup = subgroup;
		}

		/// <summary>
		///     The read Connection of this Client.
		/// </summary>
		public IConnection ReadConnection { get; set; }

		/// <summary>
		///     The write Connection of this Client.
		/// </summary>
		public IConnection WriteConnection { get; set; }

		/// <summary>
		///     The AMQP exchange of this broker.
		/// </summary>
		public string Group { get; }

		/// <summary>
		///     The subgroup of this broker. Useful to setup multiple groups of queues that all receive the same data.
		///     Implemented internally as an extra identifier in the queue name.
		/// </summary>
		public string Subgroup { get; }

		/// <summary>
		///     The AMQP channel for publishing events.
		/// </summary>
		public IModel PublishChannel { get; set; }

		/// <summary>
		///     The RPC Queue of this Broker
		/// </summary>
		public string RPCQueueName { get; set; }

		/// <summary>
		///     The Consumer of the RPC Queue
		/// </summary>
		public EventingBasicConsumer RPCConsumer { get; set; }

		/// <summary>
		///     Event for Received Messages this Client is Subscribed to.
		/// </summary>
		public event EventHandler<AmqpReceiveEventArgs> Receive;

		/// <summary>
		///     ConnectAsync connects this Client to the Amqp Server .
		/// </summary>
		/// <param name="options">The options for the Connection.</param>
		/// <returns>Task</returns>
		public async Task ConnectAsync(AmqpConnectOptions options)
		{
			var factory = new ConnectionFactory
			{
				UserName = options.Username,
				Password = options.Password,
				VirtualHost = options.VirtualHost,
				HostName = options.HostName,
				NetworkRecoveryInterval = options.NetworkRecoveryInterval
			};
			factory.Port = options.Port ?? factory.Port;
			factory.AutomaticRecoveryEnabled = options.AutomaticRecoveryEnabled ?? factory.AutomaticRecoveryEnabled;

			await CreateConnections(factory);
		}

		/// <summary>
		///     ConnectAsync connects this Client to the Amqp Server.
		/// </summary>
		/// <param name="url">The Connection uri as string.</param>
		/// <returns>Task</returns>
		public async Task ConnectAsync(string url)
		{
			var factory = new ConnectionFactory
			{
				Uri = new Uri(url)
			};

			await CreateConnections(factory);
		}

		/// <summary>
		///     ConnectAsync connects this Client to the Amqp Server.
		/// </summary>
		/// <param name="uri">The Connection uri</param>
		/// <returns>Task</returns>
		public async Task ConnectAsync(Uri uri)
		{
			var factory = new ConnectionFactory
			{
				Uri = uri
			};

			await CreateConnections(factory);
		}

		/// <summary>
		///     Disconnect disconnects the Client from the Amqp Server.
		/// </summary>
		/// <param name="code">The status code of the disconnect.</param>
		/// <param name="text">The status text of the disconnect.</param>
		public void Disconnect(ushort code, string text)
		{
			lock (PublishChannel)
			{
				PublishChannel.Close(code, text);
			}

			foreach (var (_, value) in _subscribeChannels) value.Close();
			WriteConnection.Close(code, text);
			ReadConnection.Close(code, text);
		}

		/// <summary>
		///     PublishAsync Publishes a message
		/// </summary>
		/// <param name="event">The name of the event to publish</param>
		/// <param name="data">The data of the event to publish</param>
		/// <param name="options">Optional options for this Publish</param>
		/// <returns>Task</returns>
		public Task PublishAsync(string @event, byte[] data, IBasicProperties options = null)
		{
			lock (PublishChannel)
			{
				PublishChannel.BasicPublish(Group, @event, false, options ?? new BasicProperties(),
					data);
			}

			return Task.CompletedTask;
		}

		/// <summary>
		///     PublishWithResponseAsync Publishes a message and waits for the response
		/// </summary>
		/// <param name="event">The name of the event to publish</param>
		/// <param name="data">The data of the event to publish</param>
		/// <param name="options">Optional options for this Publish</param>
		/// <param name="timeout">Optional the timeout to wait for the response, in ms</param>
		/// <returns>Task</returns>
		public async Task<byte[]> PublishWithResponseAsync(string @event, byte[] data, int timeout = 15000, IBasicProperties options = null)
		{
			var tcs = new TaskCompletionSource<byte[]>();

			var correlationID = RandomString(15);

			void OnRPCConsumerOnReceived(object sender, BasicDeliverEventArgs args)
			{
				if (args.BasicProperties.CorrelationId != correlationID) return;
				tcs.TrySetResult(args.Body);
				RPCConsumer.Received -= OnRPCConsumerOnReceived;
			}

			RPCConsumer.Received += OnRPCConsumerOnReceived;

			var basicProperties = options ?? new BasicProperties();

			basicProperties.ReplyTo = RPCQueueName;
			basicProperties.CorrelationId = correlationID;

			await PublishAsync(@event, data, basicProperties);

			var timer = new Timer
			{
				Interval = timeout,
				AutoReset = false,
				Enabled = true
			};
			
			void OnTimerOnElapsed(object sender, ElapsedEventArgs args)
			{
				tcs.TrySetException(new TimeoutException("RPC Response didn't arrive in time"));
				timer.Stop();
				timer.Dispose();
				RPCConsumer.Received -= OnRPCConsumerOnReceived;
			}

			timer.Elapsed += OnTimerOnElapsed;

			timer.Start();

			return await tcs.Task;
		}

		/// <inheritdoc />
		public Task SubscribeAsync(string @event)
		{
			var queueName = $"{Group}{Subgroup ?? ""}{@event}";
			var model = GetOrCreateChannel(@event);
			model.QueueDeclare(queueName, true, false, false);
			model.QueueBind(queueName, Group, @event);
			
			var consumer = new EventingBasicConsumer(model);

			consumer.Received += (ch, ea) =>
			{
				model.BasicAck(ea.DeliveryTag, false);
				Receive?.Invoke(this, new AmqpReceiveEventArgs(@event, ea.Body, ea.BasicProperties));
			};

			var consumerTag = model.BasicConsume(queueName, false, consumer);
			_consumerTags.Add(@event, consumerTag);

			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task SubscribeAsync(IEnumerable<string> events)
			=> Task.WhenAll(events.Select(SubscribeAsync));

		/// <inheritdoc />
		public Task UnsubscribeAsync(string @event)
		{
			_consumerTags.TryGetValue(@event, out var consumerTag);

			if (consumerTag == null) return Task.FromException(new Exception("No Event with this name registered"));

			var channel = GetOrCreateChannel(@event);
			channel.BasicCancel(consumerTag);
			_consumerTags.Remove(@event);

			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task UnsubscribeAsync(IEnumerable<string> events)
			=> Task.WhenAll(events.Select(UnsubscribeAsync));

		private IModel GetOrCreateChannel(string @event)
		{
			if (_subscribeChannels.TryGetValue(@event, out var channel)) return channel;
			var createChannel = ReadConnection.CreateModel();
			_subscribeChannels.TryAdd(@event, createChannel);
			return createChannel;
		}

		private Task CreateConnections(IConnectionFactory factory)
		{
			try
			{
				ReadConnection = factory.CreateConnection();
				WriteConnection = factory.CreateConnection();
			}
			catch (Exception e)
			{
				return Task.FromException(e);
			}

			PublishChannel = WriteConnection.CreateModel();

			PublishChannel.ExchangeDeclare(Group, "direct");

			var rpcModel = GetOrCreateChannel("RPC");

			RPCQueueName = rpcModel.QueueDeclare().QueueName;
			
			rpcModel.QueueBind(RPCQueueName, Group, RPCQueueName);

			RPCConsumer = new EventingBasicConsumer(rpcModel);
			
			rpcModel.BasicConsume(RPCQueueName, false, RPCConsumer);

			return Task.CompletedTask;
		}
	}

	/// <inheritdoc />
	/// <summary>
	///     EventArgs for the <see cref="AmqpBroker" /> Receive event.
	/// </summary>
	public class AmqpReceiveEventArgs : EventArgs
	{
		/// <inheritdoc />
		/// <summary>
		///     Creates a new instance of AmqpReceiveEventArgs.
		/// </summary>
		/// <param name="event">The Event which is invoked.</param>
		/// <param name="data">The Data of this Event.</param>
		/// <param name="properties">The Properties of this Event</param>
		public AmqpReceiveEventArgs(string @event, byte[] data, IBasicProperties properties)
		{
			Properties = properties;
			Event = @event;
			Data = data;
		}

		/// <summary>
		///     The Event which is invoked.
		/// </summary>
		public string Event { get; }

		/// <summary>
		///     The Data of this Event.
		/// </summary>
		public byte[] Data { get; }
		
		/// <summary>
		/// The Properties of this Event.
		/// </summary>
		public IBasicProperties Properties { get; }
	}
}
