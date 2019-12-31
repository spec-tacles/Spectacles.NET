using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
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
