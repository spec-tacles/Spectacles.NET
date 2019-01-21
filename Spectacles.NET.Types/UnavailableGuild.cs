using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class UnavailableGuild
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("unavailable")]
		public bool Unavailable { get; set; }
	}
}