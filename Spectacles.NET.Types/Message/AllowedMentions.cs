using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Allowed mentions of a Message
	/// </summary>
	[DataContract]
	public class AllowedMentions
	{
		/// <summary>
		/// An array of <see cref="AllowedMentionsType"/> to parse from the content.
		/// </summary>
		[DataMember(Name="parse", Order=1)]
		public AllowedMentionsType[] Parse { get; set; }
		
		/// <summary>
		/// Array of role_ids to mention (Max size of 100)
		/// </summary>
		[DataMember(Name="roles", Order=2)]
		public string[] Roles { get; set; }
		
		/// <summary>
		/// Array of user_ids to mention (Max size of 100)
		/// </summary>
		[DataMember(Name="users", Order=3)]
		public string[] Users { get; set; }
	}
}
