// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMemberInSuper.Global

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spectacles.NET.Broker
{
	/// <summary>
	///     Base Class All Brokers should extend
	/// </summary>
	public abstract class Broker
	{
		/// <summary>
		///     PublishAsync Publishes a message
		/// </summary>
		/// <param name="event">The name of the event to publish</param>
		/// <param name="data">The data of the event to publish</param>
		/// <param name="options">Optional options for this Publish</param>
		/// <returns>Task</returns>
		public abstract Task PublishAsync(string @event, byte[] data, object options = null);

		/// <summary>
		///     PublishAsync Publishes a message and waits for the result via RPC
		/// </summary>
		/// <param name="event">The name of the event to publish</param>
		/// <param name="data">The data of the event to publish</param>
		/// <param name="options">Optional options for this Publish</param>
		/// <param name="timeout">Optional the timeout to wait for the response</param>
		/// <returns></returns>
		public abstract Task<byte[]> PublishAsync(string @event, byte[] data, int timeout = 15, object options = null);

		/// <summary>
		///     SubscribeAsync subscribes to a queue
		/// </summary>
		/// <param name="event">The name of the queue to subscribe to</param>
		/// <returns>Task</returns>
		public abstract Task SubscribeAsync(string @event);

		/// <summary>
		///     SubscribeAsync subscribes to multiple queues
		/// </summary>
		/// <param name="events">An Enumerable of all Events to subscribe to</param>
		/// <returns>Task</returns>
		public abstract Task SubscribeAsync(IEnumerable<string> events);

		/// <summary>
		///     UnsubscribeAsync unsubscribe from a queue
		/// </summary>
		/// <param name="event">The name of the queue to unsubscribe from</param>
		/// <returns>Task</returns>
		public abstract Task UnsubscribeAsync(string @event);

		/// <summary>
		///     UnsubscribeAsync unsubscribe from multiple queues
		/// </summary>
		/// <param name="events">An Enumerable of all Events to unsubscribe from</param>
		/// <returns>Task</returns>
		public abstract Task UnsubscribeAsync(IEnumerable<string> events);
	}
}
