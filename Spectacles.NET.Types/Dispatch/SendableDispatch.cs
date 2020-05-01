using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Packet Sent from the Worker to the Gateway where only the GuildId is known and not the ShardCount.
	/// </summary>
	[DataContract]
    public class SendableDispatch
	{
		/// <summary>
		///     The GuildId from which the ShardId should be calculated.
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     The SendPacket which should be send to the Discord Websocket API.
		/// </summary>
		[DataMember(Name="packet", Order=2)]
		public SendPacket Packet { get; set; }
	}
}
