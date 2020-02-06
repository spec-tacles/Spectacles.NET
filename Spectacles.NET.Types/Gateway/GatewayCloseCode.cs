namespace Spectacles.NET.Types
{
	/// <summary>
	///     Your connection to our gateway may also sometimes close. When it does, you will receive a close code that tells you
	///     what happened.
	/// </summary>
	public enum GatewayCloseCode
	{
		/// <summary>
		///     We're not sure what went wrong. Try reconnecting?
		/// </summary>
		UNKNOWN_ERROR = 4000,

		/// <summary>
		///     You sent an invalid Gateway opcode or an invalid payload for an opcode. Don't do that!
		/// </summary>
		UNKNOWN_OP_CODE,

		/// <summary>
		///     You sent an invalid payload to us. Don't do that!
		/// </summary>
		DECODE_ERROR,

		/// <summary>
		///     You sent us a payload prior to identifying.
		/// </summary>
		NOT_AUTHENTICATED,

		/// <summary>
		///     The account token sent with your identify payload is incorrect.
		/// </summary>
		AUTHENTICATION_FAILED,

		/// <summary>
		///     You sent more than one identify payload. Don't do that!
		/// </summary>
		ALREADY_AUTHENTICATED,

		/// <summary>
		///     The sequence sent when resuming the session was invalid. Reconnect and start a new session.
		/// </summary>
		INVALID_SEQ = 4007,

		/// <summary>
		///     Woah nelly! You're sending payloads to us too quickly. Slow it down!
		/// </summary>
		RATE_LIMITED,

		/// <summary>
		///     Your session timed out. Reconnect and start a new one.
		/// </summary>
		SESSION_TIMEOUT,

		/// <summary>
		///     You sent us an invalid shard when identifying.
		/// </summary>
		INVALID_SHARD,

		/// <summary>
		///     The session would have handled too many guilds - you are required to shard your connection in order to connect.
		/// </summary>
		SHARDING_REQUIRED,
		
		/// <summary>
		/// 	You sent an invalid value for a Gateway <see cref="Intents"/>. You may have incorrectly calculated the bitwise value, or tried to specify an intent that you have not enabled or are not whitelisted for.
		/// </summary>
		INVALID_INTENTS,
		
		/// <summary>
		/// 	Disallowed intents. Your bot might not be eligible to request a privileged intent such as GUILD_PRESENCES or GUILD_MEMBERS.
		/// </summary>
		DISALLOWED_INTENTS
	}
}
