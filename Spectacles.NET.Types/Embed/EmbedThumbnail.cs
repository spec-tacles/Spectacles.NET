using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Thumbnail of an Embed
	/// </summary>
	[DataContract]
	public class EmbedThumbnail
	{
		/// <summary>
		///     source url of thumbnail (only supports http(s) and attachments)
		/// </summary>
		[DataMember(Name = "url", Order = 1)]
		public string URL { get; set; }

		/// <summary>
		///     a proxied url of the thumbnail
		/// </summary>
		[DataMember(Name = "proxy_url", Order = 2)]
		public string ProxyURL { get; set; }

		/// <summary>
		///     height of thumbnail
		/// </summary>
		[DataMember(Name = "height", Order = 3)]
		public int? Height { get; set; }

		/// <summary>
		///     width of thumbnail
		/// </summary>
		[DataMember(Name = "width", Order = 4)]
		public int? Width { get; set; }
	}
}