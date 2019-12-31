using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the MessageDeleteBulk event.
	/// </summary>
	public class MessageDeleteBulkPayload
	{
		/// <summary>
		///     the ids of the messages
		/// </summary>
		[JsonProperty("ids")]
		public string[] Ids { get; set; }

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
