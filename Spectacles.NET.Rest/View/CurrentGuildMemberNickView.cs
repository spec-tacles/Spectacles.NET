using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentGuildMemberNickView : View
	{
		public CurrentGuildMemberNickView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		public CurrentGuildMemberNickView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public CurrentGuildMemberNickView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.CurrentGuildMember(GuildID)}";

		private string GuildID { get; }
	}
}
