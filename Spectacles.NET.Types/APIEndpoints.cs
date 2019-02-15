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

		public const string Gateway = "/gateway";
		public const string BotGateway = Gateway + "/bot";
		public const string Guilds = "/guilds";
		public const string Channels = "/channels";
		public const string VoiceRegions = "/voice/regions";
		public const string CurrentUser = "/users/@me";
		public const string CurrentUserGuild = CurrentUser + "/guilds";
		public const string CurrentUserDMs = CurrentUser + "/channels";
		public const string CurrentUserConnections = CurrentUser + "/connections";
		public const string Webhooks = "/webhooks";

		public static string Guild(long id)
			=> $"{Guilds}/{id}";

		public static string GuildChannels(long guildID)
			=> $"{Guild(guildID)}/channels";

		public static string GuildMembers(long guildID)
			=> $"{Guild(guildID)}/members";

		public static string GuildMember(long guildID, long memberID)
			=> $"{GuildMembers(guildID)}/{memberID}";

		public static string CurrentGuildMember(long guildID)
			=> $"{GuildMembers(guildID)}/members/@me";

		public static string GuildMemberRole(long guildID, long memberID, long roleID)
			=> $"{GuildMember(guildID, memberID)}/roles/{roleID}";

		public static string GuildBans(long guildID)
			=> $"{Guild(guildID)}/bans";

		public static string GuildBan(long guildID, long userID)
			=> $"{GuildBans(guildID)}/{userID}";

		public static string GuildRole(long guildID, long roleID)
			=> $"{Guild(guildID)}/role/{roleID}";

		public static string GuildPrune(long guildID)
			=> $"{Guild(guildID)}/prune";

		public static string GuildVoiceRegion(long guildID)
			=> $"{Guild(guildID)}/regions";

		public static string GuildInvites(long guildID)
			=> $"{Guild(guildID)}/invites";

		public static string GuildIntegrations(long guildID)
			=> $"{Guild(guildID)}/integrations";

		public static string GuildIntegration(long guildID, long integrationID)
			=> $"{GuildIntegrations(guildID)}/{integrationID}";

		public static string GuildEmbed(long guildID)
			=> $"{Guild(guildID)}/embed";

		public static string GuildVanityURL(long guildID)
			=> $"{Guild(guildID)}/vanity-url";

		public static string GuildWidgetImage(long guildID)
			=> $"{Guild(guildID)}/widget.png";

		public static string Invite(long inviteID)
			=> $"/invites/{inviteID}";

		public static string GuildAuditLogs(long guildID)
			=> $"{Guild(guildID)}/audit-logs";

		public static string Channel(long channelID)
			=> $"{Channels}/{channelID}";

		public static string ChannelMessages(long channelID)
			=> $"{Channel(channelID)}/messages";

		public static string Message(long channelID, long messageID)
			=> $"{ChannelMessages(channelID)}/{messageID}";

		public static string MessageReactions(long channelID, long messageID)
			=> $"{Message(channelID, messageID)}/reaction";

		public static string MessageReaction(long channelID, long messageID, string emoji)
			=> $"{MessageReactions(channelID, messageID)}/{emoji}";

		public static string BulkDelete(long channelID)
			=> $"{Channel(channelID)}/bulk-delete";

		public static string ChannelPermission(long channelID, long overwriteID)
			=> $"{Channel(channelID)}/permissions/{overwriteID}";

		public static string ChannelInvite(long channelID)
			=> $"{Channel(channelID)}/invites";

		public static string ChannelTyping(long channelID)
			=> $"{Channel(channelID)}/typing";

		public static string ChannelPins(long channelID)
			=> $"{Channel(channelID)}/pins";

		public static string ChannelPin(long channelID, long messageID)
			=> $"{ChannelPins(channelID)}/{messageID}";

		public static string ChannelRecipient(long channelID, long userID)
			=> $"{Channel(channelID)}/recipients/{userID}";

		public static string GuildEmojis(long guildID)
			=> $"{Guild(guildID)}/emojis";

		public static string GuildEmoji(long guildID, long emojiID)
			=> $"{GuildEmojis(guildID)}/{emojiID}";

		public static string User(long userID)
			=> $"/users/{userID}";

		public static string UserGuild(long guildID)
			=> $"{Guilds}/{guildID}";

		public static string ChannelWebhooks(long channelID)
			=> $"{Channel(channelID)}/webhooks";

		public static string GuildWebhooks(long guildID)
			=> $"{Guild(guildID)}/webhooks";

		public static string Webhook(long webhookID)
			=> $"{Webhooks}/{webhookID}";
	}
}