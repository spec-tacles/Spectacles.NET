using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the GuildMemberChunk event.
	/// </summary>
	[DataContract]
	public class GuildMemberChunkPayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     set of guild members
		/// </summary>
		[DataMember(Name="members", Order=2)]
		public GuildMember[] GuildMembers { get; set; }
	}
}
