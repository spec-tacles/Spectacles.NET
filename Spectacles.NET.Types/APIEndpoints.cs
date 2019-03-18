// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Constants for the Endpoints of the Discord API.
	/// </summary>
	public class APIEndpoints
	{
		public const string BaseURL = "https://discordapp.com/api";

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

		public static string GuildChannels(string guildID)
			=> $"{Guild(guildID)}/channels";

		public static string GuildMembers(string guildID)
			=> $"{Guild(guildID)}/members";

		public static string GuildMember(string guildID, string memberID)
			=> $"{GuildMembers(guildID)}/{memberID}";

		public static string CurrentGuildMember(string guildID)
			=> $"{GuildMembers(guildID)}/members/@me";

		public static string GuildMemberRole(string guildID, string memberID, string roleID)
			=> $"{GuildMember(guildID, memberID)}/roles/{roleID}";

		public static string GuildBans(string guildID)
			=> $"{Guild(guildID)}/bans";

		public static string GuildBan(string guildID, string userID)
			=> $"{GuildBans(guildID)}/{userID}";

		public static string GuildRoles(string guildID)
			=> $"{Guild(guildID)}/roles";

		public static string GuildRole(string guildID, string roleID)
			=> $"{GuildRoles(guildID)}/{roleID}";

		public static string GuildPrune(string guildID)
			=> $"{Guild(guildID)}/prune";

		public static string GuildVoiceRegion(string guildID)
			=> $"{Guild(guildID)}/regions";

		public static string GuildInvites(string guildID)
			=> $"{Guild(guildID)}/invites";

		public static string GuildIntegrations(string guildID)
			=> $"{Guild(guildID)}/integrations";

		public static string GuildIntegration(string guildID, string integrationID)
			=> $"{GuildIntegrations(guildID)}/{integrationID}";

		public static string GuildEmbed(string guildID)
			=> $"{Guild(guildID)}/embed";

		public static string GuildVanityURL(string guildID)
			=> $"{Guild(guildID)}/vanity-url";

		public static string GuildWidgetImage(string guildID)
			=> $"{Guild(guildID)}/widget.png";

		public static string Invite(string inviteID)
			=> $"invites/{inviteID}";

		public static string GuildAuditLogs(string guildID)
			=> $"{Guild(guildID)}/audit-logs";

		public static string Channel(string channelID)
			=> $"{Channels}/{channelID}";

		public static string ChannelMessages(string channelID)
			=> $"{Channel(channelID)}/messages";

		public static string Message(string channelID, string messageID)
			=> $"{ChannelMessages(channelID)}/{messageID}";

		public static string MessageReactions(string channelID, string messageID)
			=> $"{Message(channelID, messageID)}/reactions";

		public static string MessageReaction(string channelID, string messageID, string emoji)
			=> $"{MessageReactions(channelID, messageID)}/{emoji}";

		public static string BulkDelete(string channelID)
			=> $"{Channel(channelID)}/bulk-delete";

		public static string ChannelPermission(string channelID, string overwriteID)
			=> $"{Channel(channelID)}/permissions/{overwriteID}";

		public static string ChannelInvites(string channelID)
			=> $"{Channel(channelID)}/invites";

		public static string ChannelTyping(string channelID)
			=> $"{Channel(channelID)}/typing";

		public static string ChannelPins(string channelID)
			=> $"{Channel(channelID)}/pins";

		public static string ChannelPin(string channelID, string messageID)
			=> $"{ChannelPins(channelID)}/{messageID}";

		public static string ChannelRecipient(string channelID, string userID)
			=> $"{Channel(channelID)}/recipients/{userID}";

		public static string GuildEmojis(string guildID)
			=> $"{Guild(guildID)}/emojis";

		public static string GuildEmoji(string guildID, string emojiID)
			=> $"{GuildEmojis(guildID)}/{emojiID}";

		public static string User(string userID)
			=> $"users/{userID}";

		public static string UserGuild(string guildID)
			=> $"{Guilds}/{guildID}";

		public static string ChannelWebhooks(string channelID)
			=> $"{Channel(channelID)}/webhooks";

		public static string GuildWebhooks(string guildID)
			=> $"{Guild(guildID)}/webhooks";

		public static string Webhook(string webhookID)
			=> $"{Webhooks}/{webhookID}";
	}
}