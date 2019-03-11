using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Embed
	{
		/// <summary>
		/// title of embed
		/// </summary>
		[JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
		public string Title { get; set; }
		
		/// <summary>
		/// type of embed (always "rich" for webhook embeds)
		/// </summary>
		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }
		
		/// <summary>
		/// description of embed
		/// </summary>
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }
		
		/// <summary>
		/// url of embed
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
		
		/// <summary>
		/// timestamp of embed content
		/// </summary>
		[JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime Timestamp { get; set; }
		
		/// <summary>
		/// color code of the embed
		/// </summary>
		[JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
		public int? Color { get; set; }
		
		/// <summary>
		/// footer information
		/// </summary>
		[JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
		public EmbedFooter Footer { get; set; }
		
		/// <summary>
		/// image information
		/// </summary>
		[JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
		public EmbedImage Image { get; set; }
		
		/// <summary>
		/// thumbnail information
		/// </summary>
		[JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
		public EmbedThumbnail Thumbnail { get; set; }
		
		/// <summary>
		/// video information
		/// </summary>
		[JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
		public EmbedVideo Video { get; set; }
		
		/// <summary>
		/// provider information
		/// </summary>
		[JsonProperty("provider", NullValueHandling = NullValueHandling.Ignore)]
		public EmbedProvider Provider { get; set; }
		
		/// <summary>
		/// author information
		/// </summary>
		[JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
		public EmbedAuthor Author { get; set; }
		
		/// <summary>
		/// fields information
		/// </summary>
		[JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
		public List<EmbedField> Fields { get; set; }
	}

	public class EmbedThumbnail
	{
		/// <summary>
		/// source url of thumbnail (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
		
		/// <summary>
		/// a proxied url of the thumbnail
		/// </summary>
		[JsonProperty("proxy_url", NullValueHandling = NullValueHandling.Ignore)]
		public string ProxyURL { get; set; }
		
		/// <summary>
		/// height of thumbnail
		/// </summary>
		[JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
		public int? Height { get; set; }
		
		/// <summary>
		/// width of thumbnail
		/// </summary>
		[JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
		public int? Width { get; set; }
	}

	public class EmbedVideo
	{
		/// <summary>
		/// source url of video
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
		
		/// <summary>
		/// height of video
		/// </summary>
		[JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
		public int? Height { get; set; }
		
		/// <summary>
		/// width of video
		/// </summary>
		[JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
		public int? Width { get; set; }
	}

	public class EmbedImage
	{
		/// <summary>
		/// source url of image (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
		
		/// <summary>
		/// a proxied url of the image
		/// </summary>
		[JsonProperty("proxy_url", NullValueHandling = NullValueHandling.Ignore)]
		public string ProxyURL { get; set; }
		
		/// <summary>
		/// height of image
		/// </summary>
		[JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
		public int? Height { get; set; }
		
		/// <summary>
		/// width of image
		/// </summary>
		[JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
		public int? Width { get; set; }
	}

	public class EmbedProvider
	{
		/// <summary>
		/// name of provider
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		/// <summary>
		/// url of provider
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
	}

	public class EmbedAuthor
	{
		/// <summary>
		/// name of author
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		/// <summary>
		/// url of author
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string URL { get; set; }
		
		/// <summary>
		/// url of author icon (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
		public string IconURL { get; set; }
		
		/// <summary>
		/// a proxied url of author icon
		/// </summary>
		[JsonProperty("proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
		public string ProxyIconURL { get; set; }
	}

	public class EmbedFooter
	{
		/// <summary>
		/// footer text
		/// </summary>
		[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
		public string Text { get; set; }
		
		/// <summary>
		/// url of footer icon (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
		public string IconURL { get; set; }
		
		/// <summary>
		/// a proxied url of footer icon
		/// </summary>
		[JsonProperty("proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
		public string ProxyIconURL { get; set; }
	}

	public class EmbedField
	{
		/// <summary>
		/// name of the field
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		/// <summary>
		/// value of the field
		/// </summary>
		[JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
		public string Value { get; set; }
		
		/// <summary>
		/// whether or not this field should display inline
		/// </summary>
		[JsonProperty("inline", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Inline { get; set; }
	}
}