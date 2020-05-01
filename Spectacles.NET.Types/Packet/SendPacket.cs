using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Packet we send over the Discord gateway
	/// </summary>
	[DataContract]
	public class SendPacket
	{
		/// <summary>
		///     The OpCode of this packet
		/// </summary>
		[DataMember(Name="op", Order=1)]
		public OpCode OpCode { get; set; }

		/// <summary>
		///     The Data of this packet
		/// </summary>
		[DataMember(Name="d", Order=2)]
		public object Data { get; set; }
	}
}
