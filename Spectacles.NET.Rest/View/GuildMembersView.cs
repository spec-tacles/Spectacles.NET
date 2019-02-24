using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildMembersView : View
	{
		public GuildMembersView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildMembersView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
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