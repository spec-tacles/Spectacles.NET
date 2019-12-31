using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildRoleDelete event.
	/// </summary>
	public class GuildRoleDeletePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the deleted role id
		/// </summary>
		[JsonProperty("role_id")]
		public string RoleId { get; set; }
	}
}
