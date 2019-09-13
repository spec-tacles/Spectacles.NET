using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildBansView : View
	{
		public GuildBansView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		public GuildBansView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildBansView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildBan(GuildID, ID) : APIEndpoints.GuildBans(GuildID))}";

		private string GuildID { get; }
	}
}
