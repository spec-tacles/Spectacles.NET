using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Webhooks are a low-effort way to post messages to channels in Discord. They do not require a bot user or authentication to use.
	/// </summary>
	public class Webhook
	{
		/// <summary>
		/// the id of the webhook
		/// </summary>
		[JsonProperty("id")]
		public long ID { get; set; }
		
		/// <summary>
		/// the guild id this webhook is for
		/// </summary>
		[JsonProperty("guild_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? GuildID { get; set; }
		
		/// <summary>
		/// the channel id this webhook is for
		/// </summary>
		[JsonProperty("channel_id")]
		public long ChannelID { get; set; }
		
		/// <summary>
		/// the user this webhook was created by (not returned when getting a webhook with its token)
		/// </summary>
		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public User User { get; set; }
		
		/// <summary>
		/// the default name of the webhook
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		/// <summary>
		/// the default avatar of the webhook
		/// </summary>
		[JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
		public string Avatar { get; set; }
		
		/// <summary>
		/// the secure token of the webhook
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }
	}
}