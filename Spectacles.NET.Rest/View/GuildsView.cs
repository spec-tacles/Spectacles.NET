using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildsView : View
	{
		public GuildsView(RestClient client) : base(client)
		{
		}

		public GuildsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		public GuildChannelsView Channels
			=> new GuildChannelsView(Client, Id);

		public GuildMembersView Members
			=> new GuildMembersView(Client, Id);

		public GuildAuditLogsView AuditLogs
			=> new GuildAuditLogsView(Client, Id);

		public GuildBansView Bans
			=> new GuildBansView(Client, Id);

		public GuildRolesView Roles
			=> new GuildRolesView(Client, Id);

		public GuildPruneView Prune
			=> new GuildPruneView(Client, Id);

		public GuildRegionsView Region
			=> new GuildRegionsView(Client, Id);

		public GuildInvitesView Invites
			=> new GuildInvitesView(Client, Id);

		public GuildIntegrationsView Integrations
			=> new GuildIntegrationsView(Client, Id);

		public GuildEmbedView Embed
			=> new GuildEmbedView(Client, Id);

		public GuildVanityURLView VanityURL
			=> new GuildVanityURLView(Client, Id);

		public GuildWidgetView Widget
			=> new GuildWidgetView(Client, Id);

		public CurrentGuildMemberNickView CurrentGuildMemberNick
			=> new CurrentGuildMemberNickView(Client, Id);

		public GuildEmojisView Emojis
			=> new GuildEmojisView(Client, Id);

		protected override string Route
			=> $"{(Id == null ? APIEndpoints.Guilds : APIEndpoints.Guild(Id))}";
	}
}
