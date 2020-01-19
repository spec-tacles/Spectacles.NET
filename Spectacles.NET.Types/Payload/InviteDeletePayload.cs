using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Sent when an invite is deleted.
	/// </summary>
	public class InviteDeletePayload
	{
		/// <summary>
		/// the channel of the invite
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
		
		/// <summary>
		/// the guild of the invite
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// the unique invite code
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }
	}
}
