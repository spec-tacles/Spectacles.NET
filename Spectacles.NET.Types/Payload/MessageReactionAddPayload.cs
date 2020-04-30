using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the MessageReactionAdd events.
	/// </summary>
	public class MessageReactionAddPayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[DataMember(Name="user_id", Order=1)]
		public string UserId { get; set; }

		/// <summary>
		///     the ids of the message
		/// </summary>
		[DataMember(Name="message_id", Order=2)]
		public string MessageId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[DataMember(Name="channel_id", Order=3)]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=4)]
		public string GuildId { get; set; }

		/// <summary>
		///     the emoji used to react
		/// </summary>
		[DataMember(Name="emoji", Order=5)]
		public Emoji Emoji { get; set; }
	}
}
