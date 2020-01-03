using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Reference data sent with crossposted messages.
	/// </summary>
	public class MessageReference
	{
		/// <summary>
		///     Id of the reference.
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		/// <summary>
		///     	Id of the originating message's channel.
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     Id of the originating message's guild.
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}
}
