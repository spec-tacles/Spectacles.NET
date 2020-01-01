using JsonSubTypes;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Base Class for AuditLogChanges
	/// </summary>
	[JsonConverter(typeof(JsonSubtypes), "Key")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "name")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "icon_hash")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "splash_hash")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "owner_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "afk_channel_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "afk_timeout")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "mfa_level")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "verification_level")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "explicit_content_filter")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "default_message_notifications")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "vanity_url_code")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogRoleChange), "$add")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogRoleChange), "$remove")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "prune_delete_days")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "widget_enabled")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "widget_channel_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "system_channel_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "position")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "topic")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "bitrate")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogOverwriteChange), "permission_overwrites")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "nsfw")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "application_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "rate_limit_per_user")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "permissions")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "color")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "hoist")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "mentionable")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "allow")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "deny")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "code")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "channel_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "inviter_id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "max_uses")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "uses")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "max_age")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "temporary")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "deaf")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "mute")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "nick")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "id")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogStringChange), "type")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogBoolChange), "enable_emoticons")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "expire_behavior")]
	[JsonSubtypes.KnownSubType(typeof(AuditLogIntegerChange), "expire_grace_period")]
	public abstract class AuditLogChangeBase
	{
		/// <summary>
		///     type of audit log change key
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }
	}
}
