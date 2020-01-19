using System;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Send when a new invite to a channel is created.
	/// </summary>
	public class InviteCreatePayload
	{
		/// <summary>
		/// the guild of the invite
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
		
		/// <summary>
		/// the channel the invite is for
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// the unique invite code
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }
		
		/// <summary>
		/// the time at which the invite was created
		/// </summary>
		[JsonProperty("created_at")]
		public string CreatedAt { get; set; }

		/// <summary>
		/// the user that created the invite
		/// </summary>
		[JsonProperty("inviter")]
		public User Inviter { get; set; }
		
		/// <summary>
		/// how long the invite is valid for (in seconds)
		/// </summary>
		[JsonProperty("max_age")]
		public int MaxAge { get; set; }
		
		/// <summary>
		/// the maximum number of times the invite can be used
		/// </summary>
		[JsonProperty("max_uses")]
		public int MaxUses { get; set; }
		
		/// <summary>
		/// whether or not the invite is temporary (invited users will be kicked on disconnect unless they're assigned a role)
		/// </summary>
		[JsonProperty("temporary")]
		public bool Temporary { get; set; }
		
		/// <summary>
		/// how many times the invite has been used (always will be 0)
		/// </summary>
		[JsonProperty("uses")]
		public int Uses { get; set; }
	}
}
