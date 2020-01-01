using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Spectacles.NET.Rest.Bucket;
using Spectacles.NET.Rest.View;
using Spectacles.NET.Types;
using Spectacles.NET.Util.Extensions;
using Spectacles.NET.Util.Logging;

namespace Spectacles.NET.Rest
{
	/// <summary>
	///     Client to interact with the Discord REST API.
	/// </summary>
	public class RestClient
	{
		/// <summary>
		///     Unprefixed token
		/// </summary>
		private readonly string _token;

		/// <summary>
		///     Creates a new Instance of RestClient.
		/// </summary>
		/// <param name="token">The Token of the Bot.</param>
		/// <param name="proxy">Optional, Uri of what to use as BaseAddress (useful for a Rest proxy)</param>
		public RestClient(string token, Uri proxy = null)
		{
			_token = token.RemoveTokenPrefix();

			SetDefaultHeadersWithBaseUri(proxy);
		}

		/// <summary>
		///     Creates a new Instance of RestClient.
		/// </summary>
		/// <param name="token">The Token of the Bot.</param>
		/// <param name="factory">Factory which creates IBucket to use</param>
		public RestClient(string token, IBucketFactory factory) : this(token)
			=> BucketFactory = factory;

		/// <summary>
		///     Creates a new Instance of RestClient.
		/// </summary>
		/// <param name="token">The Token of the Bot.</param>
		/// <param name="proxy">Uri of what to use as BaseAddress (useful for a Rest proxy)</param>
		/// <param name="factory">Factory which creates IBucket to use</param>
		public RestClient(string token, Uri proxy, IBucketFactory factory) : this(token, proxy)
			=> BucketFactory = factory;

		/// <summary>
		///     The Buckets of this RestClient mapped by Route.
		/// </summary>
		private ConcurrentDictionary<string, IBucket> Buckets { get; } = new ConcurrentDictionary<string, IBucket>();

		/// <summary>
		///     The HttpClient of this RestClient.
		/// </summary>
		public HttpClient HttpClient { get; } = new HttpClient();

		/// <summary>
		///     The Guilds View.
		/// </summary>
		public GuildsView Guilds
			=> new GuildsView(this);

		/// <summary>
		///     The Channels View.
		/// </summary>
		public ChannelsView Channels
			=> new ChannelsView(this);

		/// <summary>
		///     The Users View.
		/// </summary>
		public UsersView Users
			=> new UsersView(this);

		/// <summary>
		///     The Invites View.
		/// </summary>
		public InvitesView Invites
			=> new InvitesView(this);

		/// <summary>
		///     The Voice View.
		/// </summary>
		public VoiceView Voice
			=> new VoiceView(this);

		/// <summary>
		///     The Webhook View.
		/// </summary>
		public WebhooksView Webhooks
			=> new WebhooksView(this);
		
		/// <summary>
		/// 	The Application View.
		/// </summary>
		public ApplicationView Application
			=> new ApplicationView(this);

		/// <summary>
		///     Task Resolving when the Client isn't Global Ratelimited anymore.
		/// </summary>
		public Task GlobalTimeout { get; set; }

		/// <summary>
		///     Factory which creates IBucket instances to use.
		/// </summary>
		private IBucketFactory BucketFactory { get; } = new InMemoryBucketFactory();

		/// <summary>
		///     The Token of this RestClient.
		/// </summary>
		private string Token
			=> $"Bot {_token}";

		/// <summary>
		///     Event emitted when Logs are received.
		/// </summary>
		public event EventHandler<LogEventArgs> Log;

		/// <summary>
		///     Enqueues a Request and Creates a Bucket if needed.
		/// </summary>
		/// <param name="method">The HTTP Method to use.</param>
		/// <param name="route">The Path to use.</param>
		/// <param name="content">The HttpContent to use.</param>
		/// <param name="auditLogReason">Optional AuditLog Reason.</param>
		/// <returns></returns>
		public Task<object> Request(string route, RequestMethod method, HttpContent content,
			string auditLogReason = null)
		{
			var bucketRoute = MakeRoute(method, route);
			if (Buckets.TryGetValue(bucketRoute, out var bucket))
				return bucket.Enqueue(method, route, content, auditLogReason);
			bucket = BucketFactory.CreateBucket(this, bucketRoute);
			Buckets.TryAdd(bucketRoute, bucket);
			return bucket.Enqueue(method, route, content, auditLogReason);
		}

		/// <summary>
		///     Enqueues a Request and Creates a Bucket if needed.
		/// </summary>
		/// <param name="method">The HTTP Method to use.</param>
		/// <param name="route">The Path to use.</param>
		/// <param name="content">The HttpContent to use.</param>
		/// <param name="auditLogReason">Optional AuditLog Reason.</param>
		/// <returns></returns>
		public Task<T> Request<T>(string route, RequestMethod method, HttpContent content, string auditLogReason = null)
		{
			var bucketRoute = MakeRoute(method, route);
			if (Buckets.TryGetValue(bucketRoute, out var bucket))
				return bucket.Enqueue<T>(method, route, content, auditLogReason);
			bucket = BucketFactory.CreateBucket(this, bucketRoute);
			Buckets.TryAdd(bucketRoute, bucket);
			return bucket.Enqueue<T>(method, route, content, auditLogReason);
		}

		/// <summary>
		///     Sets the Default Headers for the HttpClient
		/// </summary>
		private void SetDefaultHeaders()
		{
			HttpClient.DefaultRequestHeaders.Add("Authorization", Token);
			HttpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
			CreateLog(LogLevel.DEBUG, "Set HttpClient Default Headers");
		}

		/// <summary>
		///     Sets the Default Headers & BaseAddress for the HttpClient
		/// </summary>
		/// <param name="uri">The BaseAddress to set</param>
		private void SetDefaultHeadersWithBaseUri(Uri uri = null)
		{
			SetDefaultHeaders();
			HttpClient.BaseAddress = uri ?? new Uri(APIEndpoints.APIBaseURL);
			CreateLog(LogLevel.DEBUG, "Set HttpClient Base Address");
		}

		/// <summary>
		///     Creates a Route from an url.
		/// </summary>
		/// <param name="method">The HTTP request method to use.</param>
		/// <param name="url">The url to use.</param>
		/// <returns></returns>
		private static string MakeRoute(RequestMethod method, string url)
		{
			var defaultRegEx = new Regex(@"\/([a-z-]+)\/(?:[0-9]{17,19})");
			var reactionRegEx = new Regex(@"\/reactions\/[^/]+");
			var webhookRegEx = new Regex(@"^\/webhooks\/(\d+)\/[A-Za-z0-9-_]{64,}");
			var route = defaultRegEx.Replace(url, m =>
			{
				var val = m.Groups[1].Value;
				return val == "channels" || val == "guilds" || val == "webhooks" ? m.Value : $"/{val}/:id";
			});
			route = reactionRegEx.Replace(route, "/reactions/:id");
			route = webhookRegEx.Replace(route, "/webhooks/$1/:token");

			if (method == RequestMethod.DELETE && route.EndsWith("/messages/:id")) route = $"{method}{route}";

			return route;
		}

		/// <summary>
		///     Emits something on the Log event
		/// </summary>
		/// <param name="level">The LogLevel of this log</param>
		/// <param name="message">The message of this log</param>
		/// <param name="sender">Optional sender of this Message</param>
		public void CreateLog(LogLevel level, string message, string sender = null)
			=> Log?.Invoke(this, new LogEventArgs(level, sender ?? "RestClient", message));
	}
}
