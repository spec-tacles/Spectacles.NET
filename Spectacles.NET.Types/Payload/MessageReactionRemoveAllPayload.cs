using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the MessageDeleteBulk event.
	/// </summary>
	[DataContract]
	public class MessageReactionRemoveAllPayload
	{
		/// <summary>
		///     the ids of the message
		/// </summary>
		[DataMember(Name="message_id", Order=1)]
		public string MessageId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[DataMember(Name="channel_id", Order=2)]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=3)]
		public string GuildId { get; set; }
	}
}
