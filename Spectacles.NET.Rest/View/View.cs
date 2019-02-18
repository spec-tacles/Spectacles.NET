using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spectacles.NET.Rest.View
{
	public abstract class View
	{
		protected abstract string Route { get; }

		protected string ID { get; set; }
		
		protected RestClient Client { get; }

		protected View(RestClient client)
		{
			Client = client;
		}

		public Task<dynamic> GetAsync()
		{
			return Client.DoRequest(RequestMethod.GET, Route, null);
		}

		public Task<dynamic> GetAsync(Dictionary<string, string> queries)
		{
			return Client.DoRequest(RequestMethod.GET, Route, new FormUrlEncodedContent(queries));
		}

		public Task<dynamic> PatchAsync(Dictionary<string, dynamic> json)
		{
			return Client.DoRequest(RequestMethod.PATCH, Route, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"));
		}

		public Task<dynamic> PutAsync(Dictionary<string, dynamic> json)
		{
			return Client.DoRequest(RequestMethod.PUT, Route, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"));
		}

		public Task<dynamic> DeleteAsync()
		{
			return Client.DoRequest(RequestMethod.DELETE, Route, null);
		}

		public Task<dynamic> PostAsync(Dictionary<string, dynamic> json)
		{
			return Client.DoRequest(RequestMethod.POST, Route, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"));
		}
	}
}