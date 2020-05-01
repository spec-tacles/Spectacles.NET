using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Author of an Embed
	/// </summary>
	[DataContract]
	public class EmbedAuthor
	{
		/// <summary>
		///     name of author
		/// </summary>
		[DataMember(Name="name", Order=1)]
		public string Name { get; set; }

		/// <summary>
		///     url of author
		/// </summary>
		[DataMember(Name="url", Order=2)]
		public string URL { get; set; }

		/// <summary>
		///     url of author icon (only supports http(s) and attachments)
		/// </summary>
		[DataMember(Name="icon_url", Order=3)]
		public string IconURL { get; set; }

		/// <summary>
		///     a proxied url of author icon
		/// </summary>
		[DataMember(Name="proxy_icon_url", Order=4)]
		public string ProxyIconURL { get; set; }
	}
}
