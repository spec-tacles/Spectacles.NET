using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildMembersView : View
	{
		public GuildMemberRolesView Roles
			=> new GuildMemberRolesView(Client, GuildID, ID);
		
		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildMember(GuildID, ID) : APIEndpoints.GuildMembers(GuildID))}";

		private string GuildID { get; }
		
		public GuildMembersView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}