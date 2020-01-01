using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	///     Bucket for handling Ratelimits of one Route in memory.
	/// </summary>
	public class InMemoryBucket : IBucket
	{
		/// <summary>
		///     The queue holding all the request of this Bucket.
		/// </summary>
		private readonly ConcurrentQueue<Request> _queue = new ConcurrentQueue<Request>();

		/// <summary>
		///     Creates a new instance of Bucket.
		/// </summary>
		/// <param name="client">The RestClient which created this instance.</param>
		/// <param name="route">The route of this Bucket</param>
		public InMemoryBucket(RestClient client, string route)
		{
			Client = client;
			Route = route;
		}

		/// <summary>
		///     If this Bucket is currently executing Requests.
		/// </summary>
		private bool Started { get; set; }

		/// <summary>
		///     The Worker Thread of this Bucket.
		/// </summary>
		private Thread Worker { get; set; }

		/// <summary>
		///     The amount of request that can be done before waiting.
		/// </summary>
		private int Limit { get; set; } = -1;

		/// <summary>
		///     The remaining amount of request that can be done.
		/// </summary>
		private int Remaining { get; set; } = 1;

		/// <summary>
		///     The timeout to wait before continue sending requests.
		/// </summary>
		private int Timeout { get; set; }

		/// <inheritdoc />
		public RestClient Client { get; }

		/// <inheritdoc />
		public string Route { get; }

		/// <inheritdoc />
		public Task<object> Enqueue(HttpMethod method, string url, HttpContent content, string reason)
		{
			var tcs = new TaskCompletionSource<object>();
			var request = new Request(this, content, method, url, reason);
			request.Success += (sender, data) => tcs.TrySetResult(JsonConvert.DeserializeObject(data));
			request.Error += (sender, exception) => tcs.TrySetException(exception);
			Enqueue(request);
			_execute();
			return tcs.Task;
		}

		/// <inheritdoc />
		public Task<T> Enqueue<T>(HttpMethod method, string url, HttpContent content, string reason)
		{
			var tcs = new TaskCompletionSource<T>();
			var request = new Request(this, content, method, url, reason);
			request.Success += (sender, data) => tcs.TrySetResult(JsonConvert.DeserializeObject<T>(data));
			request.Error += (sender, exception) => tcs.TrySetException(exception);
			Enqueue(request);
			_execute();
			return tcs.Task;
		}

		/// <inheritdoc />
		public void Enqueue(Request request)
			=> _queue.Enqueue(request);


		/// <inheritdoc />
		public Task SetLimit(int amount)
		{
			Limit = amount;
			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task SetRemaining(int amount)
		{
			Remaining = amount;
			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task SetTimeout(TimeSpan duration)
		{
			Timeout = (int) duration.TotalMilliseconds;
			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public Task<int> GetLimit()
			=> Task.FromResult(Limit);

		/// <inheritdoc />
		public Task<int> GetRemaining()
			=> Task.FromResult(Remaining);

		/// <inheritdoc />
		public Task<int> GetTimeout()
			=> Task.FromResult(Timeout);

		/// <inheritdoc />
		public async Task<bool> IsLimited()
			=> (await IsGloballyLimited() || Remaining < 1) && Timeout > 0;

		/// <inheritdoc />
		public Task<bool> IsGloballyLimited()
			=> Task.FromResult(Client.GlobalTimeout != null);

		/// <inheritdoc />
		public Task SetGloballyLimited(TimeSpan duration)
		{
			Client.GlobalTimeout = new Task(async () =>
			{
				await Task.Delay(duration);
				Client.GlobalTimeout = null;
			});
			return Task.CompletedTask;
		}

		/// <summary>
		///     Creates the WorkerThread if needed.
		/// </summary>
		private void _execute()
		{
			if (Started) return;
			Started = true;

			Worker = new Thread(_run);
			Worker.Start();
		}

		/// <summary>
		///     The WorkerThread method to execute requests.
		/// </summary>
		private async void _run()
		{
			while (_queue.TryDequeue(out var request))
			{
				if (await IsLimited())
				{
					if (Client.GlobalTimeout != null) await Client.GlobalTimeout;
					else await Task.Delay(Timeout);
					Timeout = 0;
				}

				await request.Execute();
			}

			Started = false;
		}
	}
}
