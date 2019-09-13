using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildIntegrationSyncView : View
	{
		public GuildIntegrationSyncView(RestClient client, string guildID, string integrationID) : base(client)
		{
			GuildID = guildID;
			IntegrationID = integrationID;
		}

		public GuildIntegrationSyncView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildIntegrationSyncView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildIntegration(GuildID, IntegrationID)}/sync";

		private string GuildID { get; }

		private string IntegrationID { get; }
	}
}
