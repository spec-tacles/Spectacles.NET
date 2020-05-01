using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Packet we receive over the Discord gateway
	/// </summary>
	[DataContract]
	public class ReceivePacket
	{
		/// <summary>
		///     The OPCode of this packet
		/// </summary>
		[DataMember(Name="op", Order=1)]
		public OpCode OpCode { get; set; }

		/// <summary>
		///     The Data of this packet
		/// </summary>
		[DataMember(Name="d", Order=2)]
		public object Data { get; set; }

		/// <summary>
		///     The current Sequence, if any
		/// </summary>
		[DataMember(Name="s", Order=3)]
		public int? Seq { get; set; }

		/// <summary>
		///     The Type of this Dispatch, if any
		/// </summary>
		[DataMember(Name="t", Order=4)]
		public GatewayEvent? Type { get; set; }
	}
}
