using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Spectacles.NET.Rest.Bucket
{
	public class Bucket
	{
		public int Limit { get; set; } = -1;
		public int Remaining { get; set; } = 1;
		public int Timeout { get; set; }
		public RestClient Client { get; }
		
		private readonly Queue<Request> _queue = new Queue<Request>();

		public bool Limited
			=> (Client.GlobalRatelimited || Remaining < 1) && Timeout > 0;

		private bool Started { get; set; }
		
		private Thread Worker { get; set; }

		public Bucket(RestClient client)
		{
			Client = client;
		}

		public Task<dynamic> Enqueue(RequestMethod method, string url, HttpContent content)
		{
			var tcs = new TaskCompletionSource<dynamic>();
			var request = new Request(this, content, method, url);
			request.Success += (sender, data) => tcs.TrySetResult(data);
			request.Error += (sender, exception) => tcs.TrySetException(exception);
			Enqueue(request);
			_execute();
			return tcs.Task;
		}
		
		
		public bool Dequeue(out Request request)
		{
			lock (_queue)
			{
				return _queue.TryDequeue(out request);
			}
		}

		public void Enqueue(Request request)
		{
			lock (_queue)
			{
				_queue.Enqueue(request);
			}
		}

		private void _execute()
		{
			if (Started) return;
			Started = true;
			
			Worker = new Thread(_run);
			Worker.Start();
		}

		private async void _run()
		{
			while (Dequeue(out var request))
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

		private static string _match(Match m)
		{
			var val = m.Groups[1].Value;
			return (val == "channels" || val == "guilds" || val == "webhooks") ? m.Value : $"/{val}/:id";
		}
	}
}