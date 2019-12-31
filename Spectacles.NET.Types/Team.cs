using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Team
	{
		[JsonProperty("icon")]
		public string Icon { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("members")]
		public TeamMember[] Members { get; set; }

		[JsonProperty("owner_user_id")]
		public string OwnerUserId { get; set; }
	}
}
