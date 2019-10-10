using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildBansView : View
	{
		public GuildBansView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildBansView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildBansView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.GuildBan(GuildId, Id) : APIEndpoints.GuildBans(GuildId))}";

		private string GuildId { get; }
	}
}
