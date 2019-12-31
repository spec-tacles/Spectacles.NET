using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Packet Sent from the Worker to the Gateway where only the GuildId is known and not the ShardCount.
	/// </summary>
	public class SendableDispatch
	{
		/// <summary>
		///     The GuildId from which the ShardId should be calculated.
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     The SendPacket which should be send to the Discord Websocket API.
		/// </summary>
		[JsonProperty("packet")]
		public SendPacket Packet { get; set; }
	}
}
