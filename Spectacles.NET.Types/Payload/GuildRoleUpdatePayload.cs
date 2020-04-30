using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildRoleUpdate event.
	/// </summary>
	[DataContract]
	public class GuildRoleUpdatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     the role updated
		/// </summary>
		[DataMember(Name="role", Order=2)]
		public Role Role { get; set; }
	}
}
