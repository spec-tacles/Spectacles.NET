using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildMemberRolesView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildMemberRole(GuildID, UserID, ID)}";
		
		private string GuildID { get; }
		
		private string UserID { get; }
		
		public GuildMemberRolesView(RestClient client, string guildID, string userID) : base(client)
		{
			GuildID = guildID;
			UserID = userID;
		}
	}
}