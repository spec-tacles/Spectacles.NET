using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the VoiceServerUpdate event.
	/// </summary>
	public class VoiceServerUpdatePayload
	{
		/// <summary>
		///     voice connection token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		///     the guild this voice server update is for
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the voice server host
		/// </summary>
		[JsonProperty("endpoint")]
		public string Endpoint { get; set; }
	}
}
