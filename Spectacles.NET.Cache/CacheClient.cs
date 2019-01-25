// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

using System.Threading.Tasks;
using Spectacles.NET.Cache.Stores;
using StackExchange.Redis;

namespace Spectacles.NET.Cache
{
	public class CacheClient
	{
		public ConnectionMultiplexer Redis { get; }
		
		public UserStore Users { get; }

		public CacheClient(ConnectionMultiplexer redis)
		{
			Redis = redis;
			Users = new UserStore(this);
		}
		
		public static async Task<CacheClient> ConnectAsync(string url)
		{
			var redis = await ConnectionMultiplexer.ConnectAsync(url);
			return new CacheClient(redis);
		}
	}
}