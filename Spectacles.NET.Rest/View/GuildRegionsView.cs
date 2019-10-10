using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildRegionsView : View
	{
		public GuildRegionsView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildRegionsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildRegionsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildVoiceRegion(GuildId)}";

		private string GuildId { get; }
	}
}
