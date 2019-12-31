using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Used to request offline members for a guild or a list of guilds. When initially connecting, the gateway will only
	///     send offline members if a guild has less than the large_threshold members (value in the Gateway Identify). If a
	///     client wishes to receive additional members, they need to explicitly request them via this operation. The server
	///     will send Guild Members Chunk events in response with up to 1000 members per chunk until all members that match the
	///     request have been sent.
	/// </summary>
	public class RequestGuildMembersDispatch
	{
		/// <summary>
		///     id of the guild(s) to get offline members for
		/// </summary>
		[JsonProperty("guild_id")]
		public object GuildId { get; set; }

		/// <summary>
		///     string that username starts with, or an empty string to return all members
		/// </summary>
		[JsonProperty("query")]
		public string Query { get; set; }

		/// <summary>
		///     maximum number of members to send or 0 to request all members matched
		/// </summary>
		[JsonProperty("limit")]
		public int Limit { get; set; }
	}
}
