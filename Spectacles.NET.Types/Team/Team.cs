using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a Client OAuth2 Application Team.
	/// </summary>
	[DataContract]
	public class Team
	{
		/// <summary>
		/// The Team's icon hash.
		/// </summary>
		[DataMember(Name = "icon", Order = 1)]
		public string Icon { get; set; }

		/// <summary>
		/// The ID of the Team.
		/// </summary>
		[DataMember(Name = "id", Order = 2)]
		public string Id { get; set; }

		/// <summary>
		/// The Team's members.
		/// </summary>
		[DataMember(Name = "members", Order = 3)]
		public TeamMember[] Members { get; set; }

		/// <summary>
		/// The owner id of this team.
		/// </summary>
		[DataMember(Name = "owner_user_id", Order = 4)]
		public string OwnerUserId { get; set; }
	}
}
