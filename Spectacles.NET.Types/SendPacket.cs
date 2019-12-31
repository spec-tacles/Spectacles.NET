using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Packet we send over the Discord gateway
	/// </summary>
	public class SendPacket
	{
		/// <summary>
		///     The OpCode of this packet
		/// </summary>
		[JsonProperty("op")]
		public OpCode OpCode { get; set; }

		/// <summary>
		///     The Data of this packet
		/// </summary>
		[JsonProperty("d")]
		public object Data { get; set; }
	}
}
