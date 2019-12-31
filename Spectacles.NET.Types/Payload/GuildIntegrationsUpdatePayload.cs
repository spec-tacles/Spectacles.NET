using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildIntegrationsUpdate event.
	/// </summary>
	public class GuildIntegrationsUpdatePayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}
}
