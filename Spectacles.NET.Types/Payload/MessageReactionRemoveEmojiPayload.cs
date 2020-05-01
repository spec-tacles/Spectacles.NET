using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Sent when a bot removes all instances of a given emoji from the reactions of a message.
	/// </summary>
	[DataContract]
	public class MessageReactionRemoveEmojiPayload
	{
		/// <summary>
		/// the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }
		
		/// <summary>
		/// 	the id of the channel
		/// </summary>
		[DataMember(Name="channel_id", Order=2)]
		public string ChannelId { get; set; }
		
		/// <summary>
		/// the id of the message
		/// </summary>
		[DataMember(Name="message_id", Order=3)]
		public string MessageId { get; set; }
		
		/// <summary>
		/// the emoji that was removed
		/// </summary>
		[DataMember(Name="emoji", Order=4)]
		public Emoji Emoji { get; set; }
	}
}
