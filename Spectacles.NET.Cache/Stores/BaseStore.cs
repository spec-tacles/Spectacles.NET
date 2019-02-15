// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Spectacles.NET.Cache.Stores
{
	/// <summary>
	/// Base Store which all Stores extend.
	/// </summary>
	/// <typeparam name="T">The Type this store handles.</typeparam>
	public abstract class BaseStore<T>
	{
		private CacheClient Client { get; }

		protected BaseStore(CacheClient client)
		{
			Client = client;
		}

		public abstract Task SetAsync(string key);
		
		public abstract Task SetAsync(T entry);
		
		public abstract Task SetAsync(IEnumerable<T> entries);
		
		public abstract Task<T> GetAsync(string id);

		public abstract Task<T[]> GetAllAsync();

		protected IDatabase Database 
			=> Client.Redis.GetDatabase();
	}
}