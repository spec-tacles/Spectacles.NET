using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildWidgetView : View
	{
		public GuildWidgetView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		protected override string Route
			=> $"{APIEndpoints.GuildWidgetImage(GuildID)}";

		private string GuildID { get; }
	}
}
