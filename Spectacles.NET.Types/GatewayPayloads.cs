using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildBanAdd event.
	/// </summary>
	public class GuildBanAddPayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the banned user
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}

	/// <summary>
	///     The payload for the GuildBanRemove event.
	/// </summary>
	public class GuildBanRemovePayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the unbanned user
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}

	/// <summary>
	///     The payload for the GuildEmojisUpdate event.
	/// </summary>
	public class GuildEmojisUpdate
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     array of emojis
		/// </summary>
		[JsonProperty("emojis")]
		public Emoji[] Emojis { get; set; }
	}

	/// <summary>
	///     The payload for the GuildIntegrationsUpdate event.
	/// </summary>
	public class GuildIntegrationsUpdatePayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}

	/// <summary>
	///     The payload for the GuildMemberAdd event.
	/// </summary>
	/// <inheritdoc />
	public class GuildMemberAddPayload : GuildMember
	{
		/// <summary>
		///     ID of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}

	/// <summary>
	///     The Payload for the GuildMemberRemove event.
	/// </summary>
	public class GuildMemberRemovePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the user who was removed
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
	}

	/// <summary>
	///     The Payload for the GuildMemberUpdate event.
	/// </summary>
	public class GuildMemberUpdatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the user who was removed
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <summary>
		///     user role ids
		/// </summary>
		[JsonProperty("roles")]
		public string[] Roles { get; set; }

		/// <summary>
		///     nickname of the user in the guild
		/// </summary>
		[JsonProperty("nick")]
		public string Nickname { get; set; }
	}

	/// <summary>
	///     The Payload for the GuildMemberChunk event.
	/// </summary>
	public class GuildMemberChunkPayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     set of guild members
		/// </summary>
		[JsonProperty("members")]
		public GuildMember[] GuildMembers { get; set; }
	}

	/// <summary>
	///     The Payload for the GuildRoleCreate event.
	/// </summary>
	public class GuildRoleCreatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the role created
		/// </summary>
		[JsonProperty("role")]
		public Role Role { get; set; }
	}

	/// <summary>
	///     The Payload for the GuildRoleUpdate event.
	/// </summary>
	public class GuildRoleUpdatePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the role updated
		/// </summary>
		[JsonProperty("role")]
		public Role Role { get; set; }
	}

	/// <summary>
	///     The Payload for the GuildRoleDelete event.
	/// </summary>
	public class GuildRoleDeletePayload
	{
		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the deleted role id
		/// </summary>
		[JsonProperty("role_id")]
		public string RoleID { get; set; }
	}

	/// <summary>
	///     The Payload for the MessageUpdate event.
	/// </summary>
	public class MessageUpdatePayload
	{
		/// <summary>
		///     id of the message
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     id of the channel the message was sent in
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     id of the guild the message was sent in
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the author of this message
		/// </summary>
		[JsonProperty("author")]
		public User Author { get; set; }

		/// <summary>
		///     member properties for this message's author
		/// </summary>
		[JsonProperty("member")]
		public GuildMember Member { get; set; }

		/// <summary>
		///     contents of the message
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }

		/// <summary>
		///     when this message was sent
		/// </summary>
		[JsonProperty("timestamp")]
		public DateTime? Timestamp { get; set; }

		/// <summary>
		///     when this message was edited (or null if never)
		/// </summary>
		[JsonProperty("edited_timestamp")]
		public DateTime? EditedTimestamp { get; set; }

		/// <summary>
		///     whether this was a TTS message
		/// </summary>
		[JsonProperty("tts")]
		public bool? TTS { get; set; }

		/// <summary>
		///     whether this message mentions everyone
		/// </summary>
		[JsonProperty("mention_everyone")]
		public bool? MentionEveryone { get; set; }

		/// <summary>
		///     users specifically mentioned in the message
		/// </summary>
		[JsonProperty("mentions")]
		public List<MentionUser> Mentions { get; set; }

		/// <summary>
		///     roles specifically mentioned in this message
		/// </summary>
		[JsonProperty("mention_roles")]
		public List<string> RoleMentions { get; set; }

		/// <summary>
		///     any attached files
		/// </summary>
		[JsonProperty("attachments")]
		public List<Attachment> Attachments { get; set; }

		/// <summary>
		///     any embedded content
		/// </summary>
		[JsonProperty("embeds")]
		public List<Embed> Embeds { get; set; }

		/// <summary>
		///     reactions to the message
		/// </summary>
		[JsonProperty("reactions")]
		public List<Reaction> Reactions { get; set; }

		/// <summary>
		///     used for validating a message was sent
		/// </summary>
		[JsonProperty("nonce")]
		public string Nonce { get; set; }

		/// <summary>
		///     whether this message is pinned
		/// </summary>
		[JsonProperty("pinned")]
		public bool? Pinned { get; set; }

		// ReSharper disable once CommentTypo
		/// <summary>
		///     if the message is generated by a webhook, this is the webhook's id
		/// </summary>
		[JsonProperty("webhook_id")]
		public string WebhookId { get; set; }

		/// <summary>
		///     <see cref="MessageType" />
		/// </summary>
		[JsonProperty("type")]
		public MessageType? Type { get; set; }

		/// <summary>
		///     sent with Rich Presence-related chat embeds
		/// </summary>
		[JsonProperty("activity")]
		public MessageActivity Activity { get; set; }

		/// <summary>
		///     sent with Rich Presence-related chat embeds
		/// </summary>
		[JsonProperty("application")]
		public MessageApplication Application { get; set; }
	}

	/// <summary>
	///     The Payload for the MessageDelete event.
	/// </summary>
	public class MessageDeletePayload
	{
		/// <summary>
		///     the id of the message
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}

	/// <summary>
	///     The Payload for the MessageDeleteBulk event.
	/// </summary>
	public class MessageDeleteBulkPayload
	{
		/// <summary>
		///     the ids of the messages
		/// </summary>
		[JsonProperty("ids")]
		public string[] Ids { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}

	/// <summary>
	///     The Payload for the MessageReactionAdd events.
	/// </summary>
	public class MessageReactionAddPayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		/// <summary>
		///     the ids of the message
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the emoji used to react
		/// </summary>
		[JsonProperty("emoji")]
		public Emoji Emoji { get; set; }
	}

	/// <summary>
	///     The Payload for the MessageReactionRemove events.
	/// </summary>
	public class MessageReactionRemovePayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		/// <summary>
		///     the ids of the message
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the emoji used to react
		/// </summary>
		[JsonProperty("emoji")]
		public Emoji Emoji { get; set; }
	}

	/// <summary>
	///     The Payload for the MessageDeleteBulk event.
	/// </summary>
	public class MessageReactionRemoveAllPayload
	{
		/// <summary>
		///     the ids of the message
		/// </summary>
		[JsonProperty("message_id")]
		public string MessageId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}

	/// <summary>
	///     The Payload for the PresenceUpdate event.
	/// </summary>
	public class PresenceUpdatePayload
	{
		/// <summary>
		///     the user presence is being updated for
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <summary>
		///     roles this user is in
		/// </summary>
		[JsonProperty("roles")]
		public string[] Roles { get; set; }

		/// <summary>
		///     null, or the user's current activity
		/// </summary>
		[JsonProperty("game")]
		public Activity Game { get; set; }

		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     either "idle", "dnd", "online", or "offline"
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		///     user's current activities
		/// </summary>
		[JsonProperty("activities")]
		public Activity[] Activities { get; set; }

		/// <summary>
		///     user's platform-dependent status
		/// </summary>
		[JsonProperty("client_status")]
		public ClientStatus ClientStatus { get; set; }
	}

	/// <summary>
	///     The Payload for the TypingStart event.
	/// </summary>
	public class TypingStartPayload
	{
		/// <summary>
		///     the id of the user
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     unix time (in seconds) of when the user started typing
		/// </summary>
		[JsonProperty("timestamp")]
		public long Timestamp { get; set; }
	}

	/// <summary>
	///     The Payload for the VoiceServerUpdate event.
	/// </summary>
	public class VoiceServerUpdatePayload
	{
		/// <summary>
		///     voice connection token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		///     the guild this voice server update is for
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     the voice server host
		/// </summary>
		[JsonProperty("endpoint")]
		public string Endpoint { get; set; }
	}

	/// <summary>
	///     The Payload for the WebhookUpdate event.
	/// </summary>
	public class WebhookUpdatePayload
	{
		/// <summary>
		///     the id of the channel
		/// </summary>
		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
	}
}
