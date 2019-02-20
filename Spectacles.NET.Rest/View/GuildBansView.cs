using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildBansView : View
	{
		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildBan(GuildID, ID) : APIEndpoints.GuildBans(GuildID))}";
		
		private string GuildID { get; }
		
		public GuildBansView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}