using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Used to request offline members for a guild or a list of guilds. When initially connecting, the gateway will only
	///     send offline members if a guild has less than the large_threshold members (value in the Gateway Identify). If a
	///     client wishes to receive additional members, they need to explicitly request them via this operation. The server
	///     will send Guild Members Chunk events in response with up to 1000 members per chunk until all members that match the
	///     request have been sent.
	/// </summary>
	[DataContract]
	public class RequestGuildMembersDispatch
	{
		/// <summary>
		///     id of the guild(s) to get offline members for
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public object GuildId { get; set; }

		/// <summary>
		///     string that username starts with, or an empty string to return all members
		/// </summary>
		[DataMember(Name="query", Order=2)]
		public string Query { get; set; }

		/// <summary>
		///     maximum number of members to send or 0 to request all members matched
		/// </summary>
		[DataMember(Name="limit", Order=3)]
		public int Limit { get; set; }
	}
}
