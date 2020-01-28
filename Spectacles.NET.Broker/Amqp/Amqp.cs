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
	/// <inheritdoc />
	/// <summary>
	///     Broker made for Amqp using RabbitMQ .NET Library.
	/// </summary>
	public class AmqpBroker : IBroker
	{
		/// <summary>
		///     The consumers that this broker has registered.
		/// </summary>
		private Dictionary<string, string> ConsumerTags { get; }= new Dictionary<string, string>();

		/// <summary>
		///     The AMQP channels for subscribing
		/// </summary>
		private ConcurrentDictionary<string, IModel> SubscribeChannels { get; } =
			new ConcurrentDictionary<string, IModel>();

		/// <summary>
		///     Creates a new AMQPBroker instance.
		/// </summary>
		/// <param name="group">The AMQP exchange of this broker.</param>
		/// <param name="subgroup">
		///     The subgroup of this broker. Useful to setup multiple groups of queues that all receive the same
		///     data. Implemented internally as an extra identifier in the queue name.
		/// </param>
		/// <param name="autoAck">If the Events should be acknowledged automatically (default=false)</param>
		public AmqpBroker(string group, string subgroup = null, bool autoAck = false)
		{
			Group = group;
			Subgroup = subgroup;
			AutoAck = autoAck;
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
		///     If the Events should be acknowledged automatically (default=false)
		/// </summary>
		public bool AutoAck { get; }

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
		/// <param name="factory">Factory creating Connections</param>
		/// <returns>Task</returns>
		public Task ConnectAsync(ConnectionFactory factory)
			=> CreateConnections(factory);

		/// <summary>
		///     ConnectAsync connects this Client to the Amqp Server.
		/// </summary>
		/// <param name="url">The Connection uri as string.</param>
		/// <returns>Task</returns>
		public Task ConnectAsync(string url)
			=> ConnectAsync(new Uri(url));

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

			foreach (var value in SubscribeChannels.Values) value.Close();
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

			var correlationId = RandomString(15);

			void OnRPCConsumerOnReceived(object sender, BasicDeliverEventArgs args)
			{
				if (args.BasicProperties.CorrelationId != correlationId) return;
				tcs.TrySetResult(args.Body);
				RPCConsumer.Received -= OnRPCConsumerOnReceived;
			}

			RPCConsumer.Received += OnRPCConsumerOnReceived;

			var basicProperties = options ?? new BasicProperties();

			basicProperties.ReplyTo = RPCQueueName;
			basicProperties.CorrelationId = correlationId;

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

		/// <summary>
		/// 	Acknowledges a Message by delivery message
		/// </summary>
		/// <param name="event">The Event of the message</param>
		/// <param name="deliveryTag">The delivery tag of the message</param>
		public void Ack(string @event, ulong deliveryTag)
		{
			var model = GetOrCreateChannel(@event);
			model.BasicAck(deliveryTag, false);
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
				Receive?.Invoke(this, new AmqpReceiveEventArgs(@event, ea.Body, ea.BasicProperties, ea.DeliveryTag));
			};

			var consumerTag = model.BasicConsume(queueName, AutoAck, consumer);
			ConsumerTags.Add(@event, consumerTag);

			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task SubscribeAsync(IEnumerable<string> events)
			=> Task.WhenAll(events.Select(SubscribeAsync));

		/// <inheritdoc />
		public Task UnsubscribeAsync(string @event)
		{
			ConsumerTags.TryGetValue(@event, out var consumerTag);

			if (consumerTag == null) return Task.FromException(new Exception("No Event with this name registered"));

			var channel = GetOrCreateChannel(@event);
			channel.BasicCancel(consumerTag);
			ConsumerTags.Remove(@event);

			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task UnsubscribeAsync(IEnumerable<string> events)
			=> Task.WhenAll(events.Select(UnsubscribeAsync));

		private IModel GetOrCreateChannel(string @event)
		{
			if (SubscribeChannels.TryGetValue(@event, out var channel)) return channel;
			var createChannel = ReadConnection.CreateModel();
			SubscribeChannels.TryAdd(@event, createChannel);
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
			
			rpcModel.BasicConsume(RPCQueueName, AutoAck, RPCConsumer);

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
		/// <param name="properties">The Properties of this Event.</param>
		/// <param name="deliveryTag">The Delivery tag of this Event.</param>
		public AmqpReceiveEventArgs(string @event, byte[] data, IBasicProperties properties, ulong deliveryTag)
		{
			Properties = properties;
			DeliveryTag = deliveryTag;
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
		///     The Properties of this Event.
		/// </summary>
		public IBasicProperties Properties { get; }

		/// <summary>
		///     The Delivery Tag of this Event.
		/// </summary>
		public ulong DeliveryTag { get; }
	}
}
