using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildEmojisUpdate event.
	/// </summary>
	public class GuildEmojisUpdate
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     array of emojis
		/// </summary>
		[JsonProperty("emojis")]
		public Emoji[] Emojis { get; set; }
	}
}
