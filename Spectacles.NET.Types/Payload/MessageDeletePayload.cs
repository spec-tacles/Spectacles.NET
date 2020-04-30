using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the MessageDelete event.
	/// </summary>
	public class MessageDeletePayload
	{
		/// <summary>
		///     the id of the message
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

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
