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
		
		private RestClient Client { get; }

		protected long? ID { get; private set; }

		protected View(RestClient client)
		{
			Client = client;
		}

		public View this[long id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		public async Task<dynamic> GetAsync()
		{
			var res = await Client.HttpClient.GetAsync(Route);
			return JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync());
		}

		public async Task<dynamic> GetAsync(Dictionary<string, string> queries)
		{
			var query = await new FormUrlEncodedContent(queries).ReadAsStringAsync();
			var path = new UriBuilder(Route)
			{
				Port = -1,
				Query = query
			};
			var res = await Client.HttpClient.GetAsync(path.Uri);
			return JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync());
		}

		public async Task<dynamic> PatchAsync(Dictionary<string, dynamic> json)
		{
			var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
			var res = await Client.HttpClient.PatchAsync(Route, content);
			return JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync());
		}

		public async Task<dynamic> PutAsync(Dictionary<string, dynamic> json)
		{
			var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
			var res = await Client.HttpClient.PutAsync(Route, content);
			return JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync());
		}

		public async Task<dynamic> DeleteAsync()
		{
			var res = await Client.HttpClient.DeleteAsync(Route);
			return JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync());
		}

		public async Task<dynamic> PostAsync(Dictionary<string, dynamic> json)
		{
			var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
			var res = await Client.HttpClient.PostAsync(Route, content);
			return JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync());
		}
	}
}