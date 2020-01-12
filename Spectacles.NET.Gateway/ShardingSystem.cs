namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// Discord Allows Big Bots to Login with multiple Shards at the same time. This represent how much Shards can Login at the same time
	/// </summary>
	public enum ShardingSystem
	{
		/// <summary>
		/// Default Sharding System, allows to only spawn 1 Shard at a Time.
		/// </summary>
		DEFAULT = 1,
		
		/// <summary>
		/// Big Bots Sharding, allows to spawn up to 16 Shards of the same Queue.
		/// </summary>
		BIG_BOT_SHARDING = 16,
		
		/// <summary>
		/// Very Big Bots Sharding, allows to spawn up to 64 Shards of the same Queue.
		/// </summary>
		VERY_BIG_BOT_SHARDING = 64
	}
}
