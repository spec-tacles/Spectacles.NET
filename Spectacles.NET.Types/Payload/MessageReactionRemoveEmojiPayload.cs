using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Sent when a bot removes all instances of a given emoji from the reactions of a message.
	/// </summary>
	public class MessageReactionRemoveEmojiPayload
	{
		/// <summary>
		/// the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
		
		/// <summary>
		/// 	the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// the id of the message
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }
		
		/// <summary>
		/// the emoji that was removed
		/// </summary>
		[JsonProperty("emoji")]
		public Emoji Emoji { get; set; }
	}
}
