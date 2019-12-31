using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class EmbedThumbnail
	{
		/// <summary>
		///     source url of thumbnail (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		///     a proxied url of the thumbnail
		/// </summary>
		[JsonProperty("proxy_url")]
		public string ProxyURL { get; set; }

		/// <summary>
		///     height of thumbnail
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }

		/// <summary>
		///     width of thumbnail
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }
	}
}
