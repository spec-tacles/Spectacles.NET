// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public enum ChannelType
	{
		GUILD_TEXT,
		DM,
		GUILD_VOICE,
		GROUP_DM,
		GUILD_CATEGORY,
	}
	
	/// <summary>
	/// A Discord Channel Represents a guild or DM channel within Discord. <see cref="http://discordapp.com/developers/docs/resources/channel"/>
	/// </summary>
	public class Channel
	{
		/// <summary>
		/// The id of this channel
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// the type of channel see <see cref="ChannelType"/>
		/// </summary>
		[JsonProperty("type")]
		public ChannelType Type { get; set; }
		
		/// <summary>
		/// the id of the guild
		/// </summary>
		[JsonProperty("guild_id", NullValueHandling = NullValueHandling.Ignore)]
		public string GuildID { get; set; }
		
		/// <summary>
		/// sorting position of the channel
		/// </summary>
		[JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
		public int? Position { get; set; }
		
		/// <summary>
		/// explicit permission overwrites for members and roles
		/// </summary>
		[JsonProperty("permission_overwrites", NullValueHandling = NullValueHandling.Ignore)]
		public List<PermissionOverwrite> PermissionOverwrites { get; set; }
		
		/// <summary>
		/// the name of the channel (2-100 characters)
		/// </summary>
		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		/// <summary>
		/// the channel topic (0-1024 characters)
		/// </summary>
		[JsonProperty("topic", NullValueHandling = NullValueHandling.Ignore)]
		public string Topic { get; set; }
		
		/// <summary>
		/// whether the channel is nsfw
		/// </summary>
		[JsonProperty("nsfw", NullValueHandling = NullValueHandling.Ignore)]
		public bool? NSFW { get; set; }
		
		/// <summary>
		/// the id of the last message sent in this channel (may not point to an existing or valid message)
		/// </summary>
		[JsonProperty("last_message_id", NullValueHandling = NullValueHandling.Ignore)]
		public string LastMessageID { get; set; }
		
		/// <summary>
		/// the bitrate (in bits) of the voice channel
		/// </summary>
		[JsonProperty("bitrate", NullValueHandling = NullValueHandling.Ignore)]
		public int? Bitrate { get; set; }
		
		/// <summary>
		/// the user limit of the voice channel
		/// </summary>
		[JsonProperty("user_limit", NullValueHandling = NullValueHandling.Ignore)]
		public int? UserLimit { get; set; }
		
		/// <summary>
		/// amount of seconds a user has to wait before sending another message (0-120); bots, as well as users with the permission manage_messages or manage_channel, are unaffected
		/// </summary>
		[JsonProperty("rate_limit_per_user", NullValueHandling = NullValueHandling.Ignore)]
		public int? RateLimitPerUser { get; set; }
		
		/// <summary>
		/// the recipients of the DM
		/// </summary>
		[JsonProperty("recipients", NullValueHandling = NullValueHandling.Ignore)]
		public List<User> Recipients { get; set; }
		
		/// <summary>
		/// icon hash
		/// </summary>
		[JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
		public string Icon { get; set; }
		
		/// <summary>
		/// id of the DM creator
		/// </summary>
		[JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
		public string OwnerID { get; set; }
		
		/// <summary>
		/// application id of the group DM creator if it is bot-created
		/// </summary>
		[JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ApplicationID { get; set; }
		
		/// <summary>
		/// id of the parent category for a channel
		/// </summary>
		[JsonProperty("parent_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ParentID { get; set; }
		
		/// <summary>
		/// when the last pinned message was pinned
		/// </summary>
		[JsonProperty("last_pin_timestamp", NullValueHandling = NullValueHandling.Ignore)]
		public string LastPinTimestamp { get; set; }
	}
}