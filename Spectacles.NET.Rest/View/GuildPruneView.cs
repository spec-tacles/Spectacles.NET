using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildPruneView : View
	{
		public GuildPruneView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		protected override string Route
			=> $"{APIEndpoints.GuildPrune(GuildId)}";

		private string GuildId { get; }
	}
}
