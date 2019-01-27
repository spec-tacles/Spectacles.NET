// ReSharper disable UnusedMember.Global

using System.Data;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// All gateway events in Discord are tagged with an opcode that denotes the payload type.
	/// </summary>
	public enum OpCode
	{
		/// <summary>
		/// dispatches an event
		/// </summary>
		DISPATCH,
		
		/// <summary>
		/// used for ping checking
		/// </summary>
		HEARTBEAT,
		
		/// <summary>
		/// used for client handshake
		/// </summary>
		IDENTIFY,
		
		/// <summary>
		/// used to update the client status
		/// </summary>
		STATUS_UPDATE,
		
		/// <summary>
		/// used to join/move/leave voice channels
		/// </summary>
		VOICE_STATE_UPDATE,
		
		/// <summary>
		/// used to resume a closed connection
		/// </summary>
		RESUME = 6,
		
		/// <summary>
		/// used to tell clients to reconnect to the gateway
		/// </summary>
		RECONNECT,
		
		/// <summary>
		/// used to request guild members
		/// </summary>
		REQUEST_GUILD_MEMBERS,
		
		/// <summary>
		/// used to notify client they have an invalid session id
		/// </summary>
		INVALID_SESSION,
		
		/// <summary>
		/// sent immediately after connecting, contains heartbeat and server debug information
		/// </summary>
		HELLO,
		
		/// <summary>
		/// sent immediately following a client heartbeat that was received
		/// </summary>
		HEARTBEAT_ACK
	}

	/// <summary>
	/// Your connection to our gateway may also sometimes close. When it does, you will receive a close code that tells you what happened.
	/// </summary>
	public enum GatewayCloseCode
	{
		/// <summary>
		/// We're not sure what went wrong. Try reconnecting?
		/// </summary>
		UNKNOWN_ERROR = 4000,
		
		/// <summary>
		/// You sent an invalid Gateway opcode or an invalid payload for an opcode. Don't do that!
		/// </summary>
		UNKNOWN_OP_CODE,
		
		/// <summary>
		/// You sent an invalid payload to us. Don't do that!
		/// </summary>
		DECODE_ERROR,
		
		/// <summary>
		/// You sent us a payload prior to identifying.
		/// </summary>
		NOT_AUTHENTICATED,
		
		/// <summary>
		/// The account token sent with your identify payload is incorrect.
		/// </summary>
		AUTHENTICATION_FAILED,
		
		/// <summary>
		/// You sent more than one identify payload. Don't do that!
		/// </summary>
		ALREADY_AUTHENTICATED,
		
		/// <summary>
		/// The sequence sent when resuming the session was invalid. Reconnect and start a new session.
		/// </summary>
		INVALID_SEQ = 4007,
		
		/// <summary>
		/// Woah nelly! You're sending payloads to us too quickly. Slow it down!
		/// </summary>
		RATE_LIMITED,
		
		/// <summary>
		/// Your session timed out. Reconnect and start a new one.
		/// </summary>
		SESSION_TIMEOUT,
		
		/// <summary>
		/// You sent us an invalid shard when identifying.
		/// </summary>
		INVALID_SHARD,
		
		/// <summary>
		/// The session would have handled too many guilds - you are required to shard your connection in order to connect.
		/// </summary>
		SHARDING_REQUIRED
	}

	/// <summary>
	/// A Packet we send over the Discord gateway
	/// </summary>
	public class SendPacket
	{
		/// <summary>
		/// The OpCode of this packet
		/// </summary>
		[JsonProperty("op")]
		public OpCode OpCode { get; set; }
		
		/// <summary>
		/// The Data of this packet
		/// </summary>
		[JsonProperty("d")]
		public string Data { get; set; }
	}

	/// <summary>
	/// A Packet we receive over the Discord gateway
	/// </summary>
	public class ReceivePacket
	{
		/// <summary>
		/// The OPCode of this packet
		/// </summary>
		[JsonProperty("op")]
		public OpCode OpCode { get; set; }
		
		/// <summary>
		/// The Data of this packet
		/// </summary>
		[JsonProperty("d")]
		public dynamic Data { get; set; }
		
		/// <summary>
		/// The current Sequence, if any
		/// </summary>
		[JsonProperty("s")]
		public int? Seq { get; set; }
		
		/// <summary>
		/// The Type of this Dispatch, if any
		/// </summary>
		[JsonProperty("t")]
		public string Type { get; set; }
	}

	/// <summary>
	/// The Identify data we send over the Discord Gateway
	/// </summary>
	public class IdentifyDispatch
	{
		/// <summary>
		/// authentication token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }
		
		/// <summary>
		/// <see cref="IdentifyProperties"/>
		/// </summary>
		[JsonProperty("properties")]
		public IdentifyProperties Properties { get; set; }
		
		/// <summary>
		/// whether this connection supports compression of packets
		/// </summary>
		[JsonProperty("compress")]
		public bool Compress { get; set; }
		
		/// <summary>
		/// value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild member list
		/// </summary>
		[JsonProperty("large_threshold")]
		public int LargeThreshold { get; set; }
		
		/// <summary>
		/// used for Guild Sharding
		/// </summary>
		[JsonProperty("shard")]
		public int[] Shard { get; set; }
		
		/// <summary>
		/// presence structure for initial presence information	
		/// </summary>
		[JsonProperty("presence")]
		public dynamic Presence { get; set; }
	}

	/// <summary>
	/// The properties send along with the Identify data
	/// </summary>
	public class IdentifyProperties
	{
		/// <summary>
		/// your operating system
		/// </summary>
		[JsonProperty("$os")]
		public string OS { get; set; }
		
		/// <summary>
		/// your library name
		/// </summary>
		[JsonProperty("$browser")]
		public string Browser { get; set; }
		
		/// <summary>
		/// your library name
		/// </summary>
		[JsonProperty("$device")]
		public string Device { get; set; }
	}

	/// <summary>
	/// The Ready dispatch  
	/// </summary>
	public class ReadyDispatch
	{
		/// <summary>
		/// gateway protocol version
		/// </summary>
		[JsonProperty("v")]
		public int GatewayVersion { get; set; }
		
		/// <summary>
		/// information about the user including email
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
		
		/// <summary>
		/// the guilds the user is in
		/// </summary>
		[JsonProperty("guilds")]
		public UnavailableGuild[] Guilds { get; set; }
		
		/// <summary>
		/// used for resuming connections
		/// </summary>
		[JsonProperty("session_id")]
		public string SessionID { get; set; }
		
		/// <summary>
		/// used for debugging
		/// </summary>
		[JsonProperty("_trace")]
		public string[] Trace { get; set; }
		
		/// <summary>
		/// the shard information associated with this session, if sent when identifying
		/// </summary>
		[JsonProperty("shard")]
		public int?[] Shard { get; set; }
	}

	public class ResumedDispatch
	{
		/// <summary>
		/// used for debugging
		/// </summary>
		[JsonProperty("_trace")]
		public string[] Trace { get; set; }
	}
}