using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a Client OAuth2 Application Team.
	/// </summary>
	public class Team
	{
		/// <summary>
		/// The Team's icon hash.
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		/// The ID of the Team.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// The Team's members.
		/// </summary>
		[JsonProperty("members")]
		public TeamMember[] Members { get; set; }

		/// <summary>
		/// The owner id of this team.
		/// </summary>
		[JsonProperty("owner_user_id")]
		public string OwnerUserId { get; set; }
	}
}
