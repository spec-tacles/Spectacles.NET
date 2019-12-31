using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class EmbedFooter
	{
		/// <summary>
		///     footer text
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		///     url of footer icon (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("icon_url")]
		public string IconURL { get; set; }

		/// <summary>
		///     a proxied url of footer icon
		/// </summary>
		[JsonProperty("proxy_icon_url")]
		public string ProxyIconURL { get; set; }
	}
}
