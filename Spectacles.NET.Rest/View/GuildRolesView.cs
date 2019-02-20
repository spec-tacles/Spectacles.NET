using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildRolesView : View
	{
		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildRole(GuildID, ID) : APIEndpoints.GuildRoles(GuildID))}";
		
		private string GuildID { get; }
		
		public GuildRolesView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}