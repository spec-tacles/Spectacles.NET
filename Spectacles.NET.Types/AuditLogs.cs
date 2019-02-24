using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public enum AuditLogEvent
	{
		GUILD_UPDATE = 1,
		CHANNEL_CREATE = 10,
		CHANNEL_UPDATE,
		CHANNEL_DELETE,
		CHANNEL_OVERWRITE_CREATE,
		CHANNEL_OVERWRITE_UPDATE,
		CHANNEL_OVERWRITE_DELETE,
		MEMBER_KICK = 20,
		MEMBER_PRUNE,
		MEMBER_BAN_ADD,
		MEMBER_BAN_REMOVE,
		MEMBER_UPDATE,
		MEMBER_ROLE_UPDATE,
		ROLE_CREATE = 30,
		ROLE_UPDATE,
		ROLE_DELETE,
		INVITE_CREATE = 40,
		INVITE_UPDATE,
		INVITE_DELETE,
		WEBHOOK_CREATE = 50,
		WEBHOOK_UPDATE,
		WEBHOOK_DELETE,
		EMOJI_CREATE = 60,
		EMOJI_UPDATE,
		EMOJI_DELETE,
		MESSAGE_DELETE = 72
	}
	
	/// <summary>
	/// Whenever an admin action is performed on the API, an entry is added to the respective guild's audit log. You can specify the reason by attaching the X-Audit-Log-Reason request header. This header supports url encoded utf8 characters.
	/// </summary>
	public class AuditLogs
	{
		/// <summary>
		/// list of webhooks found in the audit log
		/// </summary>
		[JsonProperty("webhooks")]
		public Webhook[] Webhooks { get; set; }
		
		/// <summary>
		/// list of users found in the audit log
		/// </summary>
		[JsonProperty("users")]
		public User[] Users { get; set; }
		
		/// <summary>
		/// list of audit log entries
		/// </summary>
		[JsonProperty("audit_log_entries")]
		public AuditLogEntry[] AuditLogEntries { get; set; }
	}

	/// <summary>
	/// An Audit Log Entry 
	/// </summary>
	public class AuditLogEntry
	{
		/// <summary>
		/// id of the affected entity (webhook, user, role, etc.)
		/// </summary>
		[JsonProperty("target_id")]
		public string TargetID { get; set; }
		
		/// <summary>
		/// changes made to the target_id
		/// </summary>
		[JsonProperty("changes")]
		public AuditLogChange[] Changes { get; set; }
		
		/// <summary>
		/// the user who made the changes
		/// </summary>
		[JsonProperty("user_id")]
		public string UserID { get; set; }
		
		/// <summary>
		/// id of the entry
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// type of action that occured
		/// </summary>
		[JsonProperty("action_type")]
		public AuditLogEvent ActionType { get; set; }
		
		/// <summary>
		/// additional info for certain action types
		/// </summary>
		[JsonProperty("options")]
		public AuditLogEntryInfo Options { get; set; }
		
		/// <summary>
		/// the reason for the change (0-512 characters)
		/// </summary>
		[JsonProperty("reason")]
		public string Reason { get; set; }
	}

	public class AuditLogChange
	{
		/// <summary>
		/// new value of the key
		/// </summary>
		[JsonProperty("new_value")]
		public dynamic NewValue { get; set; }
		
		/// <summary>
		/// old value of the key
		/// </summary>
		[JsonProperty("old_value")]
		public dynamic OldValue { get; set; }
		
		/// <summary>
		/// type of audit log change key
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }
	}

	public class AuditLogEntryInfo
	{
		/// <summary>
		/// number of days after which inactive members were kicked
		/// </summary>
		[JsonProperty("delete_member_days")]
		public string DeletedMemberDays { get; set; }
		
		/// <summary>
		/// number of members removed by the prune
		/// </summary>
		[JsonProperty("members_removed")]
		public string MembersRemoved { get; set; }
		
		/// <summary>
		/// channel in which the messages were deleted
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }

		/// <summary>
		/// number of deleted messages
		/// </summary>
		[JsonProperty("count")]
		public string Count { get; set; }
		
		/// <summary>
		/// id of the overwritten entity
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// type of overwritten entity ("member" or "role")
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }
		
		/// <summary>
		/// name of the role if type is "role"
		/// </summary>
		[JsonProperty("role_name")]
		public string RoleName { get; set; }
	}
}