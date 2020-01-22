using System;

namespace Spectacles.NET.Gateway.Event
{
	/// <summary>
	/// EventArgs for the LatencyUpdateEvent
	/// </summary>
	public class LatencyUpdateArgs : EventArgs
	{
		/// <summary>
		///     Creates a new LatencyUpdateArgs instance
		/// </summary>
		/// <param name="shardId">Shard where the Dispatch occured.</param>
		/// <param name="latency">The Latency in ms.</param>
		public LatencyUpdateArgs(int shardId, int latency)
		{
			ShardId = shardId;
			Latency = latency;
		}

		/// <summary>
		///     Shard where the Latency Update occured.
		/// </summary>
		public int ShardId { get; }

		/// <summary>
		///     The Latency in ms.
		/// </summary>
		public int Latency { get; }
	}
}
