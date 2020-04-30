using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Send when a new invite to a channel is created.
	/// </summary>
	[DataContract]
	public class InviteCreatePayload
	{
		/// <summary>
		/// the guild of the invite
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }
		
		/// <summary>
		/// the channel the invite is for
		/// </summary>
		[DataMember(Name="channel_id", Order=2)]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// the unique invite code
		/// </summary>
		[DataMember(Name="code", Order=3)]
		public string Code { get; set; }
		
		/// <summary>
		/// the time at which the invite was created
		/// </summary>
		[DataMember(Name="created_at", Order=4)]
		public string CreatedAt { get; set; }

		/// <summary>
		/// the user that created the invite
		/// </summary>
		[DataMember(Name="inviter", Order=5)]
		public User Inviter { get; set; }
		
		/// <summary>
		/// how long the invite is valid for (in seconds)
		/// </summary>
		[DataMember(Name="max_age", Order=6)]
		public int MaxAge { get; set; }
		
		/// <summary>
		/// the maximum number of times the invite can be used
		/// </summary>
		[DataMember(Name="max_uses", Order=7)]
		public int MaxUses { get; set; }
		
		/// <summary>
		/// whether or not the invite is temporary (invited users will be kicked on disconnect unless they're assigned a role)
		/// </summary>
		[DataMember(Name="temporary", Order=8)]
		public bool Temporary { get; set; }
		
		/// <summary>
		/// how many times the invite has been used (always will be 0)
		/// </summary>
		[DataMember(Name="uses", Order=9)]
		public int Uses { get; set; }
	}
}
