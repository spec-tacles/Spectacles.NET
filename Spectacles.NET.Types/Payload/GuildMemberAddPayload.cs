using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildMemberAdd event.
	/// </summary>
	/// <inheritdoc />
	[DataContract]
	public class GuildMemberAddPayload : GuildMember
	{
		/// <summary>
		///     Id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }
	}
}
