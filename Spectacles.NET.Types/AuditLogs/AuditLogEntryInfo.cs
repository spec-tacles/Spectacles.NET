using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Additional Audit Log info for certain action types
	/// </summary>
	[DataContract]
	public class AuditLogEntryInfo
	{
		/// <summary>
		///     number of days after which inactive members were kicked
		/// </summary>
		[DataMember(Name = "delete_member_days", Order = 1)]
		public string DeletedMemberDays { get; set; }

		/// <summary>
		///     number of members removed by the prune
		/// </summary>
		[DataMember(Name = "members_removed", Order = 2)]
		public string MembersRemoved { get; set; }

		/// <summary>
		///     channel in which the messages were deleted
		/// </summary>
		[DataMember(Name = "channel_id", Order = 3)]
		public string ChannelId { get; set; }

		/// <summary>
		/// 	id of the message that was targeted
		/// </summary>
		[DataMember(Name = "message_id", Order = 4)]
		public string MessageId { get; set; }

		/// <summary>
		///     number of deleted messages
		/// </summary>
		[DataMember(Name = "count", Order = 5)]
		public string Count { get; set; }

		/// <summary>
		///     id of the overwritten entity
		/// </summary>
		[DataMember(Name = "id", Order = 6)]
		public string Id { get; set; }

		/// <summary>
		///     type of overwritten entity ("member" or "role")
		/// </summary>
		[DataMember(Name = "type", Order = 7)]
		public string Type { get; set; }

		/// <summary>
		///     name of the role if type is "role"
		/// </summary>
		[DataMember(Name = "role_name", Order = 8)]
		public string RoleName { get; set; }
	}
}
