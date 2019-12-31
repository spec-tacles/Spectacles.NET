using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildMemberRemove event.
	/// </summary>
	public class GuildMemberRemovePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the user who was removed
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}
}
