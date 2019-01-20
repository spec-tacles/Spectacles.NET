using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Presence
	{
		[JsonProperty("user")]
		public User User { get; set; }
		
		[JsonProperty("roles")]
		public string[] Roles { get; set; }
		
		[JsonProperty("game")]
		public Activity Game { get; set; }
		
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }
		
		[JsonProperty("status")]
		public string Status { get; set; }
		
		[JsonProperty("activities")]
		public Activity[] Activities { get; set; }
	}
}