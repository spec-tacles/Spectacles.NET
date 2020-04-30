using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Footer of an Embed
	/// </summary>
	[DataContract]
	public class EmbedFooter
	{
		/// <summary>
		///     footer text
		/// </summary>
		[DataMember(Name="text", Order=1)]
		public string Text { get; set; }

		/// <summary>
		///     url of footer icon (only supports http(s) and attachments)
		/// </summary>
		[DataMember(Name="icon_url", Order=2)]
		public string IconURL { get; set; }

		/// <summary>
		///     a proxied url of footer icon
		/// </summary>
		[DataMember(Name="proxy_icon_url", Order=3)]
		public string ProxyIconURL { get; set; }
	}
}
