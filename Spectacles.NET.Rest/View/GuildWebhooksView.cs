using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildWebhooksView : View
	{
		public GuildWebhooksView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		protected override string Route
			=> $"{APIEndpoints.GuildWebhooks(GuildId)}";

		private string GuildId { get; }
	}
}
