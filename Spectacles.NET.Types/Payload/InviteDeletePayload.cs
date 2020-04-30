using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Sent when an invite is deleted.
	/// </summary>
	[DataContract]
	public class InviteDeletePayload
	{
		/// <summary>
		/// the channel of the invite
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }
		
		/// <summary>
		/// the guild of the invite
		/// </summary>
		[DataMember(Name="channel_id", Order=2)]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// the unique invite code
		/// </summary>
		[DataMember(Name="code", Order=3)]
		public string Code { get; set; }
	}
}
