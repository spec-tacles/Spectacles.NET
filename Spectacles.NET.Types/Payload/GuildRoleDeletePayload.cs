using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildRoleDelete event.
	/// </summary>
	[DataContract]
	public class GuildRoleDeletePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     the deleted role id
		/// </summary>
		[DataMember(Name="role_id", Order=2)]
		public string RoleId { get; set; }
	}
}
