using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildEmbedView : View
	{
		public GuildEmbedView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		protected override string Route
			=> $"{APIEndpoints.GuildEmbed(GuildId)}";

		private string GuildId { get; }
	}
}
