using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public abstract class View
	{
		protected View(RestClient client)
			=> Client = client;

		protected abstract string Route { get; }

		protected string Id { get; set; }

		protected RestClient Client { get; }

		public Task<object> GetAsync()
			=> Client.Request(Route, HttpMethod.Get, null);

		public Task<T> GetAsync<T>()
			=> Client.Request<T>(Route, HttpMethod.Get, null);

		public Task<object> GetAsync(Dictionary<string, string> queries)
			=> Client.Request(Route, HttpMethod.Get, new FormUrlEncodedContent(queries));

		public Task<T> GetAsync<T>(Dictionary<string, string> queries)
			=> Client.Request<T>(Route, HttpMethod.Get, new FormUrlEncodedContent(queries));

		public Task<object> PatchAsync(object json, string reason = null)
			=> Client.Request(Route, HttpMethod.Patch,
				new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);

		public Task<T> PatchAsync<T>(object json, string reason = null)
			=> Client.Request<T>(Route, HttpMethod.Patch,
				new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);

		public Task<object> PutAsync(object json, string reason = null)
			=> Client.Request(Route, HttpMethod.Put,
				new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);

		public Task<T> PutAsync<T>(object json, string reason = null)
			=> Client.Request<T>(Route, HttpMethod.Put,
				new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);

		public Task<object> DeleteAsync(string reason = null)
			=> Client.Request(Route, HttpMethod.Delete, null, reason);

		public Task<T> DeleteAsync<T>(string reason = null)
			=> Client.Request<T>(Route, HttpMethod.Delete, null, reason);

		public Task<object> PostAsync(object data, string reason = null)
			=> Client.Request(Route, HttpMethod.Post,
				new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), reason);

		public Task<T> PostAsync<T>(object data, string reason = null)
			=> Client.Request<T>(Route, HttpMethod.Post,
				new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), reason);

		public Task<T> PostAsync<T, TL>(TL data, string reason = null) where TL : SendableMessage
		{
			if (data.File == null)
				return Client.Request<T>(Route, HttpMethod.Post,
					new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), reason);
			
			var content = new MultipartFormDataContent();

			foreach (var file in data.File) content.Add(new ByteArrayContent(file.Value), "file", file.Name);

			content.Add(new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"),
				"payload_json");

			return Client.Request<T>(Route, HttpMethod.Post, content, reason);
		}
	}
}
