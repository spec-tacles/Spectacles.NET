using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildIntegrationsView : View
	{
		public GuildIntegrationsView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		public GuildIntegrationSyncView Sync
			=> new GuildIntegrationSyncView(Client, GuildID, ID);

		public GuildIntegrationsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildIntegrationsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildIntegration(GuildID, ID) : APIEndpoints.GuildIntegrations(GuildID))}";

		private string GuildID { get; }
	}
}
