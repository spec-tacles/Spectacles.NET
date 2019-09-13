using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildVanityURLView : View
	{
		public GuildVanityURLView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		protected override string Route
			=> $"{APIEndpoints.GuildVanityURL(GuildID)}";

		private string GuildID { get; }
	}
}
