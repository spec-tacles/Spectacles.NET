using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildWidgetView : View
	{
		public GuildWidgetView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		protected override string Route
			=> $"{APIEndpoints.GuildWidgetImage(GuildId)}";

		private string GuildId { get; }
	}
}
