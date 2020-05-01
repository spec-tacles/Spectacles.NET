using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the TypingStart event.
	/// </summary>
	[DataContract]
	public class TypingStartPayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[DataMember(Name = "user_id", Order = 1)]
		public string UserId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[DataMember(Name = "channel_id", Order = 2)]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name = "guild_id", Order = 3)]
		public string GuildId { get; set; }

		/// <summary>
		///     unix time (in seconds) of when the user started typing
		/// </summary>
		[DataMember(Name = "timestamp", Order = 4)]
		public long Timestamp { get; set; }
	}
}
