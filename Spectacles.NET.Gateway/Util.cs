using Spectacles.NET.Util.Extensions;
using static Spectacles.NET.Gateway.Singletons;

namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// Utility functions used in Spectacles Gateway
	/// </summary>
	public static class Util
	{
		/// <summary>
		/// Gets a Gateway by a Token
		/// </summary>
		/// <param name="token">The token of the Gateway</param>
		/// <param name="shardCount"></param>
		/// <param name="shardingSystem">The Sharding System to use for this Gateway</param>
		/// <returns>IGateway</returns>
		public static IGateway GetGateway(string token, int? shardCount, ShardingSystem shardingSystem = ShardingSystem.DEFAULT)
		{
			token = token.RemoveTokenPrefix();
			if (Gateways.ContainsKey(token)) return Gateways[token];
			var instance = new Gateway(token, shardCount);
			Gateways[token] = instance;
			return instance;
		}
	}
}
