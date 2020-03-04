using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Allowed Mention Types
	/// </summary>
	public enum AllowedMentionsType
	{
		/// <summary>
		/// Controls role mentions
		/// </summary>
		[EnumMember(Value = "roles")]
		ROLES,
		
		/// <summary>
		/// Controls user mentions
		/// </summary>
		[EnumMember(Value = "users")]
		USERS,
		
		/// <summary>
		/// Controls @everyone and @here mentions
		/// </summary>
		[EnumMember(Value = "everyone")]
		EVERYONE
	}
}
