using System;
using Newtonsoft.Json.Linq;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway
{
	/// <inheritdoc />
	/// <summary>
	/// EventArgs for the Cluster DispatchEvent
	/// </summary>
	public class DispatchEventArgs : EventArgs
	{
		/// <summary>
		/// Shard where the Dispatch occured.
		/// </summary>
		public int ShardID { get; }
		
		/// <summary>
		/// Data of the Dispatch.
		/// </summary>
		public JObject Data { get; }
		
		/// <summary>
		/// The Event of this Dispatch.
		/// </summary>
		public GatewayEvent Event { get; }

		/// <inheritdoc />
		/// <summary>
		/// Creates a new DispatchEventArgs instance
		/// </summary>
		/// <param name="shardID">Shard where the Dispatch occured.</param>
		/// <param name="data">Data of the Dispatch.</param>
		/// <param name="event">The Event of this Dispatch.</param>
		public DispatchEventArgs(int shardID, JObject data, GatewayEvent @event)
		{
			ShardID = shardID;
			Data = data;
			Event = @event;
		}
	}
}
