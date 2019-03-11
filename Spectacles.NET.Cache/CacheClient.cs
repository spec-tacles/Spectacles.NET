// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

using System.Collections.Concurrent;
using System.Threading.Tasks;
using Spectacles.NET.Cache.Stores;
using StackExchange.Redis;

namespace Spectacles.NET.Cache
{
	public class CacheClient
	{
		public ConnectionMultiplexer Redis { get; }
		
		private ConcurrentDictionary<string, IStore> Stores { get; } = new ConcurrentDictionary<string, IStore>();
		
		public CacheClient(ConnectionMultiplexer redis)
		{
			Redis = redis;
			Stores.TryAdd("Users", new UserStore(this));
			Stores.TryAdd("Guilds", new GuildsStore(this));
		}

		public bool TryGetStore(string key, out IStore store)
		{
			return Stores.TryGetValue(key, out store);
		}

		public bool TryAddStore(string key, IStore value)
		{
			return Stores.TryAdd(key, value);
		}
		
		public static async Task<CacheClient> ConnectAsync(string url)
		{
			var redis = await ConnectionMultiplexer.ConnectAsync(url);
			return new CacheClient(redis);
		}
	}
}