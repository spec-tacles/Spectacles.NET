using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Embed
	{
		/// <summary>
		/// title of embed
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }
		
		/// <summary>
		/// type of embed (always "rich" for webhook embeds)
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }
		
		/// <summary>
		/// description of embed
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
		
		/// <summary>
		/// url of embed
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
		
		/// <summary>
		/// timestamp of embed content
		/// </summary>
		[JsonProperty("timestamp")]
		public DateTime? Timestamp { get; set; }
		
		/// <summary>
		/// color code of the embed
		/// </summary>
		[JsonProperty("color")]
		public int? Color { get; set; }
		
		/// <summary>
		/// footer information
		/// </summary>
		[JsonProperty("footer")]
		public EmbedFooter Footer { get; set; }
		
		/// <summary>
		/// image information
		/// </summary>
		[JsonProperty("image")]
		public EmbedImage Image { get; set; }
		
		/// <summary>
		/// thumbnail information
		/// </summary>
		[JsonProperty("thumbnail")]
		public EmbedThumbnail Thumbnail { get; set; }
		
		/// <summary>
		/// video information
		/// </summary>
		[JsonProperty("video")]
		public EmbedVideo Video { get; set; }
		
		/// <summary>
		/// provider information
		/// </summary>
		[JsonProperty("provider")]
		public EmbedProvider Provider { get; set; }
		
		/// <summary>
		/// author information
		/// </summary>
		[JsonProperty("author")]
		public EmbedAuthor Author { get; set; }
		
		/// <summary>
		/// fields information
		/// </summary>
		[JsonProperty("fields")]
		public List<EmbedField> Fields { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedThumbnail
	{
		/// <summary>
		/// source url of thumbnail (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
		
		/// <summary>
		/// a proxied url of the thumbnail
		/// </summary>
		[JsonProperty("proxy_url")]
		public string ProxyURL { get; set; }
		
		/// <summary>
		/// height of thumbnail
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }
		
		/// <summary>
		/// width of thumbnail
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedVideo
	{
		/// <summary>
		/// source url of video
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
		
		/// <summary>
		/// height of video
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }
		
		/// <summary>
		/// width of video
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedImage
	{
		/// <summary>
		/// source url of image (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
		
		/// <summary>
		/// a proxied url of the image
		/// </summary>
		[JsonProperty("proxy_url")]
		public string ProxyURL { get; set; }
		
		/// <summary>
		/// height of image
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }
		
		/// <summary>
		/// width of image
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedProvider
	{
		/// <summary>
		/// name of provider
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// url of provider
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedAuthor
	{
		/// <summary>
		/// name of author
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// url of author
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
		
		/// <summary>
		/// url of author icon (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("icon_url")]
		public string IconURL { get; set; }
		
		/// <summary>
		/// a proxied url of author icon
		/// </summary>
		[JsonProperty("proxy_icon_url")]
		public string ProxyIconURL { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedFooter
	{
		/// <summary>
		/// footer text
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }
		
		/// <summary>
		/// url of footer icon (only supports http(s) and attachments)
		/// </summary>
		[JsonProperty("icon_url")]
		public string IconURL { get; set; }
		
		/// <summary>
		/// a proxied url of footer icon
		/// </summary>
		[JsonProperty("proxy_icon_url")]
		public string ProxyIconURL { get; set; }
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class EmbedField
	{
		/// <summary>
		/// name of the field
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// value of the field
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
		
		/// <summary>
		/// whether or not this field should display inline
		/// </summary>
		[JsonProperty("inline")]
		public bool? Inline { get; set; }
	}
}