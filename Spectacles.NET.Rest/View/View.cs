using System;
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
			return Client.Request(Route, RequestMethod.PUT, null, null);
		}

		public Task<dynamic> GetAsync(Dictionary<string, string> queries)
		{
			return Client.Request(Route, RequestMethod.PUT, new FormUrlEncodedContent(queries), null);	
		}

		public Task<dynamic> PatchAsync(Dictionary<string, dynamic> json, string reason)
		{
			return Client.Request(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<dynamic> PutAsync(Dictionary<string, dynamic> json, string reason)
		{
			return Client.Request(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<dynamic> DeleteAsync(string reason)
		{
			return Client.Request(Route, RequestMethod.PUT, null, reason);
		}

		public Task<dynamic> PostAsync(Dictionary<string, dynamic> json, string reason)
		{
			return Client.Request(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<dynamic> PostAsync(IEnumerable<Tuple<HttpContent, dynamic>> formData, string reason)
		{
			var content = new MultipartFormDataContent();
			foreach (var (key, value) in formData)
			{
				content.Add(key, value);
			}
			return Client.Request(Route, RequestMethod.PUT, content, reason);
		}
	}
}