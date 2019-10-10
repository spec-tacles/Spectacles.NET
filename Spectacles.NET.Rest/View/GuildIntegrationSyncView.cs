using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildIntegrationSyncView : View
	{
		public GuildIntegrationSyncView(RestClient client, string guildId, string integrationId) : base(client)
		{
			GuildId = guildId;
			IntegrationId = integrationId;
		}

		public GuildIntegrationSyncView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildIntegrationSyncView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildIntegration(GuildId, IntegrationId)}/sync";

		private string GuildId { get; }

		private string IntegrationId { get; }
	}
}
