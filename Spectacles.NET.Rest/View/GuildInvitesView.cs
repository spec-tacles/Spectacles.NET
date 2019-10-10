using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildInvitesView : View
	{
		public GuildInvitesView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildInvitesView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildInvitesView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildInvites(GuildId)}";

		private string GuildId { get; }
	}
}
