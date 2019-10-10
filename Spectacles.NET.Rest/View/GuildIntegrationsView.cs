using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildIntegrationsView : View
	{
		public GuildIntegrationsView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildIntegrationSyncView Sync
			=> new GuildIntegrationSyncView(Client, GuildId, Id);

		public GuildIntegrationsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildIntegrationsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.GuildIntegration(GuildId, Id) : APIEndpoints.GuildIntegrations(GuildId))}";

		private string GuildId { get; }
	}
}
