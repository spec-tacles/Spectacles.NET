using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildChannelsView : View
	{
		public GuildChannelsView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildChannelsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildChannelsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildChannels(GuildId)}";

		private string GuildId { get; }
	}
}
