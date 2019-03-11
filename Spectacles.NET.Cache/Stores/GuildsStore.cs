using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Types;
using StackExchange.Redis;

namespace Spectacles.NET.Cache.Stores
{
	public class GuildsStore : IStore
	{
		public CacheClient Client { get; }

		public GuildsStore(CacheClient client)
		{
			Client = client;
		}

		private IDatabase Redis
			=> Client.Redis.GetDatabase();
		
		public Task SetAsync(string key)
		{
			return Redis.HashDeleteAsync("GUILDS", key);
		}

		public Task SetAsync(object entry)
		{
			var guild = (Guild) entry;
			return Redis.HashSetAsync("GUILDS", new[] {new HashEntry(guild.ID, JsonConvert.SerializeObject(entry))});
		}

		public Task SetAsync(IEnumerable<object> entries)
		{
			var guilds = (IEnumerable<Guild>) entries;
			var fields = guilds.Select(guild => new HashEntry(guild.ID, JsonConvert.SerializeObject(guild))).ToArray();
			return Redis.HashSetAsync("GUILDS", fields);
		}

		public async Task<string> GetAsync(string id)
		{
			var res = await Redis.HashGetAsync("GUILDS", id);
			return res.ToString();
		}

		public async Task<string[]> GetAllAsync()
		{
			var res = await Redis.HashGetAllAsync("GUILDS");
			return res.Select(user => user.Value.ToString()).ToArray();
		}
	}
}