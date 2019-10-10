using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildMemberRolesView : View
	{
		public GuildMemberRolesView(RestClient client, string guildId, string userId) : base(client)
		{
			GuildId = guildId;
			UserId = userId;
		}

		public GuildMemberRolesView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildMemberRolesView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildMemberRole(GuildId, UserId, Id)}";

		private string GuildId { get; }

		private string UserId { get; }
	}
}
