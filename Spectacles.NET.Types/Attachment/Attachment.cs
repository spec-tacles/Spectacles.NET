using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents an attachment in a message.
	/// </summary>
	[DataContract]
	public class Attachment
	{
		/// <summary>
		///     attachment id
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     name of file attached
		/// </summary>
		[DataMember(Name="filename", Order=2)]
		public string FileName { get; set; }

		/// <summary>
		///     size of file in bytes
		/// </summary>
		[DataMember(Name="size", Order=3)]
		public int Size { get; set; }

		/// <summary>
		///     source url of file
		/// </summary>
		[DataMember(Name="url", Order=4)]
		public string URL { get; set; }

		/// <summary>
		///     a proxied url of file
		/// </summary>
		[DataMember(Name="proxy_url", Order=5)]
		public string ProxyURL { get; set; }

		/// <summary>
		///     height of file (if image)
		/// </summary>
		[DataMember(Name="height", Order=6)]
		public int? Height { get; set; }

		/// <summary>
		///     width of file (if image)
		/// </summary>
		[DataMember(Name="width", Order=7)]
		public int? Width { get; set; }
	}
}
