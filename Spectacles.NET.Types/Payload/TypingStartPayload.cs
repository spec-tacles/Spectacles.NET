using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the TypingStart event.
	/// </summary>
	public class TypingStartPayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

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
		///     unix time (in seconds) of when the user started typing
		/// </summary>
		[JsonProperty("timestamp")]
		public long Timestamp { get; set; }
	}
}
