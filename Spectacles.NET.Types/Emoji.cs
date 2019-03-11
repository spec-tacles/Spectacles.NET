using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// An Emoji Represents a custom or unicode emote <see cref="http://discordapp.com/developers/docs/resources/emoji"/>
	/// </summary>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Emoji
	{
		/// <summary>
		/// emoji id
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// emoji name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// roles this emoji is whitelisted to
		/// </summary>
		[JsonProperty("roles")]
		public List<string> Roles { get; set; }
		
		/// <summary>
		/// user that created this emoji
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
		
		/// <summary>
		/// whether this emoji must be wrapped in colons
		/// </summary>
		[JsonProperty("require_colons")]
		public bool? RequireColons { get; set; }
		
		/// <summary>
		/// whether this emoji is managed
		/// </summary>
		[JsonProperty("managed")]
		public bool? Managed { get; set; }
		
		/// <summary>
		/// whether this emoji is animated
		/// </summary>
		[JsonProperty("animated")]
		public bool? Animated { get; set; }
	}
}