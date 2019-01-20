using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class VoiceState
	{
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }
		
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }
		
		[JsonProperty("user_id")]
		public string UserID { get; set; }
		
		[JsonProperty("member")]
		public GuildMember Member { get; set; }
		
		[JsonProperty("session_id")]
		public string SessionID { get; set; }
		
		[JsonProperty("deaf")]
		public bool Deaf { get; set; }
		
		[JsonProperty("mute")]
		public bool Mute { get; set; }
		
		[JsonProperty("self_deaf")]
		public bool SelfDeaf { get; set; }
		
		[JsonProperty("self_mute")]
		public bool SelfMute { get; set; }
		
		[JsonProperty("suppress")]
		public bool Suppress { get; set; }
	}
}