using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Reference data sent with crossposted messages.
	/// </summary>
	[DataContract]
	public class MessageReference
	{
		/// <summary>
		///     Id of the reference.
		/// </summary>
		[DataMember(Name="message_id", Order=1)]
		public string MessageId { get; set; }

		/// <summary>
		///     	Id of the originating message's channel.
		/// </summary>
		[DataMember(Name="channel_id", Order=2)]
		public string ChannelId { get; set; }

		/// <summary>
		///     Id of the originating message's guild.
		/// </summary>
		[DataMember(Name="guild_id", Order=3)]
		public string GuildId { get; set; }
	}
}
