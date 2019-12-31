using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the MessageDelete event.
	/// </summary>
	public class MessageDeletePayload
	{
		/// <summary>
		///     the id of the message
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

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
	}
}
