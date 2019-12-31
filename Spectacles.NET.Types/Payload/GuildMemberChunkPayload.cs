using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildMemberChunk event.
	/// </summary>
	public class GuildMemberChunkPayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     set of guild members
		/// </summary>
		[JsonProperty("members")]
		public GuildMember[] GuildMembers { get; set; }
	}
}
