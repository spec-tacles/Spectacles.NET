using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildRolesView : View
	{
		public GuildRolesView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		public GuildRolesView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildRolesView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildRole(GuildID, ID) : APIEndpoints.GuildRoles(GuildID))}";

		private string GuildID { get; }
	}
}
