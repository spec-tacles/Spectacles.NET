using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Allowed mentions of a Message
	/// </summary>
	public class AllowedMentions
	{
		/// <summary>
		/// An array of <see cref="AllowedMentionsType"/> to parse from the content.
		/// </summary>
		[JsonProperty("parse")]
		public AllowedMentionsType[] Parse { get; set; }
		
		/// <summary>
		/// Array of role_ids to mention (Max size of 100)
		/// </summary>
		[JsonProperty("roles")]
		public string[] Roles { get; set; }
		
		/// <summary>
		/// Array of user_ids to mention (Max size of 100)
		/// </summary>
		[JsonProperty("users")]
		public string[] Users { get; set; }
	}
}
