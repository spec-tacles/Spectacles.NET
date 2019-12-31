using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Sent on connection to the websocket. Defines the heartbeat interval that the client should heartbeat to.
	/// </summary>
	public class HelloPacket
	{
		/// <summary>
		///     the interval (in milliseconds) the client should heartbeat with
		/// </summary>
		[JsonProperty("heartbeat_interval")]
		public long HeartbeatInterval { get; set; }
	}
}
