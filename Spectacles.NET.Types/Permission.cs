// ReSharper disable UnusedMember.Global

using System;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Permissions in Discord are a way to limit and grant certain abilities to users. A set of base permissions can be configured at the guild level for different roles. When these roles are attached to users, they grant or revoke specific privileges within the guild. Along with the guild-level permissions, Discord also supports permission overwrites that can be assigned to individual guild roles or guild members on a per-channel basis.
	/// Permissions are stored within a 53-bit integer and are calculated using bitwise operations. The total permissions integer can be determined by ORing together each individual value, and flags can be checked using AND operations.
	/// </summary>
	[Flags]
	public enum Permission
	{
		NONE = 0x00000000,
		CREATE_INSTANT_INVITE = 0x00000001,
		KICK_MEMBERS = 0x00000002,
		BAN_MEMBERS = 0x00000004,
		ADMINISTRATOR = 0x00000008,
		MANAGE_CHANNELS = 0x00000010,
		MANAGE_GUILD = 0x00000020,
		ADD_REACTIONS = 0x00000040,
		VIEW_AUDIT_LOG = 0x00000080,
		PRIORITY_SPEAKER = 0x00000100,

		VIEW_CHANNEL = 0x00000400,
		SEND_MESSAGES = 0x00000800,
		SEND_TTS_MESSAGES = 0x00001000,
		MANAGE_MESSAGES = 0x00002000,
		EMBED_LINKS = 0x00004000,
		ATTACH_FILES = 0x00008000,
		READ_MESSAGE_HISTORY = 0x00010000,
		MENTION_EVERYONE = 0x00020000,
		USE_EXTERNAL_EMOJIS = 0x00040000,
		ALL_TEXT = VIEW_CHANNEL | SEND_MESSAGES | SEND_TTS_MESSAGES | MANAGE_MESSAGES | EMBED_LINKS | ATTACH_FILES | READ_MESSAGE_HISTORY | MENTION_EVERYONE | USE_EXTERNAL_EMOJIS,

		CONNECT = 0x00100000,
		SPEAK = 0x00200000,
		MUTE_MEMBERS = 0x00400000,
		DEAFEN_MEMBERS = 0x00800000,
		MOVE_MEMBERS = 0x01000000,
		USE_VAD = 0x02000000,
		ALL_VOICE = CONNECT | SPEAK | MUTE_MEMBERS | DEAFEN_MEMBERS | MOVE_MEMBERS | USE_VAD,

		CHANGE_NICKNAME = 0x04000000,
		MANAGE_NICKNAMES = 0x08000000,
		MANAGE_ROLES = 0x10000000,
		MANAGE_WEBHOOKS = 0x20000000,
		MANAGE_EMOJIS = 0x40000000,
		
		DEFAULT = CHANGE_NICKNAME | USE_VAD | SPEAK | CONNECT | USE_EXTERNAL_EMOJIS | MENTION_EVERYONE | READ_MESSAGE_HISTORY | ATTACH_FILES | EMBED_LINKS | SEND_TTS_MESSAGES | SEND_MESSAGES | VIEW_CHANNEL | CREATE_INSTANT_INVITE,
		ALL = CREATE_INSTANT_INVITE | KICK_MEMBERS | BAN_MEMBERS | ADMINISTRATOR | MANAGE_CHANNELS | MANAGE_GUILD | ADD_REACTIONS | VIEW_AUDIT_LOG | PRIORITY_SPEAKER | ALL_TEXT | ALL_VOICE | CHANGE_NICKNAME | MANAGE_NICKNAMES | MANAGE_ROLES | MANAGE_WEBHOOKS | MANAGE_EMOJIS
	}
}