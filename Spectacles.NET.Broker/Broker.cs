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
		/// <returns>Task</returns>
		public abstract Task PublishAsync(string @event, byte[] data);

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
