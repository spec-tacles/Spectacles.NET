using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the WebhookUpdate event.
	/// </summary>
	[DataContract]
	public class WebhookUpdatePayload
	{
		/// <summary>
		///     the id of the channel
		/// </summary>
		[DataMember(Name="channel_id", Order=1)]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=2)]
		public string GuildId { get; set; }
	}
}
