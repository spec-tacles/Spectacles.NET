// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spectacles.NET.Gateway.Event;
using Spectacles.NET.Gateway.Logging;
using Spectacles.NET.Util.Extensions;

namespace Spectacles.NET.Gateway
{
	/// <inheritdoc />
	/// <summary>
	///     A Cluster of Shards
	/// </summary>
	public class Cluster : IDisposable
	{
		/// <summary>
		///     Creates a new instance and uses the recommend shard count.
		/// </summary>
		/// <param name="token">The token of the bot.</param>
		public Cluster(string token)
			=> Gateway = Gateway.Get(token.RemoveBotPrefix());

		/// <summary>
		///     Creates a new instance and uses the provided shard count.
		/// </summary>
		/// <param name="token">The token of the bot.</param>
		/// <param name="shardCount">The shard count to use.</param>
		// ReSharper disable once UnusedMember.Global
		public Cluster(string token, int shardCount)
			=> Gateway = Gateway.Get(token.RemoveBotPrefix(), shardCount);

		/// <summary>
		///     A Dictionary of Shards mapped to there ID.
		/// </summary>
		public Dictionary<int, Shard> Shards { get; } = new Dictionary<int, Shard>();

		/// <summary>
		///     The Gateway of this Cluster
		/// </summary>
		public Gateway Gateway { get; }

		/// <summary>
		///     The ShardCount provided by the Constructor.
		/// </summary>
		private int ShardCount
			=> Gateway.ShardCount;

		/// <summary>
		///     If this Cluster is already disposed.
		/// </summary>
		private bool Disposed { get; set; }

		/// <inheritdoc />
		/// <summary>
		///     Disposes this Cluster.
		/// </summary>
		public void Dispose()
		{
			if (Disposed) return;
			foreach (var shard in Shards.Values) shard.Dispose();
			Disposed = true;
		}

		/// <summary>
		///     Event emitted when Logs are received.
		/// </summary>
		public event EventHandler<LogEventArgs> Log;

		/// <summary>
		///     Event emitted when Shards fails to Connect with an unrecoverable code.
		/// </summary>
		public event EventHandler<ExceptionEventArgs> Error;

		/// <summary>
		///     Event emitted when Shards receive Dispatches.
		/// </summary>
		public event EventHandler<DispatchEventArgs> Dispatch;

		/// <summary>
		///     Event emitted when Shards send packets.
		/// </summary>
		public event EventHandler<SendEventArgs> Send;

		/// <summary>
		///     Connects all Shards of this Cluster to the Gateway.
		/// </summary>
		/// <returns>Task</returns>
		public async Task ConnectAsync()
		{
			if (!Gateway.Ready) await Gateway.FetchGatewayAsync();

			for (var i = 0; i < ShardCount; i++)
			{
				var shard = new Shard(this, i);
				shard.Log += Log;
				shard.Error += (sender, e) => Error?.Invoke(sender, new ExceptionEventArgs(shard.ID, e));
				shard.Dispatch += Dispatch;
				shard.Send += Send;
				Shards.Add(i, shard);
			}

			_log(LogLevel.INFO, $"Spawning {Shards.Count} shard(s)");

			foreach (var shard in Shards.Values) await shard.ConnectAsync();

			_log(LogLevel.INFO, "Finished spawning shards");
		}

		/// <summary>
		///     Emits something on the Log event
		/// </summary>
		/// <param name="level">The LogLevel of this log</param>
		/// <param name="message">The message of this log</param>
		private void _log(LogLevel level, string message)
			=> Log?.Invoke(this, new LogEventArgs(level, "Cluster", message));
	}
}
