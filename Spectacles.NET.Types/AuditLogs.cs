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
	
	public class AuditLogs
	{
		public Webhook[] Webhooks { get; set; }
		
		public User[] Users { get; set; }
		
		public AuditLogEntry[] AuditLogEntries { get; set; }
	}

	public class AuditLogEntry
	{
		public string TargetID { get; set; }
		
		public AuditLogChange[] Changes { get; set; }
		
		public string UserID { get; set; }
		
		public string ID { get; set; }
		
		public AuditLogEvent ActionType { get; set; }
		
		public AuditLogEntryInfo Options { get; set; }
		
		public string Reason { get; set; }
	}

	public class AuditLogChange
	{
		public dynamic NewValue { get; set; }
		
		public dynamic OldValue { get; set; }
		
		public string Key { get; set; }
	}

	public class AuditLogEntryInfo
	{
		public string DeletedMemberDays { get; set; }
		
		public string MembersRemoved { get; set; }
		
		public string ChannelID { get; set; }
		
		public string Count { get; set; }
		
		public string ID { get; set; }
		
		public string Type { get; set; }
		
		public string RoleName { get; set; }
	}
}