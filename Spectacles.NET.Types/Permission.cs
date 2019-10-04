// ReSharper disable UnusedMember.Global

using System;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Permissions in Discord are a way to limit and grant certain abilities to users. A set of base permissions can be
	///     configured at the guild level for different roles. When these roles are attached to users, they grant or revoke
	///     specific privileges within the guild. Along with the guild-level permissions, Discord also supports permission
	///     overwrites that can be assigned to individual guild roles or guild members on a per-channel basis.
	///     Permissions are stored within a 53-bit integer and are calculated using bitwise operations. The total permissions
	///     integer can be determined by ORing together each individual value, and flags can be checked using AND operations.
	/// </summary>
	[Flags]
	public enum Permission
	{
		/// <summary>
		/// No permissions
		/// </summary>
		NONE = 0x00000000,
		
		/// <summary>
		/// Allows creation of instant invites
		/// </summary>
		CREATE_INSTANT_INVITE = 0x00000001,
		
		/// <summary>
		/// Allows kicking members
		/// </summary>
		KICK_MEMBERS = 0x00000002,
		
		/// <summary>
		/// Allows banning members
		/// </summary>
		BAN_MEMBERS = 0x00000004,
		
		/// <summary>
		/// Allows all permissions and bypasses channel permission overwrites
		/// </summary>
		ADMINISTRATOR = 0x00000008,
		
		/// <summary>
		/// Allows management and editing of channels
		/// </summary>
		MANAGE_CHANNELS = 0x00000010,
		
		/// <summary>
		/// Allows management and editing of the guild
		/// </summary>
		MANAGE_GUILD = 0x00000020,
		
		/// <summary>
		/// Allows for the addition of reactions to messages
		/// </summary>
		ADD_REACTIONS = 0x00000040,
		
		/// <summary>
		/// Allows for viewing of audit logs
		/// </summary>
		VIEW_AUDIT_LOG = 0x00000080,
		
		/// <summary>
		/// Allows for using priority speaker in a voice channel
		/// </summary>
		PRIORITY_SPEAKER = 0x00000100,
		
		/// <summary>
		/// 	Allows the user to go live
		/// </summary>
		STREAM = 0x00000200,
		
		/// <summary>
		/// Allows guild members to view a channel, which includes reading messages in text channels
		/// </summary>
		VIEW_CHANNEL = 0x00000400,
		
		/// <summary>
		/// Allows for sending messages in a channel
		/// </summary>
		SEND_MESSAGES = 0x00000800,
		
		/// <summary>
		/// Allows for sending of /tts messages
		/// </summary>
		SEND_TTS_MESSAGES = 0x00001000,
		
		/// <summary>
		/// Allows for deletion of other users messages
		/// </summary>
		MANAGE_MESSAGES = 0x00002000,
		
		/// <summary>
		/// Links sent by users with this permission will be auto-embedded
		/// </summary>
		EMBED_LINKS = 0x00004000,
		
		/// <summary>
		/// Allows for uploading images and files
		/// </summary>
		ATTACH_FILES = 0x00008000,
		
		/// <summary>
		/// Allows for reading of message history
		/// </summary>
		READ_MESSAGE_HISTORY = 0x00010000,
		
		/// <summary>
		/// Allows for using the @everyone tag to notify all users in a channel, and the @here tag to notify all online users in a channel
		/// </summary>
		MENTION_EVERYONE = 0x00020000,
		
		/// <summary>
		/// Allows the usage of custom emojis from other servers
		/// </summary>
		USE_EXTERNAL_EMOJIS = 0x00040000,

		/// <summary>
		/// All permissions related to Text Channel
		/// </summary>
		ALL_TEXT = VIEW_CHANNEL | SEND_MESSAGES | SEND_TTS_MESSAGES | MANAGE_MESSAGES | EMBED_LINKS | ATTACH_FILES |
		           READ_MESSAGE_HISTORY | MENTION_EVERYONE | USE_EXTERNAL_EMOJIS,

		/// <summary>
		/// Allows for joining of a voice channel
		/// </summary>
		CONNECT = 0x00100000,
		
		/// <summary>
		/// Allows for speaking in a voice channel
		/// </summary>
		SPEAK = 0x00200000,
		
		/// <summary>
		/// Allows for muting members in a voice channel
		/// </summary>
		MUTE_MEMBERS = 0x00400000,
		
		/// <summary>
		/// Allows for deafening of members in a voice channel
		/// </summary>
		DEAFEN_MEMBERS = 0x00800000,
		
		/// <summary>
		/// Allows for moving of members between voice channels
		/// </summary>
		MOVE_MEMBERS = 0x01000000,
		
		/// <summary>
		/// Allows for using voice-activity-detection in a voice channel
		/// </summary>
		USE_VAD = 0x02000000,
		
		/// <summary>
		/// All permissions related to Voice Channel
		/// </summary>
		ALL_VOICE = CONNECT | SPEAK | MUTE_MEMBERS | DEAFEN_MEMBERS | MOVE_MEMBERS | USE_VAD,

		/// <summary>
		/// Allows for modification of own nickname
		/// </summary>
		CHANGE_NICKNAME = 0x04000000,
		
		/// <summary>
		/// Allows for modification of other users nicknames
		/// </summary>
		MANAGE_NICKNAMES = 0x08000000,
		
		/// <summary>
		/// Allows management and editing of roles
		/// </summary>
		MANAGE_ROLES = 0x10000000,
		
		/// <summary>
		/// Allows management and editing of webhooks
		/// </summary>
		MANAGE_WEBHOOKS = 0x20000000,
		
		/// <summary>
		/// Allows management and editing of emojis
		/// </summary>
		MANAGE_EMOJIS = 0x40000000,

		/// <summary>
		/// Default permissions
		/// </summary>
		DEFAULT = CHANGE_NICKNAME | USE_VAD | SPEAK | CONNECT | USE_EXTERNAL_EMOJIS | MENTION_EVERYONE |
		          READ_MESSAGE_HISTORY | ATTACH_FILES | EMBED_LINKS | SEND_TTS_MESSAGES | SEND_MESSAGES | VIEW_CHANNEL |
		          CREATE_INSTANT_INVITE,

		/// <summary>
		/// All permissions
		/// </summary>
		ALL = CREATE_INSTANT_INVITE | KICK_MEMBERS | BAN_MEMBERS | ADMINISTRATOR | MANAGE_CHANNELS | MANAGE_GUILD |
		      ADD_REACTIONS | VIEW_AUDIT_LOG | PRIORITY_SPEAKER | ALL_TEXT | ALL_VOICE | CHANGE_NICKNAME |
		      MANAGE_NICKNAMES | MANAGE_ROLES | MANAGE_WEBHOOKS | MANAGE_EMOJIS
	}
}
