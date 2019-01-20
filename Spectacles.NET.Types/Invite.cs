using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Invite
	{
		[JsonProperty("code")]
		public string Code { get; set; }
		
		[JsonProperty("Guild")]
		public Guild Guild { get; set; }
		
		[JsonProperty("channel")]
		public Channel Channel { get; set; }
		
		[JsonProperty("approximate_presence_count")]
		public int ApproximatePresenceCount { get; set; }
		
		[JsonProperty("approximate_member_count")]
		public int ApproximateMemberCount { get; set; }
	}
}