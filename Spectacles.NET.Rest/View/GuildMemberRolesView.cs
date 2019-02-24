using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildMemberRolesView : View
	{
		public GuildMemberRolesView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildMemberRolesView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
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