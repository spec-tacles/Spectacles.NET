namespace Spectacles.NET.Types
{
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
		PRESENCES_REPLACE,

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
}
