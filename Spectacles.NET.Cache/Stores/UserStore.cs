using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Types;
using StackExchange.Redis;

namespace Spectacles.NET.Cache.Stores
{
	public class UserStore : BaseStore<User>
	{
		public UserStore(CacheClient client) : base(client)
		{
			
		}

		public override Task SetAsync(string key)
		{
			return Database.HashSetAsync("users", new[] {new HashEntry(RedisValue.Unbox(key), RedisValue.Null)});
		}

		public override Task SetAsync(User entry)
		{
			return Database.HashSetAsync("users",
				new[]
				{
					new HashEntry(RedisValue.Unbox(entry.ID), RedisValue.Unbox(JsonConvert.SerializeObject(entry)))
				});
		}

		public override Task SetAsync(IEnumerable<User> entries)
		{
			var hashEntries = entries.Select(user => new HashEntry(RedisValue.Unbox(user.ID), RedisValue.Unbox(JsonConvert.SerializeObject(user)))).ToArray();
			return Database.HashSetAsync("users", hashEntries);
		}

		public override async Task<User> GetAsync(string id)
		{
			var result = await Database.HashGetAsync("users", RedisValue.Unbox(id));
			return result.Box() as User;
		}

		public override async Task<User[]> GetAllAsync()
		{
			var result = await Database.HashGetAllAsync("users");
			return result.Select(res => res.Value.Box()) as User[];
		}
	}
}