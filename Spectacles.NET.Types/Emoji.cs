using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Emoji
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("roles")]
		public string[] Roles { get; set; }
		
		[JsonProperty("user")]
		public User User { get; set; }
		
		[JsonProperty("require_colons")]
		public bool? RequireColons { get; set; }
		
		[JsonProperty("managed")]
		public bool? Managed { get; set; }
		
		[JsonProperty("animated")]
		public bool? Animated { get; set; }
	}
}