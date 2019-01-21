// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable EventNeverSubscribedTo.Global

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.Framing;

namespace Spectacles.NET.Broker.Amqp
{
	/// <summary>
	/// Class representing ConnectOptions to Amqp.
	/// </summary>
	public class AmqpConnectOptions
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string VirtualHost { get; set; }
		public string HostName { get; set; }
		public int? Port { get; set; }
		public bool? AutomaticRecoveryEnabled { get; set; }
		public TimeSpan NetworkRecoveryInterval { get; set; }
	}
	
	/// <inheritdoc />
	/// <summary>
	/// Broker made for Amqp using RabbitMQ .NET Library.
	/// </summary>
	public class AmqpBroker : Broker
	{
		/// <summary>
		/// Event for Received Messages this Client is Subscribed to.
		/// </summary>
		public event EventHandler<AmqpReceiveEventArgs> Receive;
		
		/// <summary>
		/// The Connection of this Client.
		/// </summary>
		public IConnection Connection { get; set; }
		
		/// <summary>
		/// The AMQP channel currently connected to.
		/// </summary>
		public IModel Channel { get; set; }
		
		/// <summary>
		/// The AMQP exchange of this broker.
		/// </summary>
		public string Group { get; }
		/// <summary>
		/// The subgroup of this broker. Useful to setup multiple groups of queues that all receive the same data.
		/// Implemented internally as an extra identifier in the queue name.
		/// </summary>
		public string Subgroup { get; }
		
		/// <summary>
		/// The consumers that this broker has registered.
		/// </summary>
		private readonly Dictionary<string, string> _consumerTags = new Dictionary<string, string>();
		
		public AmqpBroker(string group, string subgroup)
		{
			Group = group;
			Subgroup = subgroup;
		}

		/// <summary>
		/// ConnectAsync connects this Client to the Amqp Server .
		/// </summary>
		/// <param name="options">The options for the Connection.</param>
		/// <returns>Task</returns>
		public Task ConnectAsync(AmqpConnectOptions options)
		{
			var factory = new ConnectionFactory()
			{
				UserName = options.Username,
				Password = options.Password,
				VirtualHost = options.VirtualHost,
				HostName = options.HostName,
				NetworkRecoveryInterval = options.NetworkRecoveryInterval
			};
			factory.Port = options.Port ?? factory.Port;
			factory.AutomaticRecoveryEnabled = options.AutomaticRecoveryEnabled ?? factory.AutomaticRecoveryEnabled;
			try
			{
				Connection = factory.CreateConnection();
			}
			catch (Exception e)
			{
				return Task.FromException(e);
			}

			Channel = Connection.CreateModel();

			return Task.CompletedTask;
		}

		/// <summary>
		/// ConnectAsync connects this Client to the Amqp Server.
		/// </summary>
		/// <param name="connectionString">The Connection uri as string.</param>
		/// <returns>Task</returns>
		public Task ConnectAsync(string connectionString)
		{
			var factory = new ConnectionFactory()
			{
				Uri = new Uri(connectionString) 
			};
			
			try
			{
				Connection = factory.CreateConnection();
			}
			catch (BrokerUnreachableException e)
			{
				return Task.FromException(e);
			}

			Channel = Connection.CreateModel();

			return Task.CompletedTask;
		}

		/// <summary>
		/// Disconnect disconnects the Client from the Amqp Server.
		/// </summary>
		/// <param name="code">The status code of the disconnect.</param>
		/// <param name="text">The status text of the disconnect.</param>
		public void Disconnect(ushort code, string text)
		{
			Channel.Close(code, text);
			Connection.Close(code, text);
		}
		
		public override Task PublishAsync(string @event, dynamic data)
		{
			var message = Encoding.UTF8.GetBytes(data);
			Channel.BasicPublish(Group, @event, false, new BasicProperties(), message);

			return Task.CompletedTask;
		}

		public override Task SubscribeAsync(string @event)
		{
			var queueName = $"{Group}{Subgroup ?? ""}{@event}";
			Channel.QueueDeclare(queueName);
			Channel.QueueBind(queueName, Group, @event);
			
			var consumer = new EventingBasicConsumer(Channel);

			consumer.Received += (ch, ea) =>
			{
				Receive?.Invoke(this, new AmqpReceiveEventArgs(@event, Encoding.UTF8.GetString(ea.Body)));
				Channel.BasicAck(ea.DeliveryTag, false);
			};

			var consumerTag = Channel.BasicConsume(@event, false, consumer);
			_consumerTags.Add(@event, consumerTag);

			return Task.CompletedTask;
		}

		public override async Task SubscribeAsync(IEnumerable<string> events)
		{
			foreach (var @event in events)
			{
				await SubscribeAsync(@event);
			}
		}

		public override Task UnsubscribeAsync(string @event)
		{
			_consumerTags.TryGetValue(@event, out var consumerTag);
			
			if (consumerTag == null) return Task.FromException(new Exception("No Event with this name registered"));
			Channel.BasicCancel(consumerTag);
			_consumerTags.Remove(@event);

			return Task.CompletedTask;
		}

		public override async Task UnsubscribeAsync(IEnumerable<string> events)
		{
			foreach (var @event in events)
			{
				await UnsubscribeAsync(@event);
			}
		}
	}
	
	/// <inheritdoc />
	/// <summary>
	/// EventArgs for the <see cref="AmqpBroker"/> Receive event.
	/// </summary>
	public class AmqpReceiveEventArgs : EventArgs
	{
		public string Event { get; }
		public string Data { get; }

		public AmqpReceiveEventArgs(string @event, string data)
		{
			Event = @event;
			Data = data;
		}
	}

}