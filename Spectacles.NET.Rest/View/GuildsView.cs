using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildsView : View
	{
		public GuildsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		public GuildChannelsView Channels
			=> new GuildChannelsView(Client, ID);
		
		public GuildMembersView Members
			=> new GuildMembersView(Client, ID);
		
		public GuildAuditLogsView AuditLogs
			=> new GuildAuditLogsView(Client, ID);
		
		public GuildBansView Bans
			=> new GuildBansView(Client, ID);
		
		public GuildRolesView Roles
			=> new GuildRolesView(Client, ID);
		
		public GuildPruneView Prune
			=> new GuildPruneView(Client, ID);
		
		public GuildRegionsView Region
			=> new GuildRegionsView(Client, ID);
		
		public GuildInvitesView Invites
			=> new GuildInvitesView(Client, ID);
		
		public GuildIntegrationsView Integrations
			=> new GuildIntegrationsView(Client, ID);
		
		public GuildEmbedView Embed
			=> new GuildEmbedView(Client, ID);
		
		public GuildVanityURLView VanityURL
			=> new GuildVanityURLView(Client, ID);
		
		public GuildWidgetView Widget
			=> new GuildWidgetView(Client, ID);
		
		public CurrentGuildMemberNickView CurrentGuildMemberNick
			=> new CurrentGuildMemberNickView(Client, ID);
		
		public GuildEmojisView Emojis
			=> new GuildEmojisView(Client, ID);
		
		protected override string Route 
			=> $"{(ID == null ? APIEndpoints.Guilds : APIEndpoints.Guild(ID))}";

		public GuildsView(RestClient client) : base(client)
		{
		}
	}
}