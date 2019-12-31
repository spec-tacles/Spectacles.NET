using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildBanAdd event.
	/// </summary>
	public class GuildBanAddPayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the banned user
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}
}
