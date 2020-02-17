using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RateLimiter;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway
{
	/// <inheritdoc />
	public class Gateway : IGateway
	{
		/// <summary>
		/// Creates a new instance of Gateway from a Token & a Shard Count.
		/// </summary>
		/// <param name="token">The token of this Gateway</param>
		/// <param name="shardCount">The Shard Count to use for this Gateway</param>
		/// <param name="shardingSystem">The Sharding System to use for this Gateway</param>
		public Gateway(string token, int? shardCount, ShardingSystem shardingSystem = ShardingSystem.DEFAULT)
		{
			RawToken = token;
			ProvidedShardCount = shardCount;
			ShardingSystem = shardingSystem;
		}
		
		/// <inheritdoc />
		public IRateLimiter RateLimiter { get; } = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromSeconds(5));

		/// <inheritdoc />
		public GatewayBot Data { get; private set; }

		/// <inheritdoc />
		public bool Ready
			=> Data != null;

		/// <inheritdoc />
		public string Token
			=> $"Bot {RawToken}";

		/// <inheritdoc />
		public int ShardCount
			=> ProvidedShardCount ?? Data.Shards;
		
		/// <summary>
		/// Raw token provided
		/// </summary>
		private string RawToken { get; }
		
		/// <summary>
		/// Optional shard count provided
		/// </summary>
		private int? ProvidedShardCount { get; }
		
		/// <summary>
		/// Start Range Id of Current Shard Bucket
		/// </summary>
		private int? ShardStartRange { get; set; }
		
		/// <summary>
		/// End Range Id of Current Shard Bucket
		/// </summary>
		private int? ShardEndRange { get; set; }
		
		/// <summary>
		/// Sharding System of this Gateway
		/// </summary>
		private ShardingSystem ShardingSystem { get; }

		/// <inheritdoc />
		public async Task InitializeAsync()
		{
			if (Ready) return;
			await FetchGatewayAsync();
		}

		/// <inheritdoc />
		public async Task PerformIdentifyAsync(Func<Task> lambda, int shardId)
		{
			if (ShardingSystem == ShardingSystem.DEFAULT)
				await RateLimiter.Perform(lambda);
			else if (shardId > ShardStartRange && shardId <= ShardEndRange) await lambda();
			else
			{
				await RateLimiter.Perform(lambda);
				ShardStartRange = shardId;
				ShardEndRange = shardId + (int) ShardingSystem;
			}
		}
		
		/// <summary>
		///     Fetches the /Gateway/Bot endpoint and caches it
		/// </summary>
		/// <returns></returns>
		private async Task FetchGatewayAsync()
		{
			var message = new HttpRequestMessage();
			message.Headers.Add("Authorization", Token);
			message.Headers.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
			message.RequestUri = new Uri($"{APIEndpoints.APIBaseURL}{APIEndpoints.BotGateway}");
			var res = await Singletons.HttpClient.SendAsync(message);
			res.EnsureSuccessStatusCode();
			Data = JsonConvert.DeserializeObject<GatewayBot>(await res.Content.ReadAsStringAsync());
		}
	}
}