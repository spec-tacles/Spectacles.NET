using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a Client OAuth2 Application Team Member.
	/// </summary>
	public class TeamMember
	{
		/// <summary>
		/// The Membership State of this Team Member.
		/// </summary>
		[JsonProperty("membership_state")]
		public MembershipState MembershipState { get; set; }

		/// <summary>
		/// The permissions this Team Member has with regard to the team.
		/// </summary>
		[JsonProperty("permissions")]
		public string[] Permissions { get; set; }

		/// <summary>
		/// The Team id this member is part of
		/// </summary>
		[JsonProperty("team_id")]
		public string TeamId { get; set; }

		/// <summary>
		/// The user for this Team Member
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}
}
