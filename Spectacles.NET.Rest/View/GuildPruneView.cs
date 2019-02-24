using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildPruneView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildPrune(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildPruneView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}