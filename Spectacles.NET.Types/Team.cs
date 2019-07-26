using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public enum MembershipState
	{
		INVITED = 1,
		ACCEPTED
	}
	
	public class TeamMember
	{
		[JsonProperty("membership_state")]
		public MembershipState MembershipState { get; set; }
		
		[JsonProperty("permissions")]
		public string[] Permissions { get; set; }
		
		[JsonProperty("team_id")]
		public string TeamID { get; set; }
		
		[JsonProperty("user")]
		public User User { get; set; }
	}
	
	public class Team
	{
		[JsonProperty("icon")]
		public string Icon { get; set; }
		
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("members")]
		public TeamMember[] Members { get; set; }
		
		[JsonProperty("owner_user_id")]
		public string OwnerUserID { get; set; }
	}
}