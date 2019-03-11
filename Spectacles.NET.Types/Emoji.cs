using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// An Emoji Represents a custom or unicode emote <see cref="http://discordapp.com/developers/docs/resources/emoji"/>
	/// </summary>
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
		[JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Roles { get; set; }
		
		/// <summary>
		/// user that created this emoji
		/// </summary>
		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public User User { get; set; }
		
		/// <summary>
		/// whether this emoji must be wrapped in colons
		/// </summary>
		[JsonProperty("require_colons", NullValueHandling = NullValueHandling.Ignore)]
		public bool? RequireColons { get; set; }
		
		/// <summary>
		/// whether this emoji is managed
		/// </summary>
		[JsonProperty("managed", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Managed { get; set; }
		
		/// <summary>
		/// whether this emoji is animated
		/// </summary>
		[JsonProperty("animated", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Animated { get; set; }
	}
}