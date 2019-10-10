using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildVanityURLView : View
	{
		public GuildVanityURLView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		protected override string Route
			=> $"{APIEndpoints.GuildVanityURL(GuildId)}";

		private string GuildId { get; }
	}
}
