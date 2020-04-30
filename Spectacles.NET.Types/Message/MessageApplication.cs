using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a Client OAuth2 Application.
	/// </summary>
	[DataContract]
	public class MessageApplication
	{
		/// <summary>
		///     id of the application
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		// ReSharper disable once CommentTypo
		/// <summary>
		///     id of the embed's image asset
		/// </summary>
		[DataMember(Name="cover_image", Order=2)]
		public string CoverImage { get; set; }

		/// <summary>
		///     application's description
		/// </summary>
		[DataMember(Name="description", Order=3)]
		public string Description { get; set; }

		/// <summary>
		///     id of the application's icon
		/// </summary>
		[DataMember(Name="icon", Order=4)]
		public string Icon { get; set; }

		/// <summary>
		///     name of the application
		/// </summary>
		[DataMember(Name="name", Order=5)]
		public string Name { get; set; }
	}
}
