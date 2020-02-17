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
		public static IGateway GetGateway(string token, int? shardCount, ShardingSystem shardingSystem)
		{
			token = token.RemoveTokenPrefix();
			if (Gateways.ContainsKey(token)) return Gateways[token];
			var instance = new Gateway(token, shardCount, shardingSystem);
			Gateways[token] = instance;
			return instance;
		}

		/// <summary>
		/// Gets the Fibonacci sequence from a number
		/// </summary>
		/// <param name="number">the sequence to get of</param>
		/// <returns></returns>
		public static int Fibonacci(int number)
		{
			if ((number == 0) || (number == 1))
				return number;

			return Fibonacci(number - 1) + Fibonacci(number - 2);
		}
	}
}
