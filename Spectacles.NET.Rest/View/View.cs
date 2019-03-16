using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Rest.Interfaces;

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
			return Client.Request(Route, RequestMethod.GET, null, null);
		}
		
		public Task<dynamic> GetAsync<T>()
		{
			return Client.Request<T>(Route, RequestMethod.GET, null, null);
		}

		public Task<dynamic> GetAsync(Dictionary<string, string> queries)
		{
			return Client.Request(Route, RequestMethod.GET, new FormUrlEncodedContent(queries), null);	
		}
		
		public Task<dynamic> GetAsync<T>(Dictionary<string, string> queries)
		{
			return Client.Request<T>(Route, RequestMethod.GET, new FormUrlEncodedContent(queries), null);	
		}

		public Task<dynamic> PatchAsync(object json, string reason)
		{
			return Client.Request(Route, RequestMethod.PATCH, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}
		
		public Task<dynamic> PatchAsync<T>(object json, string reason)
		{
			return Client.Request<T>(Route, RequestMethod.PATCH, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<dynamic> PutAsync(object json, string reason)
		{
			return Client.Request(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}
		
		public Task<dynamic> PutAsync<T>(object json, string reason)
		{
			return Client.Request<T>(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<dynamic> DeleteAsync(string reason)
		{
			return Client.Request(Route, RequestMethod.DELETE, null, reason);
		}
		
		public Task<dynamic> DeleteAsync<T>(string reason)
		{
			return Client.Request<T>(Route, RequestMethod.DELETE, null, reason);
		}

		public Task<dynamic> PostAsync(object data, string reason)
		{
			dynamic json = data;

			if (json.file != null)
			{
				var content = new MultipartFormDataContent();

				if (json.file is IEnumerable<IFile> files)
				{
					foreach (var file in files)
					{
						content.Add(new ByteArrayContent(file.Value), "file", file.Name);
					}
					
					json.file = null;
					
					content.Add(new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), "payload_json");

					return Client.Request(Route, RequestMethod.POST, content, reason);
				}

				throw new ArgumentException($"Expected IEnumerable<IFile>, got {json.file.GetType()}");
			}
			
			return Client.Request(Route, RequestMethod.POST, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}
		
		public Task<dynamic> PostAsync<T>(object data, string reason)
		{
			dynamic json = data;

			if (json.file != null)
			{
				var content = new MultipartFormDataContent();

				if (json.file is IEnumerable<IFile> files)
				{
					foreach (var file in files)
					{
						content.Add(new ByteArrayContent(file.Value), "file", file.Name);
					}
					
					json.file = null;
					
					content.Add(new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), "payload_json");

					return Client.Request<T>(Route, RequestMethod.POST, content, reason);
				}

				throw new ArgumentException($"Expected IEnumerable<IFile>, got {json.file.GetType()}");
			}
			
			return Client.Request<T>(Route, RequestMethod.POST, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}
	}
}