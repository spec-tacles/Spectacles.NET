using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildRolesView : View
	{
		public GuildRolesView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildRolesView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildRolesView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.GuildRole(GuildId, Id) : APIEndpoints.GuildRoles(GuildId))}";

		private string GuildId { get; }
	}
}
