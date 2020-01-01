namespace Spectacles.NET.Types
{
	/// <summary>
	/// Type of action that occurred in an Audit Log Entry
	/// </summary>
	public enum AuditLogEvent
	{
		/// <summary>
		/// Guild Update Event
		/// </summary>
		GUILD_UPDATE = 1,
		
		/// <summary>
		/// Channel Create Event
		/// </summary>
		CHANNEL_CREATE = 10,
		
		/// <summary>
		/// Channel Update Event
		/// </summary>
		CHANNEL_UPDATE,
		
		/// <summary>
		/// Channel Delete Event
		/// </summary>
		CHANNEL_DELETE,
		
		/// <summary>
		/// Channel Overwrite Create Event
		/// </summary>
		CHANNEL_OVERWRITE_CREATE,
		
		/// <summary>
		/// Channel Overwrite Update Event
		/// </summary>
		CHANNEL_OVERWRITE_UPDATE,
		
		/// <summary>
		/// Channel Overwrite Delete Event
		/// </summary>
		CHANNEL_OVERWRITE_DELETE,
		
		/// <summary>
		/// Member Kick Event
		/// </summary>
		MEMBER_KICK = 20,
		
		/// <summary>
		/// Member Prune Event
		/// </summary>
		MEMBER_PRUNE,
		
		/// <summary>
		/// Member Ban Add Event
		/// </summary>
		MEMBER_BAN_ADD,
		
		/// <summary>
		/// Member Ban Remove Event
		/// </summary>
		MEMBER_BAN_REMOVE,
		
		/// <summary>
		/// Member Update Event
		/// </summary>
		MEMBER_UPDATE,
		
		/// <summary>
		/// Member Role Update Event
		/// </summary>
		MEMBER_ROLE_UPDATE,
		
		/// <summary>
		/// Member Move Event
		/// </summary>
		MEMBER_MOVE,
		
		/// <summary>
		/// Member Disconnect Event
		/// </summary>
		MEMBER_DISCONNECT,
		
		/// <summary>
		/// Bot Add Event
		/// </summary>
		BOT_ADD,
		
		/// <summary>
		/// Role Create Event
		/// </summary>
		ROLE_CREATE = 30,
		
		/// <summary>
		/// Bot Update Event
		/// </summary>
		ROLE_UPDATE,
		
		/// <summary>
		/// Bot Delete Event
		/// </summary>
		ROLE_DELETE,
		
		/// <summary>
		/// Invite Create Event
		/// </summary>
		INVITE_CREATE = 40,
		
		/// <summary>
		/// Invite Update Event
		/// </summary>
		INVITE_UPDATE,
		
		/// <summary>
		/// Invite Delete Event
		/// </summary>
		INVITE_DELETE,
		
		/// <summary>
		/// Webhook Create Event
		/// </summary>
		WEBHOOK_CREATE = 50,
		
		/// <summary>
		/// Webhook Update Event
		/// </summary>
		WEBHOOK_UPDATE,
		
		/// <summary>
		/// Webhook Delete Event
		/// </summary>
		WEBHOOK_DELETE,
		
		/// <summary>
		/// Emoji Create Event
		/// </summary>
		EMOJI_CREATE = 60,
		
		/// <summary>
		/// Emoji Update Event
		/// </summary>
		EMOJI_UPDATE,
		
		/// <summary>
		/// Emoji Delete Event
		/// </summary>
		EMOJI_DELETE,
		
		/// <summary>
		/// Message Delete Event
		/// </summary>
		MESSAGE_DELETE = 72,
		
		/// <summary>
		/// Message Bulk Delete Event
		/// </summary>
		MESSAGE_BULK_DELETE,
		
		/// <summary>
		/// Message Pin Event
		/// </summary>
		MESSAGE_PIN,
		
		/// <summary>
		/// Message Unpin Event
		/// </summary>
		MESSAGE_UNPIN,
		
		/// <summary>
		/// Integration Create Event
		/// </summary>
		INTEGRATION_CREATE = 80,
		
		/// <summary>
		/// Integration Update Event
		/// </summary>
		INTEGRATION_UPDATE,
		
		/// <summary>
		/// Integration Delete Event
		/// </summary>
		INTEGRATION_DELETE
	}
}
