using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class ActivityEmoji
	{
		/// <summary>
		///     emoji id
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     emoji name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		///     whether this emoji is animated
		/// </summary>
		[JsonProperty("animated")]
		public bool? Animated { get; set; }
	}
}
