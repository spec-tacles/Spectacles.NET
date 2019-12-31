using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class EmbedAuthor
	{
		/// <summary>
		///     name of author
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     url of author
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		///     url of author icon (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("icon_url")]
		public string IconURL { get; set; }

		/// <summary>
		///     a proxied url of author icon
		/// </summary>
		[JsonProperty("proxy_icon_url")]
		public string ProxyIconURL { get; set; }
	}
}
