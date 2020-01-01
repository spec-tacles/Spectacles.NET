using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents an embed in a message (image/video preview, rich embed, etc.)
	/// </summary>
	public class Embed
	{
		/// <summary>
		///     title of embed
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		///     type of embed (always "rich" for webhook embeds)
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		///     description of embed
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     url of embed
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		///     timestamp of embed content
		/// </summary>
		[JsonProperty("timestamp")]
		public DateTime? Timestamp { get; set; }

		/// <summary>
		///     color code of the embed
		/// </summary>
		[JsonProperty("color")]
		public int? Color { get; set; }

		/// <summary>
		///     footer information
		/// </summary>
		[JsonProperty("footer")]
		public EmbedFooter Footer { get; set; }

		/// <summary>
		///     image information
		/// </summary>
		[JsonProperty("image")]
		public EmbedImage Image { get; set; }

		/// <summary>
		///     thumbnail information
		/// </summary>
		[JsonProperty("thumbnail")]
		public EmbedThumbnail Thumbnail { get; set; }

		/// <summary>
		///     video information
		/// </summary>
		[JsonProperty("video")]
		public EmbedVideo Video { get; set; }

		/// <summary>
		///     provider information
		/// </summary>
		[JsonProperty("provider")]
		public EmbedProvider Provider { get; set; }

		/// <summary>
		///     author information
		/// </summary>
		[JsonProperty("author")]
		public EmbedAuthor Author { get; set; }

		/// <summary>
		///     fields information
		/// </summary>
		[JsonProperty("fields")]
		public List<EmbedField> Fields { get; set; }
	}
}
