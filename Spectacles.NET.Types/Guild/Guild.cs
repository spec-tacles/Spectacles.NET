// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    ///     Guilds in Discord represent an isolated collection of users and channels, and are often referred to as "servers" in
    ///     the UI. See <a href="http://discordapp.com/developers/docs/resources/guild">here</a>.
    /// </summary>
    [DataContract]
    public class Guild
    {
        /// <summary>
        ///     guild id
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        ///     guild name (2-100 characters)
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        ///     icon hash
        /// </summary>
        [DataMember(Name = "icon", Order = 3)]
        public string Icon { get; set; }

        /// <summary>
        ///     splash hash
        /// </summary>
        [DataMember(Name = "splash", Order = 4)]
        public string Splash { get; set; }

        /// <summary>
        ///     whether or not the user is the owner of the guild
        /// </summary>
        [DataMember(Name = "owner", IsRequired = false, Order = 5)]
        [DefaultValue(false)]
        public bool? Owner { get; set; }

        /// <summary>
        ///     id of owner
        /// </summary>
        [DataMember(Name = "owner_id", Order = 6)]
        public string OwnerId { get; set; }

        /// <summary>
        ///     total permissions for the user in the guild (does not include channel overrides)
        /// </summary>
        [DataMember(Name = "permissions", Order = 7)]
        public Permission? Permissions { get; set; }

        /// <summary>
        ///     voice region id for the guild
        /// </summary>
        [DataMember(Name = "region", Order = 8)]
        public string Region { get; set; }

        /// <summary>
        ///     id of afk channel
        /// </summary>
        [DataMember(Name = "afk_channel_id", Order = 9)]
        public string AFKChannelId { get; set; }

        /// <summary>
        ///     afk timeout in seconds
        /// </summary>
        [DataMember(Name = "afk_timeout", Order = 10)]
        public int AFKTimeout { get; set; }

        /// <summary>
        ///     is this guild embeddable (e.g. widget)
        /// </summary>
        [DataMember(Name = "embed_enabled", Order = 11)]
        public bool? EmbedEnabled { get; set; }

        /// <summary>
        ///     if not null, the channel id that the widget will generate an invite to
        /// </summary>
        [DataMember(Name = "embed_channel_id", Order = 12)]
        public string EmbedChannelId { get; set; }

        /// <summary>
        ///     verification level required for the guild
        /// </summary>
        [DataMember(Name = "verification_level", Order = 13)]
        public VerificationLevel VerificationLevel { get; set; }

        /// <summary>
        ///     default message notifications level
        /// </summary>
        [DataMember(Name = "default_message_notifications", Order = 14)]
        public DefaultMessageNotificationLevel DefaultMessageNotificationLevel { get; set; }

        /// <summary>
        ///     explicit content filter level
        /// </summary>
        [DataMember(Name = "explicit_content_filter", Order = 15)]
        public ExplicitContentFilterLevel ExplicitContentFilter { get; set; }

        /// <summary>
        ///     roles in the guild
        /// </summary>
        [DataMember(Name = "roles", Order = 16)]
        public List<Role> Roles { get; set; }

        /// <summary>
        ///     custom guild emojis
        /// </summary>
        [DataMember(Name = "emojis", Order = 17)]
        public List<Emoji> Emojis { get; set; }

        /// <summary>
        ///     enabled guild features
        /// </summary>
        [DataMember(Name = "features", Order = 18)]
        public List<GuildFeature> Features { get; set; }

        /// <summary>
        ///     required MFA level for the guild
        /// </summary>
        [DataMember(Name = "mfa_level", Order = 19)]
        public MFALevel MFALevel { get; set; }

        /// <summary>
        ///     application id of the guild creator if it is bot-created
        /// </summary>
        [DataMember(Name = "application_id", Order = 20)]
        public string ApplicationId { get; set; }

        /// <summary>
        ///     whether or not the server widget is enabled
        /// </summary>
        [DataMember(Name = "widget_enabled", Order = 21)]
        public bool? WidgetEnabled { get; set; }

        /// <summary>
        ///     the channel id for the server widget
        /// </summary>
        [DataMember(Name = "widget_channel_id", Order = 22)]
        public string WidgetChannelId { get; set; }

        /// <summary>
        ///     the id of the channel to which system messages are sent
        /// </summary>
        [DataMember(Name = "system_channel_id", Order = 23)]
        public string SystemChannelId { get; set; }

        /// <summary>
        ///     when this guild was joined at
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "joined_at", Order = 24)]
        public string JoinedAt { get; set; }

        /// <summary>
        ///     whether this is considered a large guild
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "large", Order = 25)]
        public bool? Large { get; set; }

        /// <summary>
        ///     is this guild unavailable
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "unavailable", Order = 26)]
        public bool? Unavailable { get; set; }

        /// <summary>
        ///     total number of members in this guild
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "member_count", Order = 27)]
        public int? MemberCount { get; set; }

        /// <summary>
        ///     (without the guild_id key)
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "voice_states", Order = 28)]
        public List<VoiceState> VoiceStates { get; set; }

        /// <summary>
        ///     users in the guild
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "members", Order = 29)]
        public List<GuildMember> Members { get; set; }

        /// <summary>
        ///     channels in the guild
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "channels", Order = 30)]
        public List<Channel> Channels { get; set; }

        /// <summary>
        ///     presences of the users in the guild
        ///     <remarks>These field is only sent within the GUILD_CREATE event</remarks>
        /// </summary>
        [DataMember(Name = "presences", Order = 31)]
        public List<Presence> Presences { get; set; }

        /// <summary>
        ///     the maximum amount of presences for the guild
        /// </summary>
        [DataMember(Name = "max_presences", Order = 32)]
        public int? MaxPresences { get; set; }

        /// <summary>
        ///     the maximum amount of members for the guild
        /// </summary>
        [DataMember(Name = "max_members", Order = 33)]
        public int MaxMembers { get; set; }

        /// <summary>
        ///     the vanity url code for the guild
        /// </summary>
        [DataMember(Name = "vanity_url_code", Order = 34)]
        public string VanityURLCode { get; set; }

        /// <summary>
        ///     the description for the guild
        /// </summary>
        [DataMember(Name = "description", Order = 35)]
        public string Description { get; set; }

        /// <summary>
        ///     banner hash
        /// </summary>
        [DataMember(Name = "banner", Order = 36)]
        public string Banner { get; set; }

        /// <summary>
        ///     premium tier
        /// </summary>
        [DataMember(Name = "premium_tier", Order = 37)]
        public PremiumTier PremiumTier { get; set; }

        /// <summary>
        ///     the total number of users currently boosting this server
        /// </summary>
        [DataMember(Name = "premium_subscription_count", Order = 38)]
        public int? PremiumSubscriberCount { get; set; }

        /// <summary>
        ///     the preferred locale of this guild only set if guild has the "DISCOVERABLE" feature, defaults to en-US
        /// </summary>
        [DataMember(Name = "preferred_locale", Order = 39)]
        public string PreferredLocale { get; set; }
    }
}