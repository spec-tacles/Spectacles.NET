// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
		public event EventHandler<dynamic> Dispatch;
		
		/// <summary>
		/// The Token this Cluster uses.
		/// </summary>
		public string Token { get; }

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
		public readonly TimeLimiter Ratelimiter = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromSeconds(5));
		
		/// <summary>
		/// The ShardCount provided by the Constructor.
		/// </summary>
		private int? ShardCount { get; set; }

		/// <summary>
		/// Creates a new instance and uses the recommend shard count.
		/// </summary>
		/// <param name="token">The token of the bot.</param>
		public Cluster(string token)
		{
			Token = token;
		}

		/// <summary>
		/// Creates a new instance and uses the provided shard count.
		/// </summary>
		/// <param name="token">The token of the bot.</param>
		/// <param name="shardCount">The shard count to use.</param>
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

			_spawnShards(ShardCount ?? Gateway.Shards);

			_log(LogLevel.INFO, $"Starting {Shards.Count} shards");
			
			foreach (var shard in Shards.Values)
			{
				_log(LogLevel.INFO, $"Spawning shard {shard.ID}");
				await shard.ConnectAsync();
				_log(LogLevel.INFO, $"Shard {shard.ID} successfully started");
			}
		}
		
		/// <inheritdoc />
		/// <summary>
		/// Disposes this Cluster.
		/// </summary>
		public void Dispose()
		{
			foreach (var shards in Shards.Values)
			{
				shards.Dispose();
			}
		}

		/// <summary>
		/// Creates an amount of shards for this Cluster.
		/// </summary>
		/// <param name="shardCount">The amount of shards to spawn.</param>
		private void _spawnShards(int shardCount)
		{
			for (var i = 0; i < shardCount; i++)
			{
				var shard = new Shard(this, i);
				shard.Log += Log;
				shard.Error += Error;
				shard.Dispatch += Dispatch;
				Shards.Add(i, shard);
			}
		}

		/// <summary>
		/// Gets the /gateway/bot response.
		/// </summary>
		/// <returns>Task</returns>
		private async Task<GatewayBot> _getGateway()
		{
			var request = (HttpWebRequest)WebRequest.Create($"{API.BaseURL}{API.BotGateway}");
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			request.Headers.Add("Authorization", Token);
			request.Headers.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");

			using(var response = (HttpWebResponse)await request.GetResponseAsync())
			using(var stream = response.GetResponseStream())
			using(var reader = new StreamReader(stream ?? throw new Exception("No Body Content")))
			{
				var res = await reader.ReadToEndAsync();
				return JsonConvert.DeserializeObject<GatewayBot>(res);
			}
		}
		
		/// <summary>
		/// Emits something on the Log event in another Thread
		/// </summary>
		/// <param name="level">The LogLevel of this message</param>
		/// <param name="message">The message</param>
		private void _log(LogLevel level, string message)
		{
			Task.Run(() => Log?.Invoke(this, new LogEventArgs(level, $"[Cluster] {message}"))).ConfigureAwait(false);
		}
	}
}