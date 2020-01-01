using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a Client OAuth2 Application.
	/// </summary>
	public class MessageApplication
	{
		/// <summary>
		///     id of the application
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		// ReSharper disable once CommentTypo
		/// <summary>
		///     id of the embed's image asset
		/// </summary>
		[JsonProperty("cover_image")]
		public string CoverImage { get; set; }

		/// <summary>
		///     application's description
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     id of the application's icon
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		///     name of the application
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
