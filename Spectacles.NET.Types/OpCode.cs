namespace Spectacles.NET.Types
{
	/// <summary>
	///     All gateway events in Discord are tagged with an opcode that denotes the payload type.
	/// </summary>
	public enum OpCode
	{
		/// <summary>
		///     dispatches an event
		/// </summary>
		DISPATCH,

		/// <summary>
		///     used for ping checking
		/// </summary>
		HEARTBEAT,

		/// <summary>
		///     used for client handshake
		/// </summary>
		IDENTIFY,

		/// <summary>
		///     used to update the client status
		/// </summary>
		STATUS_UPDATE,

		/// <summary>
		///     used to join/move/leave voice channels
		/// </summary>
		VOICE_STATE_UPDATE,

		/// <summary>
		///     used to resume a closed connection
		/// </summary>
		RESUME = 6,

		/// <summary>
		///     used to tell clients to reconnect to the gateway
		/// </summary>
		RECONNECT,

		/// <summary>
		///     used to request guild members
		/// </summary>
		REQUEST_GUILD_MEMBERS,

		/// <summary>
		///     used to notify client they have an invalid session id
		/// </summary>
		INVALID_SESSION,

		/// <summary>
		///     sent immediately after connecting, contains heartbeat and server debug information
		/// </summary>
		HELLO,

		/// <summary>
		///     sent immediately following a client heartbeat that was received
		/// </summary>
		HEARTBEAT_ACK
	}
}
