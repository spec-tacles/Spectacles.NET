using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildMemberUpdate event.
	/// </summary>
	[DataContract]
	public class GuildMemberUpdatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     the user who was removed
		/// </summary>
		[DataMember(Name="user", Order=2)]
		public User User { get; set; }

		/// <summary>
		///     user role ids
		/// </summary>
		[DataMember(Name="roles", Order=3)]
		public string[] Roles { get; set; }

		/// <summary>
		///     nickname of the user in the guild
		/// </summary>
		[DataMember(Name="nick", Order=4)]
		public string Nickname { get; set; }
	}
}
