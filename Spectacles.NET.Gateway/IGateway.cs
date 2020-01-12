using System;
using System.Threading.Tasks;
using RateLimiter;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// A Gateway instance holds information about a Discord Bot Application & Information needed to manages a bot's lifetime on the Discord WebSocket gateway.
	/// </summary>
	public interface IGateway
	{
		/// <summary>
		/// Ratelimiter for this Gateway.
		/// </summary>
		public IRateLimiter RateLimiter { get; }
		
		/// <summary>
		/// The Discord Gateway Bot Data of this Gateway, fetched from the Gateway/Bot endpoint.
		/// </summary>
		public GatewayBot Data { get; }
		
		/// <summary>
		///  If this Gateway is ready to use.
		/// </summary>
		public bool Ready { get; }
		
		/// <summary>
		/// The Token of this Gateway.
		/// </summary>
		public string Token { get; }
		
		/// <summary>
		/// The shard count this Gateway will use.
		/// </summary>
		public int ShardCount { get; }

		/// <summary>
		/// The Url of the Discord Websocket Gateway.
		/// </summary>
		public string Url
			=> Data.URL;

		/// <summary>
		/// Initialize this Gateway (e.g. fetch GatewayBot Data).
		/// </summary>
		/// <returns></returns>
		public Task InitializeAsync();

		/// <summary>
		/// Perform an Identify of a Shard.
		/// </summary>
		/// <param name="lambda">The Identify lambda</param>
		/// <param name="shardId">The Id of the Shard identifying</param>
		/// <returns>Task</returns>
		public Task PerformIdentifyAsync(Func<Task> lambda, int shardId);
	}
}
