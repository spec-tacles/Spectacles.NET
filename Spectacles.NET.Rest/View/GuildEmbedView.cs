using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildEmbedView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildEmbed(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildEmbedView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}