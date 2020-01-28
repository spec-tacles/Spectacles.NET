using RabbitMQ.Client;

namespace Spectacles.NET.Broker.Amqp.EventArgs
{
	/// <inheritdoc />
	/// <summary>
	///     EventArgs for the <see cref="AmqpBroker" /> Receive event.
	/// </summary>
	public class AmqpReceiveEventArgs : System.EventArgs
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
