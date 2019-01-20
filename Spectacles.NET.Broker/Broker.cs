// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMemberInSuper.Global

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spectacles.NET.Broker
{
	public abstract class Broker
	{
		public abstract Task PublishAsync(string @event, dynamic data);

		public abstract Task SubscribeAsync(string @event);
		
		public abstract Task SubscribeAsync(IEnumerable<string> events);
		
		public abstract Task UnsubscribeAsync(string @event);
		
		public abstract Task UnsubscribeAsync(IEnumerable<string> events);
	}
}