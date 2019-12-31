using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildRoleCreate event.
	/// </summary>
	public class GuildRoleCreatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the role created
		/// </summary>
		[JsonProperty("role")]
		public Role Role { get; set; }
	}
}
