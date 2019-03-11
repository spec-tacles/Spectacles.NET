// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
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
	
	/// <summary>
	/// Guilds in Discord represent an isolated collection of users and channels, and are often referred to as "servers" in the UI. <see cref="http://discordapp.com/developers/docs/resources/guild"/>
	/// </summary>
	public class Guild
	{
		/// <summary>
		/// guild id
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// guild name (2-100 characters)
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// icon hash
		/// </summary>
		[JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
		public string Icon { get; set; }
		
		/// <summary>
		/// splash hash
		/// </summary>
		[JsonProperty("splash", NullValueHandling = NullValueHandling.Ignore)]
		public string Splash { get; set; }
		
		/// <summary>
		/// whether or not the user is the owner of the guild
		/// </summary>
		[JsonProperty(PropertyName = "owner", DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore), DefaultValue(false)]
		public bool? Owner { get; set; }
		
		/// <summary>
		/// id of owner
		/// </summary>
		[JsonProperty("owner_id")]
		public string OwnerID { get; set; }
		
		/// <summary>
		/// total permissions for the user in the guild (does not include channel overrides)
		/// </summary>
		[JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
		public Permission? Permissions { get; set; }
		
		/// <summary>
		/// voice region id for the guild
		/// </summary>
		[JsonProperty("region")]
		public string Region { get; set; }
		
		/// <summary>
		/// id of afk channel
		/// </summary>
		[JsonProperty("afk_channel_id", NullValueHandling = NullValueHandling.Ignore)]
		public string AFKChannelID { get; set; }
		
		/// <summary>
		/// afk timeout in seconds
		/// </summary>
		[JsonProperty("afk_timeout")]
		public int AFKTimeout { get; set; }
		
		/// <summary>
		/// is this guild embeddable (e.g. widget)
		/// </summary>
		[JsonProperty("embed_enabled", NullValueHandling = NullValueHandling.Ignore)]
		public bool? EmbedEnabled { get; set; }
		
		/// <summary>
		/// if not null, the channel id that the widget will generate an invite to
		/// </summary>
		[JsonProperty("embed_channel_id", NullValueHandling = NullValueHandling.Ignore)]
		public string EmbedChannelID { get; set; }

		/// <summary>
		/// 	verification level required for the guild
		/// </summary>
		[JsonProperty("verification_level")]
		public VerificationLevel VerificationLevel { get; set; }
		
		/// <summary>
		/// default message notifications level
		/// </summary>
		[JsonProperty("default_message_notifications")]
		public DefaultMessageNotificationLevel DefaultMessageNotificationLevel { get; set; }
		
		/// <summary>
		/// explicit content filter level
		/// </summary>
		[JsonProperty("explicit_content_filter")]
		public ExplicitContentFilterLevel ExplicitContentFilter { get; set; }
		
		/// <summary>
		/// roles in the guild
		/// </summary>
		[JsonProperty("roles")]
		public List<Role> Roles { get; set; }
		
		/// <summary>
		/// custom guild emojis
		/// </summary>
		[JsonProperty("emojis")]
		public List<Emoji> Emojis { get; set; }
		
		/// <summary>
		/// enabled guild features
		/// </summary>
		[JsonProperty("features")]
		public List<string> Features { get; set; }
		
		/// <summary>
		/// required MFA level for the guild
		/// </summary>
		[JsonProperty("mfa_level")]
		public MFALevel MFALevel { get; set; }
		
		/// <summary>
		/// application id of the guild creator if it is bot-created
		/// </summary>
		[JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ApplicationID { get; set; }
		
		/// <summary>
		/// whether or not the server widget is enabled
		/// </summary>
		[JsonProperty("widget_enabled", NullValueHandling = NullValueHandling.Ignore)]
		public bool? WidgetEnabled { get; set; }
		
		/// <summary>
		/// the channel id for the server widget
		/// </summary>
		[JsonProperty("widget_channel_id", NullValueHandling = NullValueHandling.Ignore)]
		public string WidgetChannelID { get; set; }
		
		/// <summary>
		/// the id of the channel to which system messages are sent
		/// </summary>
		[JsonProperty("system_channel_id", NullValueHandling = NullValueHandling.Ignore)]
		public string SystemChannelID { get; set; }
		
		/// <summary>
		/// when this guild was joined at
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("joined_at", NullValueHandling = NullValueHandling.Ignore)]
		public string JoinedAt { get; set; }
		
		/// <summary>
		/// whether this is considered a large guild
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Large { get; set; }
		
		/// <summary>
		/// is this guild unavailable
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("unavailable", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Unavailable { get; set; }
		
		/// <summary>
		/// total number of members in this guild
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("member_count", NullValueHandling = NullValueHandling.Ignore)]
		public int? MemberCount { get; set; }
		
		/// <summary>
		/// (without the guild_id key)
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("voice_states", NullValueHandling = NullValueHandling.Ignore)]
		public List<VoiceState> VoiceStates { get; set; }
		
		/// <summary>
		/// users in the guild
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
		public List<GuildMember> Members { get; set; }
		
		/// <summary>
		/// channels in the guild
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("channels", NullValueHandling = NullValueHandling.Ignore)]
		public List<Channel> Channels { get; set; }
		
		/// <summary>
		/// presences of the users in the guild
		/// <remarks>These field is only sent within the GUILD_CREATE event</remarks>
		/// </summary>
		[JsonProperty("presences", NullValueHandling = NullValueHandling.Ignore)]
		public List<Presence> Presences { get; set; }
	}
}