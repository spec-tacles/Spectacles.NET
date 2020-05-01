using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a Client OAuth2 Application Team Member.
	/// </summary>
	[DataContract]
	public class TeamMember
	{
		/// <summary>
		/// The Membership State of this Team Member.
		/// </summary>
		[DataMember(Name="membership_state", Order=1)]
		public MembershipState MembershipState { get; set; }

		/// <summary>
		/// The permissions this Team Member has with regard to the team.
		/// </summary>
		[DataMember(Name="permissions", Order=2)]
		public string[] Permissions { get; set; }

		/// <summary>
		/// The Team id this member is part of
		/// </summary>
		[DataMember(Name="team_id", Order=3)]
		public string TeamId { get; set; }

		/// <summary>
		/// The user for this Team Member
		/// </summary>
		[DataMember(Name="user", Order=4)]
		public User User { get; set; }
	}
}
