using System.Net.Http;
using Spectacles.NET.Rest.View;

namespace Spectacles.NET.Rest
{
	public class RestClient
	{
		public GuildsView Guilds 
			=> new GuildsView(this);
		public readonly HttpClient HttpClient = new HttpClient();
		private string Token { get; }

		public RestClient(string token)
		{
			Token = token;
			
			HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bot {Token}");
			HttpClient.DefaultRequestHeaders.Add("User-Agent", "DiscordBot (https://github.com/spec-tacles) v1");
		}
	}
}