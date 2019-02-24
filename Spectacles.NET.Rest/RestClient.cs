using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using Spectacles.NET.Rest.View;
using Spectacles.NET.Types;

namespace Spectacles.NET.Rest
{
	/// <summary>
	/// Client to interact with the Discord REST API.
	/// </summary>
	public class RestClient
	{
		/// <summary>
		/// The Guilds View.
		/// </summary>
		public GuildsView Guilds 
			=> new GuildsView(this);
		
		/// <summary>
		/// The Channels View.
		/// </summary>
		public ChannelsView Channels
			=> new ChannelsView(this);
		
		/// <summary>
		/// The Users View.
		/// </summary>
		public UsersView Users
			=> new UsersView(this);
		
		/// <summary>
		/// The Invites View.
		/// </summary>
		public InvitesView Invites
			=> new InvitesView(this);
		
		/// <summary>
		/// The Voice View.
		/// </summary>
		public VoiceView Voice
			=> new VoiceView(this);
		
		/// <summary>
		/// The Webhook View.
		/// </summary>
		public WebhooksView Webhooks
			=> new WebhooksView(this);

		/// <summary>
		/// If this Client is currently Global Ratelimited.
		/// </summary>
		public bool GlobalRatelimited { get; set; }

		/// <summary>
		/// Task Resolving when the Client isn't Global Ratelimited anymore.
		/// </summary>
		public Task GlobalTimeout { get; set; }
		
		/// <summary>
		/// The HttpClient of this RestClient.
		/// </summary>
		public readonly HttpClient HttpClient = new HttpClient();
		
		/// <summary>
		/// The Token of this RestClient.
		/// </summary>
		private string Token { get; }
		
		/// <summary>
		/// The Buckets of this RestClient mapped by Route.
		/// </summary>
		private readonly ConcurrentDictionary<string, Bucket.Bucket> _buckets = new ConcurrentDictionary<string, Bucket.Bucket>();

		/// <summary>
		/// Creates a new Instance of RestClient.
		/// </summary>
		/// <param name="token">The Token of the Bot.</param>
		public RestClient(string token)
		{
			Token = token;
			
			HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bot {Token}");
			HttpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
		}

		/// <summary>
		/// Enqueues a Request and Creates a Bucket if needed.
		/// </summary>
		/// <param name="method">The HTTP Method to use.</param>
		/// <param name="path">The Path to use.</param>
		/// <param name="content">The HttpContent to use.</param>
		/// <param name="reason">Optional AuditLog Reason.</param>
		/// <returns></returns>
		public Task<dynamic> DoRequest(RequestMethod method, string path, HttpContent content, string reason)
		{
			var absolutePath = $"{APIEndpoints.BaseURL}/{path}";
			var route = Bucket.Bucket.MakeRoute(method, path);
			if (_buckets.TryGetValue(route, out var bucket)) return bucket.Enqueue(method, absolutePath, content, reason);
			bucket = new Bucket.Bucket(this);
			_buckets.TryAdd(route, bucket);
			return bucket.Enqueue(method, absolutePath, content, reason);
		}
	}
}