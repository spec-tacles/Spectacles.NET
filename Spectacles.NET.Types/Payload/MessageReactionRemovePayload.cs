using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the MessageReactionRemove events.
	/// </summary>
	public class MessageReactionRemovePayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		/// <summary>
		///     the ids of the message
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the emoji used to react
		/// </summary>
		[JsonProperty("emoji")]
		public Emoji Emoji { get; set; }
	}
}
