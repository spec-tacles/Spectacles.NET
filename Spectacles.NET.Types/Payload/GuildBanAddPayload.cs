using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildBanAdd event.
	/// </summary>
	[DataContract]
	public class GuildBanAddPayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     the banned user
		/// </summary>
		[DataMember(Name="user", Order=2)]
		public User User { get; set; }
	}
}
