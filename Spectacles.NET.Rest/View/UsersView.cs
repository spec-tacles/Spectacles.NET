using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class UsersView : View
	{
		public UsersView(RestClient client) : base(client)
		{
		}

		public CurrentUserGuildsView CurrentUserGuilds
			=> new CurrentUserGuildsView(Client);

		public CurrentUserChannelsView CurrentUserChannels
			=> new CurrentUserChannelsView(Client);

		public CurrentUserConnectionsView CurrentUserConnections
			=> new CurrentUserConnectionsView(Client);

		public CurrentUserDMView CurrentUserDMs
			=> new CurrentUserDMView(Client);

		public UsersView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public UsersView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.User(ID)}";
	}
}
