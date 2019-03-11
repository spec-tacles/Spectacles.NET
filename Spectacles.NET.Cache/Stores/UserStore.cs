using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Types;
using StackExchange.Redis;

namespace Spectacles.NET.Cache.Stores
{
	public class UserStore : IStore
	{
		public CacheClient Client { get; }

		private IDatabase Redis
			=> Client.Redis.GetDatabase();

		public UserStore(CacheClient client)
		{
			Client = client;
		}

		public Task SetAsync(string key)
		{
			return Redis.HashDeleteAsync("USERS", key);
		}

		public Task SetAsync(object entry)
		{
			var user = (User) entry;
			return Redis.HashSetAsync("USERS", new[] {new HashEntry(user.ID, JsonConvert.SerializeObject(entry))});
		}

		public Task SetAsync(IEnumerable<object> entries)
		{
			var users = (IEnumerable<User>) entries;
			var fields = users.Select(user => new HashEntry(user.ID, JsonConvert.SerializeObject(user))).ToArray();
			return Redis.HashSetAsync("USERS", fields);
		}

		public async Task<string> GetAsync(string id)
		{
			var res = await Redis.HashGetAsync("USERS", id);
			return res.ToString();
		}

		public async Task<string[]> GetAllAsync()
		{
			var res = await Redis.HashGetAllAsync("USERS");
			return res.Select(user => user.Value.ToString()).ToArray();
		}
	}
}