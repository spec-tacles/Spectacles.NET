using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildMembersView : View
	{
		public GuildMembersView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildMembersView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildMembersView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		public GuildMemberRolesView Roles
			=> new GuildMemberRolesView(Client, GuildId, Id);

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.GuildMember(GuildId, Id) : APIEndpoints.GuildMembers(GuildId))}";

		private string GuildId { get; }
	}
}
