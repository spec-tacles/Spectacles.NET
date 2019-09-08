using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectacles.NET.Rest.Redis;
using Spectacles.NET.Rest.Util;
using StackExchange.Redis;

namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	/// Bucket 
	/// </summary>
	public class RedisBucket : IBucket
	{
		/// <inheritdoc />
		public RestClient Client { get; }
		
		/// <summary>
		/// The route of this Bucket
		/// </summary>
		private string Route { get; }

		/// <summary>
		/// The Redis Database used by this Bucket
		/// </summary>
		private IDatabase Redis 
			=> RedisPool.BestConnection.GetDatabase();

		/// <summary>
		/// The ConnectionPool used by this Bucket
		/// </summary>
		private ConnectionPool RedisPool { get; set; }
		
		/// <summary>
		/// The queue holding all the request of this Bucket.
		/// </summary>
		private readonly ConcurrentQueue<Request> _queue = new ConcurrentQueue<Request>();

		/// <summary>
		/// If this Bucket is currently executing Requests.
		/// </summary>
		private volatile bool _started;
		
		/// <summary>
		/// The Worker Thread of this Bucket.
		/// </summary>
		private Thread Worker { get; set; }
		
		/// <summary>
		/// Route where the `:` gets removed because in Redis `:` act as separator in keys
		/// </summary>
		private string FormattedRoute 
			=> Route.Replace(":", "");
		
		/// <summary>
		/// Delay to wait before retrying to Get/Set Ratelimit information from redis
		/// </summary>
		private int RetryDelay { get; set; }

		/// <summary>
		/// Creates a new instance of Bucket.
		/// </summary>
		/// <param name="client">The RestClient which created this instance.</param>
		/// <param name="route">The route of the Bucket</param>
		/// <param name="redisPool">The ConnectionPool this Bucket should use</param>
		public RedisBucket(RestClient client, string route, ConnectionPool redisPool)
		{
			RedisPool = redisPool;
			Client = client;
			Route = route;
		}

		/// <inheritdoc />
		public Task<object> Enqueue(RequestMethod method, string url, HttpContent content, string reason)
		{
			var tcs = new TaskCompletionSource<object>();
			var request = new Request(this, content, method, url, reason);
			request.Success += (sender, data) => tcs.TrySetResult(JsonConvert.DeserializeObject(data));
			request.Error += (sender, exception) => tcs.SetException(exception);
			Enqueue(request);
			_execute();
			return tcs.Task;
		}

		/// <inheritdoc />
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


		/// <inheritdoc />
		public void Enqueue(Request request) 
			=> _queue.Enqueue(request);


		/// <inheritdoc />
		public Task SetLimit(int amount)
			=> Redis.StringSetAsync(Constants.Limit(FormattedRoute), amount.ToString());

		/// <inheritdoc />
		public Task SetRemaining(int amount)
			=> Redis.StringSetAsync(Constants.Remaining(FormattedRoute), amount.ToString());

		/// <inheritdoc />
		public Task SetTimeout(int amount)
			=> Redis.KeyExpireAsync(Constants.Remaining(FormattedRoute), TimeSpan.FromMilliseconds(amount));

		/// <inheritdoc />
		public async Task<int> GetLimit()
			=> Convert.ToInt32((await Redis.StringGetAsync(Constants.Limit(FormattedRoute))).ToString());

		/// <inheritdoc />
		public async Task<int> GetRemaining()
			=> Convert.ToInt32((await Redis.StringGetAsync(Constants.Remaining(FormattedRoute))).ToString());

		/// <inheritdoc />
		public async Task<int> GetTimeout()
		{
			var res = await Redis.KeyTimeToLiveAsync(Constants.Remaining(FormattedRoute));
			return (int) (res?.TotalMilliseconds ?? 0);
		}

		/// <inheritdoc />
		public async Task<bool> IsLimited()
			=> (await IsGloballyLimited() || await GetRemaining() < 1) && await GetTimeout() > 0;

		/// <inheritdoc />
		public async Task<bool> IsGloballyLimited() 
			=> !(await Redis.StringGetAsync(Constants.Global)).IsNullOrEmpty;

		/// <inheritdoc />
		public async Task SetGloballyLimited(int until)
		{
			await Redis.StringSetAsync(Constants.Global, "", TimeSpan.FromMilliseconds(until));
			Client.GlobalTimeout = Task.Delay(until);
		}

		/// <summary>
		/// Creates the WorkerThread if needed.
		/// </summary>
		private void _execute()
		{
			if (_started) return;
			_started = true;
			
			Worker = new Thread(_run);
			Worker.Start();
		}

		private async void _run()
		{
			while (_queue.TryDequeue(out var request))
			{
				await _handleTimeout();
				await request.Execute();
			}

			_started = false;
		}

		private async Task _handleTimeout()
		{
			try
			{
				if (await IsLimited())
				{
					if (Client.GlobalTimeout != null) await Client.GlobalTimeout;
					else await Task.Delay(await GetTimeout());
				}

				RetryDelay = 100;
			}
			catch (Exception)
			{
				RetryDelay *= 2;
				await Task.Delay(RetryDelay);
				await _handleTimeout();
			}
		}
	}
}