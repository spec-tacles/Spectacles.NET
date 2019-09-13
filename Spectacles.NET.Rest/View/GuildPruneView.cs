using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildPruneView : View
	{
		public GuildPruneView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		protected override string Route
			=> $"{APIEndpoints.GuildPrune(GuildID)}";

		private string GuildID { get; }
	}
}
