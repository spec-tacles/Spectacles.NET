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

		public Task<object> GetAsync()
		{
			return Client.Request(Route, RequestMethod.GET, null);
		}
		
		public Task<T> GetAsync<T>()
		{
			return Client.Request<T>(Route, RequestMethod.GET, null);
		}

		public Task<object> GetAsync(Dictionary<string, string> queries)
		{
			return Client.Request(Route, RequestMethod.GET, new FormUrlEncodedContent(queries));	
		}
		
		public Task<T> GetAsync<T>(Dictionary<string, string> queries)
		{
			return Client.Request<T>(Route, RequestMethod.GET, new FormUrlEncodedContent(queries));	
		}

		public Task<object> PatchAsync(object json, string reason)
		{
			return Client.Request(Route, RequestMethod.PATCH, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}
		
		public Task<T> PatchAsync<T>(object json, string reason)
		{
			return Client.Request<T>(Route, RequestMethod.PATCH, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<object> PutAsync(object json, string reason)
		{
			return Client.Request(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}
		
		public Task<T> PutAsync<T>(object json, string reason)
		{
			return Client.Request<T>(Route, RequestMethod.PUT, new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json"), reason);
		}

		public Task<object> DeleteAsync(string reason)
		{
			return Client.Request(Route, RequestMethod.DELETE, null, reason);
		}
		
		public Task<T> DeleteAsync<T>(string reason)
		{
			return Client.Request<T>(Route, RequestMethod.DELETE, null, reason);
		}

		public Task<object> PostAsync(object data, string reason)
		{
			var type = data.GetType();
			
			var prop1 = type.GetProperty("file");
			var prop2 = type.GetProperty("File");

			var prop = prop1 ?? prop2;
			
			var fileValue = prop?.GetValue(data);
			
			if (fileValue != null)
			{
				var content = new MultipartFormDataContent();

				if (fileValue is IEnumerable<IFile> files)
				{
					foreach (var file in files)
					{
						content.Add(new ByteArrayContent(file.Value), "file", file.Name);
					}
					
					prop.SetValue(data, null);
					
					content.Add(new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), "payload_json");

					return Client.Request(Route, RequestMethod.POST, content, reason);
				}

				throw new ArgumentException($"Expected IEnumerable<IFile>, got {fileValue?.GetType()}");
			}
			
			return Client.Request(Route, RequestMethod.POST, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), reason);
		}
		
		public Task<T> PostAsync<T>(object data, string reason)
		{
			var type = data.GetType();
			
			var prop1 = type.GetProperty("file");
			var prop2 = type.GetProperty("File");

			var prop = prop1 ?? prop2;
			
			var fileValue = prop?.GetValue(data);
			
			if (fileValue != null)
			{
				var content = new MultipartFormDataContent();

				if (fileValue is IEnumerable<IFile> files)
				{
					foreach (var file in files)
					{
						content.Add(new ByteArrayContent(file.Value), "file", file.Name);
					}
					
					prop.SetValue(data, null);
					
					content.Add(new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), "payload_json");

					return Client.Request<T>(Route, RequestMethod.POST, content, reason);
				}

				throw new ArgumentException($"Expected IEnumerable<IFile>, got {fileValue?.GetType()}");
			}
			
			return Client.Request<T>(Route, RequestMethod.POST, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), reason);
		}
	}
}
