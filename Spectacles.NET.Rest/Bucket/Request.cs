using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Rest.APIError;

namespace Spectacles.NET.Rest.Bucket
{
	public class Request
	{
		public event EventHandler<dynamic> Success;
		public event EventHandler<Exception> Error;

		private RequestMethod Method { get; }

		private string URL { get; }

		private HttpContent Content { get; }

		private Bucket Bucket { get; }

		private RestClient Client
			=> Bucket.Client;

		public Request(Bucket bucket, HttpContent content, RequestMethod method, string url)
		{
			Bucket = bucket;
			Content = content;
			Method = method;
			URL = url;
		}

		public async Task Execute()
		{
			Task<HttpResponseMessage> task;
			switch (Method)
			{
				case RequestMethod.GET:
					task = Client.HttpClient.GetAsync(URL);
					break;
				case RequestMethod.POST:
					task = Client.HttpClient.PostAsync(URL, Content);
					break;
				case RequestMethod.DELETE:
					task = Client.HttpClient.DeleteAsync(URL);
					break;
				case RequestMethod.PUT:
					task = Client.HttpClient.PutAsync(URL, Content);
					break;
				case RequestMethod.PATCH:
					task = Client.HttpClient.PatchAsync(URL, Content);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(Method), Method, null);
			}

			HttpResponseMessage res;
			try
			{
				res = await task;
			}
			catch (Exception e)
			{
				Error?.Invoke(this, e);
				return;
			}


			var ratelimit = new RateLimitInfo(res.Headers.ToDictionary(a => a.Key, a => a.Value.First()));
			
			var statusCode = (int) res.StatusCode;

			string content;
			try
			{
				content = await res.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				Error?.Invoke(this, e);
				return;
			}

			if (ratelimit.Remaining != null) Bucket.Remaining = (int) ratelimit.Remaining;
			if (ratelimit.Limit != null) Bucket.Limit = (int) ratelimit.Limit;
			if (ratelimit.Reset != null) Bucket.Timeout = (int) ((DateTimeOffset) ratelimit.Reset - DateTimeOffset.UtcNow).TotalMilliseconds;

			if (res.StatusCode == HttpStatusCode.TooManyRequests)
			{
				if (ratelimit.RetryAfter != null) Bucket.Timeout = (int) ratelimit.RetryAfter;
				if (ratelimit.IsGlobal)
				{
					if (ratelimit.RetryAfter != null) Client.GlobalTimeout = new Task(async () =>
					{
						Client.GlobalRatelimited = true;
						await Task.Delay((int) ratelimit.RetryAfter);
						Client.GlobalRatelimited = false;
						Client.GlobalTimeout = null;
					});
				}
				Bucket.Enqueue(this);
			} else if (statusCode >= 500 && statusCode < 600)
			{
				await Task.Delay(1000 + new Random().Next(1, 100) - 5);
				Bucket.Enqueue(this);
			}
			else if (!res.IsSuccessStatusCode)
			{
				var error = JsonConvert.DeserializeObject<DiscordAPIErrorResponse>(content);
				Error?.Invoke(this, new DiscordAPIException(statusCode, error.Code, error.Message));
			}
			else
			{
				Success?.Invoke(this, JsonConvert.DeserializeObject(content));
			}
		}
	}
}