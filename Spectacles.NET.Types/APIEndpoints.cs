// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Constants for the Endpoints of the Discord API.
	/// </summary>
	public class APIEndpoints
	{
		public const string APIBaseURL = "https://discordapp.com/api/";
		public const string CDNBaseURL = "https://cdn.discordapp.com/";
		public const string InviteBaseURL = "https://discord.gg";

		public const string Gateway = "gateway";
		public const string BotGateway = Gateway + "/bot";
		public const string Guilds = "guilds";
		public const string Channels = "channels";
		public const string VoiceRegions = "voice/regions";
		public const string CurrentUser = "users/@me";
		public const string CurrentUserGuilds = CurrentUser + "/guilds";
		public const string CurrentUserDMs = CurrentUser + "/channels";
		public const string CurrentUserConnections = CurrentUser + "/connections";
		public const string Webhooks = "webhooks";

		public static string Guild(string id)
			=> $"{Guilds}/{id}";

		public static string GuildChannels(string guildId)
			=> $"{Guild(guildId)}/channels";

		public static string GuildMembers(string guildId)
			=> $"{Guild(guildId)}/members";

		public static string GuildMember(string guildId, string memberId)
			=> $"{GuildMembers(guildId)}/{memberId}";

		public static string CurrentGuildMember(string guildId)
			=> $"{GuildMembers(guildId)}/members/@me";

		public static string GuildMemberRole(string guildId, string memberId, string roleId)
			=> $"{GuildMember(guildId, memberId)}/roles/{roleId}";

		public static string GuildBans(string guildId)
			=> $"{Guild(guildId)}/bans";

		public static string GuildBan(string guildId, string userId)
			=> $"{GuildBans(guildId)}/{userId}";

		public static string GuildRoles(string guildId)
			=> $"{Guild(guildId)}/roles";

		public static string GuildRole(string guildId, string roleId)
			=> $"{GuildRoles(guildId)}/{roleId}";

		public static string GuildPrune(string guildId)
			=> $"{Guild(guildId)}/prune";

		public static string GuildVoiceRegion(string guildId)
			=> $"{Guild(guildId)}/regions";

		public static string GuildInvites(string guildId)
			=> $"{Guild(guildId)}/invites";

		public static string GuildIntegrations(string guildId)
			=> $"{Guild(guildId)}/integrations";

		public static string GuildIntegration(string guildId, string integrationId)
			=> $"{GuildIntegrations(guildId)}/{integrationId}";

		public static string GuildEmbed(string guildId)
			=> $"{Guild(guildId)}/embed";

		public static string GuildVanityURL(string guildId)
			=> $"{Guild(guildId)}/vanity-url";

		public static string GuildWidgetImage(string guildId)
			=> $"{Guild(guildId)}/widget.png";

		public static string Invite(string inviteId)
			=> $"invites/{inviteId}";

		public static string GuildAuditLogs(string guildId)
			=> $"{Guild(guildId)}/audit-logs";

		public static string Channel(string channelId)
			=> $"{Channels}/{channelId}";

		public static string ChannelMessages(string channelId)
			=> $"{Channel(channelId)}/messages";

		public static string Message(string channelId, string messageId)
			=> $"{ChannelMessages(channelId)}/{messageId}";

		public static string MessageReactions(string channelId, string messageId)
			=> $"{Message(channelId, messageId)}/reactions";

		public static string MessageReaction(string channelId, string messageId, string emoji)
			=> $"{MessageReactions(channelId, messageId)}/{emoji}";

		public static string BulkDelete(string channelId)
			=> $"{Channel(channelId)}/bulk-delete";

		public static string ChannelPermission(string channelId, string overwriteId)
			=> $"{Channel(channelId)}/permissions/{overwriteId}";

		public static string ChannelInvites(string channelId)
			=> $"{Channel(channelId)}/invites";

		public static string ChannelTyping(string channelId)
			=> $"{Channel(channelId)}/typing";

		public static string ChannelPins(string channelId)
			=> $"{Channel(channelId)}/pins";

		public static string ChannelPin(string channelId, string messageId)
			=> $"{ChannelPins(channelId)}/{messageId}";

		public static string ChannelRecipient(string channelId, string userId)
			=> $"{Channel(channelId)}/recipients/{userId}";

		public static string GuildEmojis(string guildId)
			=> $"{Guild(guildId)}/emojis";

		public static string GuildEmoji(string guildId, string emojiId)
			=> $"{GuildEmojis(guildId)}/{emojiId}";

		public static string User(string userId)
			=> $"users/{userId}";

		public static string UserGuild(string guildId)
			=> $"{Guilds}/{guildId}";

		public static string ChannelWebhooks(string channelId)
			=> $"{Channel(channelId)}/webhooks";

		public static string GuildWebhooks(string guildId)
			=> $"{Guild(guildId)}/webhooks";

		public static string Webhook(string webhookId)
			=> $"{Webhooks}/{webhookId}";
	}
}
