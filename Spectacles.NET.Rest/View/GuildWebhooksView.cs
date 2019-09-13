using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildWebhooksView : View
	{
		public GuildWebhooksView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		protected override string Route
			=> $"{APIEndpoints.GuildWebhooks(GuildID)}";

		private string GuildID { get; }
	}
}
