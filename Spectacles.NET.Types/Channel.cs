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
	
	public class Channel
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("type")]
		public ChannelType Type { get; set; }
		
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }
		
		[JsonProperty("position")]
		public int? Position { get; set; }
		
		[JsonProperty("permission_overwrites")]
		public PermissionOverwrite[] PermissionOverwrites { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("topic")]
		public string Topic { get; set; }
		
		[JsonProperty("nsfw")]
		public bool? NSFW { get; set; }
		
		[JsonProperty("last_message_id")]
		public string LastMessageID { get; set; }
		
		[JsonProperty("bitrate")]
		public int? Bitrate { get; set; }
		
		[JsonProperty("user_limit")]
		public int? UserLimit { get; set; }
		
		[JsonProperty("rate_limit_per_user")]
		public int? RateLimitPerUser { get; set; }
		
		[JsonProperty("recipients")]
		public User[] Recipients { get; set; }
		
		[JsonProperty("icon")]
		public string Icon { get; set; }
		
		[JsonProperty("owner_id")]
		public string OwnerID { get; set; }
		
		[JsonProperty("application_id")]
		public string ApplicationID { get; set; }
		
		[JsonProperty("parent_id")]
		public string ParentID { get; set; }
		
		[JsonProperty("last_pin_timestamp")]
		public string LastPinTimestamp { get; set; }
	}
}