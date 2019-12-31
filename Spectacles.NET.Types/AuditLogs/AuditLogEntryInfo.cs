using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class AuditLogEntryInfo
	{
		/// <summary>
		///     number of days after which inactive members were kicked
		/// </summary>
		[JsonProperty("delete_member_days")]
		public string DeletedMemberDays { get; set; }

		/// <summary>
		///     number of members removed by the prune
		/// </summary>
		[JsonProperty("members_removed")]
		public string MembersRemoved { get; set; }

		/// <summary>
		///     channel in which the messages were deleted
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// 	id of the message that was targeted
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		/// <summary>
		///     number of deleted messages
		/// </summary>
		[JsonProperty("count")]
		public string Count { get; set; }

		/// <summary>
		///     id of the overwritten entity
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     type of overwritten entity ("member" or "role")
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		///     name of the role if type is "role"
		/// </summary>
		[JsonProperty("role_name")]
		public string RoleName { get; set; }
	}
}
