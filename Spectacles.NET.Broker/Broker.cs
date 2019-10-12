// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMemberInSuper.Global

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spectacles.NET.Broker
{
	/// <summary>
	///     Interface all Brokers should implement
	/// </summary>
	public interface IBroker
	{
		/// <summary>
		///     SubscribeAsync subscribes to a queue
		/// </summary>
		/// <param name="event">The name of the queue to subscribe to</param>
		/// <returns>Task</returns>
		Task SubscribeAsync(string @event);

		/// <summary>
		///     SubscribeAsync subscribes to multiple queues
		/// </summary>
		/// <param name="events">An Enumerable of all Events to subscribe to</param>
		/// <returns>Task</returns>
		Task SubscribeAsync(IEnumerable<string> events);

		/// <summary>
		///     UnsubscribeAsync unsubscribe from a queue
		/// </summary>
		/// <param name="event">The name of the queue to unsubscribe from</param>
		/// <returns>Task</returns>
		Task UnsubscribeAsync(string @event);

		/// <summary>
		///     UnsubscribeAsync unsubscribe from multiple queues
		/// </summary>
		/// <param name="events">An Enumerable of all Events to unsubscribe from</param>
		/// <returns>Task</returns>
		Task UnsubscribeAsync(IEnumerable<string> events);
	}
}
