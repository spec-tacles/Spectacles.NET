using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Packet we receive over the Discord gateway
	/// </summary>
	public class ReceivePacket
	{
		/// <summary>
		///     The OPCode of this packet
		/// </summary>
		[JsonProperty("op")]
		public OpCode OpCode { get; set; }

		/// <summary>
		///     The Data of this packet
		/// </summary>
		[JsonProperty("d")]
		public object Data { get; set; }

		/// <summary>
		///     The current Sequence, if any
		/// </summary>
		[JsonProperty("s")]
		public int? Seq { get; set; }

		/// <summary>
		///     The Type of this Dispatch, if any
		/// </summary>
		[JsonProperty("t")]
		public GatewayEvent? Type { get; set; }
	}
}
