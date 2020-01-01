using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Provider of an Embed
	/// </summary>
	public class EmbedProvider
	{
		/// <summary>
		///     name of provider
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     url of provider
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
	}
}
