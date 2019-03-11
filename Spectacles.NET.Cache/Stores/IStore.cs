using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spectacles.NET.Cache.Stores
{
	public interface IStore
	{
		CacheClient Client { get; }
		
		Task SetAsync(string key);
		
		Task SetAsync(object entry);
		
		Task SetAsync(IEnumerable<object> entries);
		
		Task<string> GetAsync(string id);

		Task<string[]> GetAllAsync();
	}
}