using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildMemberAdd event.
	/// </summary>
	/// <inheritdoc />
	public class GuildMemberAddPayload : GuildMember
	{
		/// <summary>
		///     Id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}
}
