// ReSharper disable UnusedMember.Global

using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Sent when a client wants to join, move, or disconnect from a voice channel.
	/// </summary>
	public class UpdateVoiceStateDispatch
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     id of the voice channel client wants to join (null if disconnecting)
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     is the client muted
		/// </summary>
		[JsonProperty("self_mute")]
		public bool SelfMute { get; set; }

		/// <summary>
		///     is the client deafened
		/// </summary>
		[JsonProperty("self_deaf")]
		public bool SelfDeaf { get; set; }
	}
}
