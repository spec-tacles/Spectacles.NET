using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class PermissionOverwrite
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("allow")]
		public int Allow { get; set; }
		
		[JsonProperty("deny")]
		public int Deny { get; set; }
	}
}