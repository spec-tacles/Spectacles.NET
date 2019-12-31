using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildRoleUpdate event.
	/// </summary>
	public class GuildRoleUpdatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the role updated
		/// </summary>
		[JsonProperty("role")]
		public Role Role { get; set; }
	}
}
