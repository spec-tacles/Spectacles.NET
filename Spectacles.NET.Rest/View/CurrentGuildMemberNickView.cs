using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentGuildMemberNickView : View
	{
		public CurrentGuildMemberNickView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public CurrentGuildMemberNickView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public CurrentGuildMemberNickView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.CurrentGuildMember(GuildId)}";

		private string GuildId { get; }
	}
}
