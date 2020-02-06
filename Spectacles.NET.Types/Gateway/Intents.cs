using System;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// The Discord gateway can be spammy. Like, really spammy. For a long time, the dev community has asked us for a way to “subscribe” to only the gateway events their bots need, saving tons of computational cost. With the Gateway Intents system, you tell us on IDENTIFY what you’re planning to do—your "intents"—and we'll send you only the gateway events that you need.
	/// </summary>
	[Flags]
	public enum Intents
	{
		/// <summary>
		///     - GUILD_CREATE
		///		- GUILD_DELETE
		///		- GUILD_ROLE_CREATE
		///		- GUILD_ROLE_UPDATE
		///		- GUILD_ROLE_DELETE
		///		- CHANNEL_CREATE
		///		- CHANNEL_UPDATE
		///		- CHANNEL_DELETE
		///		- CHANNEL_PINS_UPDATE
		/// </summary>
		GUILDS = 1,
		
		/// <summary>
		///     - GUILD_MEMBER_ADD
		///		- GUILD_MEMBER_UPDATE
		///		- GUILD_MEMBER_REMOVE
		/// <remarks>You need to be whitelisted to use this, otherwise you will receive an error while connecting.</remarks>
		/// </summary>
		GUILD_MEMBERS = 1 << 1,
		
		/// <summary>
		///     - GUILD_BAN_ADD
		///		- GUILD_BAN_REMOVE
		/// </summary>
		GUILD_BANS = 1 << 2,
		
		/// <summary>
		///     - GUILD_EMOJIS_UPDATE
		/// </summary>
		GUILD_EMOJIS = 1 << 3,
		
		/// <summary>
		///     - GUILD_INTEGRATIONS_UPDATE
		/// </summary>
		GUILD_INTEGRATIONS = 1 << 4,
		
		/// <summary>
		///     - WEBHOOKS_UPDATE
		/// </summary>
		GUILD_WEBHOOKS = 1 << 5,
		
		/// <summary>
		///     - INVITE_CREATE
		///		- INVITE_DELETE
		/// </summary>
		GUILD_INVITES = 1 << 6,
		
		/// <summary>
		///     - VOICE_STATE_UPDATE
		/// </summary>
		GUILD_VOICE_STATES = 1 << 7,
		
		/// <summary>
		///     - PRESENCE_UPDATE
		/// <remarks>You need to be whitelisted to use this, otherwise you will receive an error while connecting.</remarks>
		/// </summary>
		GUILD_PRESENCES = 1 << 8,
		
		/// <summary>
		///     - MESSAGE_CREATE
		///		- MESSAGE_UPDATE
		///		- MESSAGE_DELETE
		/// </summary>
		GUILD_MESSAGES = 1 << 9,
		
		/// <summary>
		///     - MESSAGE_REACTION_ADD
		///		- MESSAGE_REACTION_REMOVE
		///		- MESSAGE_REACTION_REMOVE_ALL
		///		- MESSAGE_REACTION_REMOVE_EMOJI
		/// </summary>
		GUILD_MESSAGE_REACTIONS = 1 << 10,
		
		/// <summary>
		///     - TYPING_START
		/// </summary>
		GUILD_MESSAGE_TYPING = 1 << 11,
		
		/// <summary>
		///     - CHANNEL_CREATE
		///		- MESSAGE_CREATE
		///		- MESSAGE_UPDATE
		///		- MESSAGE_DELETE
		/// </summary>
		DIRECT_MESSAGES = 1 << 12,
		
		/// <summary>
		///     - MESSAGE_REACTION_ADD
		///		- MESSAGE_REACTION_REMOVE
		///		- MESSAGE_REACTION_REMOVE_ALL
		///		- MESSAGE_REACTION_REMOVE_EMOJI
		/// </summary>
		DIRECT_MESSAGE_REACTIONS = 1 << 13,
		
		/// <summary>
		///     - TYPING_START
		/// </summary>
		DIRECT_MESSAGE_TYPING = 1 << 14
	}
}
