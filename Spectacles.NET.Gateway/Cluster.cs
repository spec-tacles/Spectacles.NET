// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RateLimiter;
using Spectacles.NET.Gateway.Logging;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway
{
	/// <inheritdoc />
	/// <summary>
	/// A Cluster of Shards
	/// </summary>
	public class Cluster : IDisposable
	{
		/// <summary>
		/// Event emitted when Logs are created.
		/// </summary>
		public event EventHandler<LogEventArgs> Log;
		
		/// <summary>
		/// Event emitted when one Shard fails to Connect with an unrecoverable code.
		/// </summary>
		public event EventHandler<Exception> Error;
		
		/// <summary>
		/// Event emitted when Shards receive Dispatches.
		/// </summary>
		public event EventHandler<DispatchEventArgs> Dispatch;

		/// <summary>
		/// Event emitted when Shards send packets.
		/// </summary>
		public event EventHandler<SendEventArgs> Send;

		/// <summary>
		/// The Prefixed Token this Cluster uses.
		/// </summary>
		public string Token
		{
			get => $"Bot {ProvidedToken}";
			set => ProvidedToken = value.Replace(@"/^(Bot|Bearer)\s*/i", "");
		}
		
		/// <summary>
		/// The Token this Cluster uses.
		/// </summary>
		private string ProvidedToken { get; set; }

		/// <summary>
		/// Cached /Gateway/Bot response.
		/// </summary>
		public GatewayBot Gateway { get; set; }
		
		/// <summary>
		/// A Dictionary of Shards mapped to there ID.
		/// </summary>
		public readonly Dictionary<int, Shard> Shards = new Dictionary<int, Shard>();
		
		/// <summary>
		/// The Ratelimiter for the Identify limit.
		/// </summary>
		public readonly TimeLimiter Ratelimiter = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromMilliseconds(5250));
		
		/// <summary>
		/// The ShardCount provided by the Constructor.
		/// </summary>
		private int? ShardCount { get; }
		
		/// <summary>
		/// If this Cluster is already disposed.
		/// </summary>
		private bool Disposed { get; set; }

		/// <summary>
		/// Creates a new instance and uses the recommend shard count.
		/// </summary>
		/// <param name="token">The token of the bot.</param>
		public Cluster(string token) 
			=> Token = token;

		/// <summary>
		/// Creates a new instance and uses the provided shard count.
		/// </summary>
		/// <param name="token">The token of the bot.</param>
		/// <param name="shardCount">The shard count to use.</param>
		// ReSharper disable once UnusedMember.Global
		public Cluster(string token, int shardCount)
		{
			Token = token;
			ShardCount = shardCount;
		}

		/// <summary>
		/// Connects all Shards of this Cluster to the Gateway.
		/// </summary>
		/// <returns>Task</returns>
		public async Task ConnectAsync()
		{
			Gateway = await _getGateway();

			var shardCount = ShardCount ?? Gateway.Shards;
			
			for (var i = 0; i < shardCount; i++)
			{
				var shard = new Shard(this, i);
				shard.Log += Log;
				shard.Error += Error;
				shard.Dispatch += Dispatch;
				shard.Send += Send;
				Shards.Add(i, shard);
			}

			_log(LogLevel.INFO, $"Spawning {Shards.Count} shard(s)");
			
			foreach (var shard in Shards.Values) await shard.ConnectAsync();

			_log(LogLevel.INFO, $"Finished spawning shards");
		}
		
		/// <inheritdoc />
		/// <summary>
		/// Disposes this Cluster.
		/// </summary>
		public void Dispose()
		{
			if (Disposed) return;
			foreach (var shard in Shards.Values) shard.Dispose();
			Disposed = true;
		}

		/// <summary>
		/// Gets the /gateway/bot response.
		/// </summary>
		/// <returns>Task</returns>
		private async Task<GatewayBot> _getGateway()
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", Token);
				httpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
				var res = await httpClient.GetAsync($"{APIEndpoints.APIBaseURL}/{APIEndpoints.BotGateway}");
				res.EnsureSuccessStatusCode();
				var body = await res.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<GatewayBot>(body);	
			}
		}
		
		/// <summary>
		/// Emits something on the Log event
		/// </summary>
		/// <param name="level">The LogLevel of this log</param>
		/// <param name="message">The message of this log</param>
		private void _log(LogLevel level, string message) 
			=> Log?.Invoke(this, new LogEventArgs(level, "Cluster", message));
	}
}