using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildWidgetView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildWidgetImage(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildWidgetView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}