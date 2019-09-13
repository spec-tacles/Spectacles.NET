using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RateLimiter;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway
{
	/// <summary>
	///     Gateway
	/// </summary>
	public class Gateway
	{
		/// <summary>
		///     Creates a new instance of Gateway from a Token and uses the recommend shardCount
		/// </summary>
		/// <param name="token">The token of this Gateway</param>
		/// <param name="shardCount">Optional the shard count this token will use</param>
		public Gateway(string token, int? shardCount = null)
		{
			Token = token;
			ProvidedShardCount = shardCount;
		}

		/// <summary>
		///     Storage of all known Gateways in this Application
		/// </summary>
		private static Dictionary<string, Gateway> Tokens { get; } = new Dictionary<string, Gateway>();

		/// <summary>
		///     The Ratelimiter for the Identify limit.
		/// </summary>
		public TimeLimiter Ratelimiter { get; } =
			TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromMilliseconds(5250));

		/// <summary>
		///     If this Gateway is ready to use
		/// </summary>
		public bool Ready
			=> Data != null;

		/// <summary>
		///     The Gateway Data of this instance, fetched from the Gateway/bot endpoint
		/// </summary>
		public GatewayBot Data { get; private set; }

		/// <summary>
		///     The shard count this Gateway will use
		/// </summary>
		protected int? ProvidedShardCount { get; }

		/// <summary>
		///     ShardCount getter which either gets the provided or recommend shard count.
		/// </summary>
		public int ShardCount
			=> ProvidedShardCount ?? Data.Shards;

		/// <summary>
		///     URL of the Discord Websocket Gateway.
		/// </summary>
		public string URL
			=> Data.URL;

		/// <summary>
		///     The Token of this Gateway
		/// </summary>
		public string Token { get; }

		/// <summary>
		///     Gets or Creates a Gateway from a token
		/// </summary>
		/// <param name="token">The token for this Gateway</param>
		/// <param name="shardCount">Optional shard count the bot will be using</param>
		/// <returns></returns>
		public static Gateway Get(string token, int? shardCount = null)
		{
			if (Tokens.ContainsKey(token)) return Tokens[token];
			var instance = new Gateway(token, shardCount);
			Tokens.Add(token, instance);
			return instance;
		}

		/// <summary>
		///     Fetches the /Gateway/Bot endpoint and caches it
		/// </summary>
		/// <returns></returns>
		public async Task FetchGatewayAsync()
		{
			if (Ready) return;
			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", Token);
				httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
				var res = await httpClient.GetAsync($"{APIEndpoints.APIBaseURL}/{APIEndpoints.BotGateway}");
				res.EnsureSuccessStatusCode();
				var body = await res.Content.ReadAsStringAsync();
				Data = JsonConvert.DeserializeObject<GatewayBot>(body);
			}
		}
	}
}
