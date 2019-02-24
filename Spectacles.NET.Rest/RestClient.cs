using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Spectacles.NET.Rest.View;
using Spectacles.NET.Types;

namespace Spectacles.NET.Rest
{
	public class RestClient
	{
		public GuildsView Guilds 
			=> new GuildsView(this);
		
		public ChannelsView Channels
			=> new ChannelsView(this);
		
		public UsersView Users
			=> new UsersView(this);
		
		public InvitesView Invites
			=> new InvitesView(this);
		
		public VoiceView Voice
			=> new VoiceView(this);

		public bool GlobalRatelimited { get; set; }

		public Task GlobalTimeout { get; set; }
		
		public readonly HttpClient HttpClient = new HttpClient();
		private string Token { get; }
		
		private readonly ConcurrentDictionary<string, Bucket.Bucket> _buckets = new ConcurrentDictionary<string, Bucket.Bucket>();

		public RestClient(string token)
		{
			Token = token;
			
			HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bot {Token}");
			HttpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
		}

		public Task<dynamic> DoRequest(RequestMethod method, string path, HttpContent content)
		{
			var absolutePath = $"{APIEndpoints.BaseURL}/{path}";
			var route = Bucket.Bucket.MakeRoute(method, path);
			if (_buckets.TryGetValue(route, out var bucket)) return bucket.Enqueue(method, absolutePath, content);
			bucket = new Bucket.Bucket(this);
			_buckets.TryAdd(route, bucket);
			return bucket.Enqueue(method, absolutePath, content);
		}
	}
}