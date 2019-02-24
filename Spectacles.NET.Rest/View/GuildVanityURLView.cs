using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildVanityURLView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildVanityURL(GuildID)}";
			
		private string GuildID { get; }
		
		public GuildVanityURLView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}