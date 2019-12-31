using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class TeamMember
	{
		[JsonProperty("membership_state")]
		public MembershipState MembershipState { get; set; }

		[JsonProperty("permissions")]
		public string[] Permissions { get; set; }

		[JsonProperty("team_id")]
		public string TeamId { get; set; }

		[JsonProperty("user")]
		public User User { get; set; }
	}
}
