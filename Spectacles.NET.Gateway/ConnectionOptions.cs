namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// Options for Connection of Shards 
	/// </summary>
	public class ConnectionOptions
	{
		/// <summary>
		/// Reconnect Timeout to use
		/// </summary>
		public int ReconnectValue { get; set; } = 5000;
		
		/// <summary>
		/// Identify Options to use
		/// </summary>
		public IdentifyOptions IdentifyOptions { get; set; }

		/// <summary>
		/// The Sharding System to use
		/// </summary>
		public ShardingSystem ShardingSystem { get; set; } = ShardingSystem.DEFAULT;
		
		/// <summary>
		/// The Reconnect Strategy to use
		/// </summary>
		public ReconnectStrategy ReconnectStrategy { get; set; } = ReconnectStrategy.EXPONENTIAL;
	}
}
