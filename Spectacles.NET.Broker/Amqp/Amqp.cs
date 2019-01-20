using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing;

namespace Spectacles.NET.Broker
{
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
	
	public class AmqpBroker : Broker
	{
		public event EventHandler<string, string> Receive; 
		
		public IConnection Connection { get; set; }
		
		public IModel Channel { get; set; }
		
		public string Group { get; set; }
		
		public string Subgroup { get; set; }
		
		public readonly Dictionary<string, string> ConsumerTags = new Dictionary<string, string>();

		public AmqpBroker(string group, string subgroup)
		{
			Group = group;
			Subgroup = subgroup;
		}

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
			catch (Exception e)
			{
				return Task.FromException(e);
			}

			Channel = Connection.CreateModel();

			return Task.CompletedTask;
		}

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
			var queue = Channel.QueueDeclare();
			
			var consumer = new EventingBasicConsumer(Channel);

			consumer.Received += (ch, ea) =>
			{
				Receive?.Invoke(this, Encoding.UTF8.GetString(ea.Body));
				
				Channel.BasicAck(ea.DeliveryTag, false);
			};

			var consumerTag = Channel.BasicConsume(@event, false, consumer);
			
			ConsumerTags.Add(@event, consumerTag);

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
			ConsumerTags.TryGetValue(@event, out var consumerTag);

			if (consumerTag == null) return Task.FromException(new Exception("No Event with this name registered"));
			
			Channel.BasicCancel(consumerTag);

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
}