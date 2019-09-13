using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Spectacles.NET.Rest.Redis
{
	/// <summary>
	///     A Pool of ConnectionMultiplexer
	/// </summary>
	public class ConnectionPool
	{
		/// <summary>
		///     Getter for the least used connection
		/// </summary>
		public ConnectionMultiplexer BestConnection
			=> Connections.OrderBy(entry => entry.Value.OperationCount).First().Value;

		/// <summary>
		///     If <see cref="ConnectAsync" /> was called
		/// </summary>
		public bool Connected { get; set; }

		private ConcurrentDictionary<int, ConnectionMultiplexer> Connections { get; } =
			new ConcurrentDictionary<int, ConnectionMultiplexer>();

		/// <summary>
		///     Connects all ConnectionMultiplexer asynchronously
		/// </summary>
		/// <param name="options">Redis configuration to use for the Pool</param>
		/// <param name="poolSize">Optional size of the pool, defaults to <see cref="Environment.ProcessorCount" /></param>
		/// <returns></returns>
		public async Task ConnectAsync(ConfigurationOptions options, int? poolSize)
		{
			poolSize = poolSize ?? Environment.ProcessorCount;
			for (var i = 0; i < poolSize; i++) Connections.TryAdd(i, await ConnectionMultiplexer.ConnectAsync(options));

			Connected = true;
		}
	}
}
