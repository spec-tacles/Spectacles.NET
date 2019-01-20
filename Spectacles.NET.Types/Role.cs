using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Role
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("color")]
		public int Color { get; set; }
		
		[JsonProperty("hoist")]
		public bool Hoist { get; set; }
		
		[JsonProperty("position")]
		public int Position { get; set; }
		
		[JsonProperty("permissions")]
		public int Permissions { get; set; }
		
		[JsonProperty("managed")]
		public bool Managed { get; set; }
		
		[JsonProperty("mentionable")]
		public bool Mentionable { get; set; }
	}
}