using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildBanRemove event.
	/// </summary>
	public class GuildBanRemovePayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the unbanned user
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}
}
