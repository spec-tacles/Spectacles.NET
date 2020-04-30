using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Sent on connection to the websocket. Defines the heartbeat interval that the client should heartbeat to.
	/// </summary>
	[DataContract]
	public class HelloPacket
	{
		/// <summary>
		///     the interval (in milliseconds) the client should heartbeat with
		/// </summary>
		[DataMember(Name="heartbeat_interval", Order=1)]
		public long HeartbeatInterval { get; set; }
	}
}
