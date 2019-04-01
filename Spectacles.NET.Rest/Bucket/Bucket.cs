using System.Collections.Concurrent;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	/// Bucket for handling Ratelimits of one Route.
	/// </summary>
	public class Bucket
	{
		/// <summary>
		/// The amount of request that can be done before waiting.
		/// </summary>
		public int Limit { get; set; } = -1;
		
		/// <summary>
		/// The remaining amount of request that can be done. 
		/// </summary>
		public int Remaining { get; set; } = 1;
		
		/// <summary>
		/// The timeout to wait before continue sending requests.
		/// </summary>
		public int Timeout { get; set; }
		
		/// <summary>
		/// The RestClient which instantiated this Bucket.
		/// </summary>
		public RestClient Client { get; }
		
		/// <summary>
		/// The queue holding all the request of this Bucket.
		/// </summary>
		private readonly ConcurrentQueue<Request> _queue = new ConcurrentQueue<Request>();

		/// <summary>
		/// If this Bucket is currently Ratelimited
		/// </summary>
		private bool Limited
			=> (Client.GlobalRatelimited || Remaining < 1) && Timeout > 0;

		/// <summary>
		/// If this Bucket is currently executing Requests.
		/// </summary>
		private bool Started { get; set; }
		
		/// <summary>
		/// The Worker Thread of this Bucket.
		/// </summary>
		private Thread Worker { get; set; }

		/// <summary>
		/// Creates a new instance of Bucket.
		/// </summary>
		/// <param name="client">The RestClient which created this instance.</param>
		public Bucket(RestClient client)
		{
			Client = client;
		}

		/// <summary>
		/// Enqueues a Request in this Bucket.
		/// </summary>
		/// <param name="method">The HTTP Request method to use.</param>
		/// <param name="url">The URL to use.</param>
		/// <param name="content">The HTTPContent to use.</param>
		/// <param name="reason">Optional AuditLog reason to use.</param>
		/// <returns>Task resolving with response from Discord API</returns>
		public Task<object> Enqueue(RequestMethod method, string url, HttpContent content, string reason)
		{
			var tcs = new TaskCompletionSource<object>();
			var request = new Request(this, content, method, url, reason);
			request.Success += (sender, data) => tcs.TrySetResult(JsonConvert.DeserializeObject(data));
			request.Error += (sender, exception) => tcs.TrySetException(exception);
			Enqueue(request);
			_execute();
			return tcs.Task;
		}
		
		/// <summary>
		/// Enqueues a Request in this Bucket.
		/// </summary>
		/// <param name="method">The HTTP Request method to use.</param>
		/// <param name="url">The URL to use.</param>
		/// <param name="content">The HTTPContent to use.</param>
		/// <param name="reason">Optional AuditLog reason to use.</param>
		/// <returns>Task resolving with response from Discord API</returns>
		public Task<T> Enqueue<T>(RequestMethod method, string url, HttpContent content, string reason)
		{
			var tcs = new TaskCompletionSource<T>();
			var request = new Request(this, content, method, url, reason);
			request.Success += (sender, data) => tcs.TrySetResult(JsonConvert.DeserializeObject<T>(data));
			request.Error += (sender, exception) => tcs.TrySetException(exception);
			Enqueue(request);
			_execute();
			return tcs.Task;
		}

		/// <summary>
		/// Enqueues a Request in this Bucket.
		/// </summary>
		/// <param name="request">The request to enqueue</param>
		public void Enqueue(Request request)
			=> _queue.Enqueue(request);
		
		
		/// <summary>
		/// Creates the WorkerThread if needed.
		/// </summary>
		private void _execute()
		{
			if (Started) return;
			Started = true;
			
			Worker = new Thread(_run);
			Worker.Start();
		}

		/// <summary>
		/// The WorkerThread method to execute requests.
		/// </summary>
		private async void _run()
		{
			while (_queue.TryDequeue(out var request))
			{
				if (Limited)
				{
					if (Client.GlobalRatelimited) await Client.GlobalTimeout;
					else await Task.Delay(Timeout);
					Timeout = 0;
				}
				await request.Execute();
			}

			Started = false;
		}

		/// <summary>
		/// Creates a Route from an url.
		/// </summary>
		/// <param name="method">The HTTP request method to use.</param>
		/// <param name="url">The url to use.</param>
		/// <returns></returns>
		public static string MakeRoute(RequestMethod method, string url)
		{
			var defaultRegEx = new Regex(@"\/([a-z-]+)\/(?:[0-9]{17,19})");
			var reactionRegEx = new Regex(@"\/reactions\/[^/]+");
			var webhookRegEx = new Regex(@"^\/webhooks\/(\d+)\/[A-Za-z0-9-_]{64,}");
			var route = defaultRegEx.Replace(url, _match);
			route = reactionRegEx.Replace(route, "/reactions/:id");
			route = webhookRegEx.Replace(route, "/webhooks/$1/:token");
			
			if (method == RequestMethod.DELETE && route.EndsWith("/messages/:id"))
			{
				route = $"{method}{url}";
			}

			return route;
		}

		/// <summary>
		/// Default RegEx match method.
		/// </summary>
		/// <param name="m">The match instance.</param>
		/// <returns></returns>
		private static string _match(Match m)
		{
			var val = m.Groups[1].Value;
			return (val == "channels" || val == "guilds" || val == "webhooks") ? m.Value : $"/{val}/:id";
		}
	}
}
