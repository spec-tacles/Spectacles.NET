using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class EmbedImage
	{
		/// <summary>
		///     source url of image (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		///     a proxied url of the image
		/// </summary>
		[JsonProperty("proxy_url")]
		public string ProxyURL { get; set; }

		/// <summary>
		///     height of image
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }

		/// <summary>
		///     width of image
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }
	}
}
