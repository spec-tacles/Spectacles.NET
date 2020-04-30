using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildMemberRemove event.
	/// </summary>
	[DataContract]
	public class GuildMemberRemovePayload
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
	}
}
