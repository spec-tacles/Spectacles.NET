using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Used to represent a user's voice connection status.
	/// </summary>
	public class VoiceState
	{
		/// <summary>
		/// the guild id this voice state is for
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }
		
		/// <summary>
		/// the channel id this user is connected to
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }
		
		/// <summary>
		/// the user id this voice state is for
		/// </summary>
		[JsonProperty("user_id")]
		public string UserID { get; set; }
		
		/// <summary>
		/// the guild member this voice state is for
		/// </summary>
		[JsonProperty("member")]
		public GuildMember Member { get; set; }
		
		/// <summary>
		/// the session id for this voice state
		/// </summary>
		[JsonProperty("session_id")]
		public string SessionID { get; set; }
		
		/// <summary>
		/// whether this user is deafened by the server
		/// </summary>
		[JsonProperty("deaf")]
		public bool Deaf { get; set; }
		
		/// <summary>
		/// whether this user is muted by the server
		/// </summary>
		[JsonProperty("mute")]
		public bool Mute { get; set; }
		
		/// <summary>
		/// whether this user is locally deafened
		/// </summary>
		[JsonProperty("self_deaf")]
		public bool SelfDeaf { get; set; }
		
		/// <summary>
		/// whether this user is locally muted
		/// </summary>
		[JsonProperty("self_mute")]
		public bool SelfMute { get; set; }
		
		/// <summary>
		/// whether this user is muted by the current user
		/// </summary>
		[JsonProperty("suppress")]
		public bool Suppress { get; set; }
	}
}