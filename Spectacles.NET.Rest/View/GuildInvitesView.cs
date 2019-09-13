using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildInvitesView : View
	{
		public GuildInvitesView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		public GuildInvitesView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildInvitesView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildInvites(GuildID)}";

		private string GuildID { get; }
	}
}
