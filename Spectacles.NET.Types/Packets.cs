// ReSharper disable UnusedMember.Global

using Newtonsoft.Json;

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
		SHARDING_REQUIRED
	}

	/// <summary>
	///     Events are payloads sent over the socket to a client that correspond to events in Discord.
	/// </summary>
	public enum GatewayEvent
	{
		/// <summary>
		///     contains the initial state information
		/// </summary>
		READY,

		/// <summary>
		///     response to Resume
		/// </summary>
		RESUMED,

		/// <summary>
		///     new channel created
		/// </summary>
		CHANNEL_CREATE,

		/// <summary>
		///     channel was updated
		/// </summary>
		CHANNEL_UPDATE,

		/// <summary>
		///     channel was deleted
		/// </summary>
		CHANNEL_DELETE,

		/// <summary>
		///     message was pinned or unpinned
		/// </summary>
		CHANNEL_PINS_UPDATE,

		/// <summary>
		///     lazy-load for unavailable guild, guild became available, or user joined a new guild
		/// </summary>
		GUILD_CREATE,

		/// <summary>
		///     guild was updated
		/// </summary>
		GUILD_UPDATE,

		/// <summary>
		///     guild became unavailable, or user left/was removed from a guild
		/// </summary>
		GUILD_DELETE,

		/// <summary>
		///     user was banned from a guild
		/// </summary>
		GUILD_BAN_ADD,

		/// <summary>
		///     user was unbanned from a guild
		/// </summary>
		GUILD_BAN_REMOVE,

		/// <summary>
		///     guild emojis were updated
		/// </summary>
		GUILD_EMOJIS_UPDATE,

		/// <summary>
		///     guild integration was updated
		/// </summary>
		GUILD_INTEGRATIONS_UPDATE,

		/// <summary>
		///     new user joined a guild
		/// </summary>
		GUILD_MEMBER_ADD,

		/// <summary>
		///     user was removed from a guild
		/// </summary>
		GUILD_MEMBER_REMOVE,

		/// <summary>
		///     guild member was updated
		/// </summary>
		GUILD_MEMBER_UPDATE,

		/// <summary>
		///     response to Request Guild Members
		/// </summary>
		GUILD_MEMBERS_CHUNK,

		/// <summary>
		///     guild role was created
		/// </summary>
		GUILD_ROLE_CREATE,

		/// <summary>
		///     guild role was updated
		/// </summary>
		GUILD_ROLE_UPDATE,

		/// <summary>
		///     guild role was deleted
		/// </summary>
		GUILD_ROLE_DELETE,

		/// <summary>
		///     message was created
		/// </summary>
		MESSAGE_CREATE,

		/// <summary>
		///     message was edited
		/// </summary>
		MESSAGE_UPDATE,

		/// <summary>
		///     message was deleted
		/// </summary>
		MESSAGE_DELETE,

		/// <summary>
		///     multiple messages were deleted at once
		/// </summary>
		MESSAGE_DELETE_BULK,

		/// <summary>
		///     user reacted to a message
		/// </summary>
		MESSAGE_REACTION_ADD,

		/// <summary>
		///     user removed a reaction from a message
		/// </summary>
		MESSAGE_REACTION_REMOVE,

		/// <summary>
		///     all reactions were explicitly removed from a message
		/// </summary>
		MESSAGE_REACTION_REMOVE_ALL,

		/// <summary>
		///     user was updated
		/// </summary>
		PRESENCE_UPDATE,

		/// <summary>
		///     used to replace presences after outages, data is null for bot accounts receiving it
		///     <remarks>Bot Accounts should ignore this</remarks>
		/// </summary>
		PRESENCE_REPLACE,

		/// <summary>
		///     user started typing in a channel
		/// </summary>
		TYPING_START,

		/// <summary>
		///     properties about the user changed
		/// </summary>
		USER_UPDATE,

		/// <summary>
		///     someone joined, left, or moved a voice channel
		/// </summary>
		VOICE_STATE_UPDATE,

		/// <summary>
		///     guild's voice server was updated
		/// </summary>
		VOICE_SERVER_UPDATE,

		/// <summary>
		///     guild channel webhook was created, update, or deleted
		/// </summary>
		WEBHOOKS_UPDATE
	}

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

	/// <summary>
	///     The Identify data we send over the Discord Gateway
	/// </summary>
	public class IdentifyPacket
	{
		/// <summary>
		///     authentication token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		///     <see cref="IdentifyProperties" />
		/// </summary>
		[JsonProperty("properties")]
		public IdentifyProperties Properties { get; set; }

		/// <summary>
		///     whether this connection supports compression of packets
		/// </summary>
		[JsonProperty("compress")]
		public bool Compress { get; set; }

		/// <summary>
		///     value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild
		///     member list
		/// </summary>
		[JsonProperty("large_threshold")]
		public int LargeThreshold { get; set; }

		/// <summary>
		///     enables dispatching of guild subscription events (presence and typing events)
		/// </summary>
		[JsonProperty("guild_subscriptions")]
		public bool? GuildSubscription { get; set; }

		/// <summary>
		///     used for Guild Sharding
		/// </summary>
		[JsonProperty("shard")]
		public int[] Shard { get; set; }

		/// <summary>
		///     presence structure for initial presence information
		/// </summary>
		[JsonProperty("presence")]
		public UpdateStatusDispatch Presence { get; set; }
	}

	/// <summary>
	///     The properties send along with the Identify data
	/// </summary>
	public class IdentifyProperties
	{
		/// <summary>
		///     your operating system
		/// </summary>
		[JsonProperty("$os")]
		public string OS { get; set; }

		/// <summary>
		///     your library name
		/// </summary>
		[JsonProperty("$browser")]
		public string Browser { get; set; }

		/// <summary>
		///     your library name
		/// </summary>
		[JsonProperty("$device")]
		public string Device { get; set; }
	}

	/// <summary>
	///     Used to replay missed events when a disconnected client resumes.
	/// </summary>
	public class ResumePacket
	{
		/// <summary>
		///     session token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		///     session id
		/// </summary>
		[JsonProperty("session_id")]
		public string SessionID { get; set; }

		/// <summary>
		///     session id
		/// </summary>
		[JsonProperty("seq")]
		public int Sequence { get; set; }
	}

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

	/// <summary>
	///     The ready event is dispatched when a client has completed the initial handshake with the gateway (for new
	///     sessions). The ready event can be the largest and most complex event the gateway will send, as it contains all the
	///     state required for a client to begin interacting with the rest of the platform.
	/// </summary>
	public class ReadyDispatch
	{
		/// <summary>
		///     gateway protocol version
		/// </summary>
		[JsonProperty("v")]
		public int GatewayVersion { get; set; }

		/// <summary>
		///     information about the user including email
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <summary>
		///     the guilds the user is in
		/// </summary>
		[JsonProperty("guilds")]
		public UnavailableGuild[] Guilds { get; set; }

		/// <summary>
		///     used for resuming connections
		/// </summary>
		[JsonProperty("session_id")]
		public string SessionID { get; set; }

		/// <summary>
		///     the shard information associated with this session, if sent when identifying
		/// </summary>
		[JsonProperty("shard")]
		public int?[] Shard { get; set; }
	}

	/// <summary>
	///     A Packet Sent from the Worker to the Gateway where only the GuildID is known and not the ShardCount.
	/// </summary>
	public class SendableDispatch
	{
		/// <summary>
		///     The GuildID from which the ShardID should be calculated.
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		///     The SendPacket which should be send to the Discord Websocket API.
		/// </summary>
		[JsonProperty("packet")]
		public SendPacket Packet { get; set; }
	}

	/// <summary>
	///     Sent by the client to indicate a presence or status update.
	/// </summary>
	public class UpdateStatusDispatch
	{
		/// <summary>
		///     unix time (in milliseconds) of when the client went idle, or null if the client is not idle
		/// </summary>
		[JsonProperty("since")]
		public int? Since { get; set; }

		/// <summary>
		///     null, or the user's new activity
		/// </summary>
		[JsonProperty("game")]
		public Activity Game { get; set; }

		/// <summary>
		///     the user's new status
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		///     whether or not the client is afk
		/// </summary>
		[JsonProperty("afk")]
		public bool AFK { get; set; }
	}

	/// <summary>
	///     Used to request offline members for a guild or a list of guilds. When initially connecting, the gateway will only
	///     send offline members if a guild has less than the large_threshold members (value in the Gateway Identify). If a
	///     client wishes to receive additional members, they need to explicitly request them via this operation. The server
	///     will send Guild Members Chunk events in response with up to 1000 members per chunk until all members that match the
	///     request have been sent.
	/// </summary>
	public class RequestGuildMembersDispatch
	{
		/// <summary>
		///     id of the guild(s) to get offline members for
		/// </summary>
		[JsonProperty("guild_id")]
		public object GuildID { get; set; }

		/// <summary>
		///     string that username starts with, or an empty string to return all members
		/// </summary>
		[JsonProperty("query")]
		public string Query { get; set; }

		/// <summary>
		///     maximum number of members to send or 0 to request all members matched
		/// </summary>
		[JsonProperty("limit")]
		public int Limit { get; set; }
	}

	/// <summary>
	///     Sent when a client wants to join, move, or disconnect from a voice channel.
	/// </summary>
	public class UpdateVoiceStateDispatch
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		///     id of the voice channel client wants to join (null if disconnecting)
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelID { get; set; }

		/// <summary>
		///     is the client muted
		/// </summary>
		[JsonProperty("self_mute")]
		public bool SelfMute { get; set; }

		/// <summary>
		///     is the client deafened
		/// </summary>
		[JsonProperty("self_deaf")]
		public bool SelfDeaf { get; set; }
	}
}
