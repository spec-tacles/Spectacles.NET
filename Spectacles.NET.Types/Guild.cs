// ReSharper disable UnusedMember.Global

using System.ComponentModel;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public enum VerificationLevel
	{
		NONE,
		LOW,
		MEDIUM,
		HIGH,
		VERY_HIGH
	}

	public enum DefaultMessageNotificationLevel
	{
		ALL_MESSAGES,
		ONLY_MENTIONS
	}
	
	public enum ExplicitContentFilterLevel {
		DISABLED,
		MEMBERS_WITHOUT_ROLES,
		ALL_MEMBERS
	}
	
	public enum MFALevel {
		NONE,
		ELEVATED
	}
	
	public class Guild
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("icon")]
		public string Icon { get; set; }
		
		[JsonProperty("splash")]
		public string Splash { get; set; }
		
		[JsonProperty(PropertyName = "owner", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(false)]
		public bool? Owner { get; set; }
		
		[JsonProperty("owner_id")]
		public string OwnerID { get; set; }
		
		[JsonProperty("permissions")]
		public int? Permissions { get; set; }
		
		[JsonProperty("region")]
		public string Region { get; set; }
		
		[JsonProperty("afk_channel_id")]
		public string AFKChannelID { get; set; }
		
		[JsonProperty("afk_timeout")]
		public int AFKTimeout { get; set; }
		
		[JsonProperty("embed_enabled")]
		public bool? EmbedEnabled { get; set; }
		
		[JsonProperty("embed_channel_id")]
		public string EmbedChannelID { get; set; }

		[JsonProperty("verification_level")]
		public VerificationLevel VerificationLevel { get; set; }
		
		[JsonProperty("default_message_notifications")]
		public DefaultMessageNotificationLevel DefaultMessageNotificationLevel { get; set; }
		
		[JsonProperty("explicit_content_filter")]
		public ExplicitContentFilterLevel ExplicitContentFilter { get; set; }
		
		[JsonProperty("roles")]
		public Role[] Roles { get; set; }
		
		[JsonProperty("emojis")]
		public Emoji[] Emojis { get; set; }
		
		[JsonProperty("features")]
		public string[] Features { get; set; }
		
		[JsonProperty("mfa_level")]
		public MFALevel MFALevel { get; set; }
		
		[JsonProperty("application_id")]
		public string ApplicationID { get; set; }
		
		[JsonProperty("widget_enabled")]
		public bool? WidgetEnabled { get; set; }
		
		[JsonProperty("widget_channel_id")]
		public string WidgetChannelID { get; set; }
		
		[JsonProperty("system_channel_id")]
		public string SystemChannelID { get; set; }
		
		[JsonProperty("joined_at")]
		public string JoinedAt { get; set; }
		
		[JsonProperty("large")]
		public bool? Large { get; set; }
		
		[JsonProperty("unavailable")]
		public bool? Unavailable { get; set; }
		
		[JsonProperty("member_count")]
		public int? MemberCount { get; set; }
		
		[JsonProperty("voice_states")]
		public VoiceState[] VoiceStates { get; set; }
		
		[JsonProperty("members")]
		public GuildMember[] Members { get; set; }
		
		[JsonProperty("channels")]
		public Channel[] Channels { get; set; }
		
		[JsonProperty("presences")]
		public Presence[] Presences { get; set; }
	}
}