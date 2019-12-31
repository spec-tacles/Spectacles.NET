using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class ChannelMention
	{
		/// <summary>
		///     id of the channel
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     id of the guild containing the channel
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the type of channel
		/// </summary>
		[JsonProperty("type")]
		public ChannelType Type { get; set; }

		/// <summary>
		///     the name of the channel
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
