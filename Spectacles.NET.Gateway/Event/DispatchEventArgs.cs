using System;
using Newtonsoft.Json.Linq;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway.Event
{
	/// <inheritdoc />
	/// <summary>
	///     EventArgs for the DispatchEvent
	/// </summary>
	public class DispatchEventArgs : EventArgs
	{
		/// <inheritdoc />
		/// <summary>
		///     Creates a new DispatchEventArgs instance
		/// </summary>
		/// <param name="shardId">Shard where the Dispatch occured.</param>
		/// <param name="data">Data of the Dispatch.</param>
		/// <param name="event">The Event of this Dispatch.</param>
		public DispatchEventArgs(int shardId, object data, GatewayEvent @event)
		{
			ShardId = shardId;
			Data = data;
			Event = @event;
		}

		/// <summary>
		///     Shard where the Dispatch occured.
		/// </summary>
		public int ShardId { get; }

		/// <summary>
		///     Data of the Dispatch.
		/// </summary>
		public object Data { get; }

		/// <summary>
		///     The Event of this Dispatch.
		/// </summary>
		public GatewayEvent Event { get; }
	}
}
