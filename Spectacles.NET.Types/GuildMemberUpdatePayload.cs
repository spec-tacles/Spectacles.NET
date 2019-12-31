using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildMemberUpdate event.
	/// </summary>
	public class GuildMemberUpdatePayload
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

		/// <summary>
		///     user role ids
		/// </summary>
		[JsonProperty("roles")]
		public string[] Roles { get; set; }

		/// <summary>
		///     nickname of the user in the guild
		/// </summary>
		[JsonProperty("nick")]
		public string Nickname { get; set; }
	}
}
