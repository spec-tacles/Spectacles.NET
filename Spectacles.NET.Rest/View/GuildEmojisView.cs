using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildEmojisView : View
	{
		public GuildEmojisView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.GuildEmoji(GuildId, Id) : APIEndpoints.GuildEmojis(GuildId))}";

		private string GuildId { get; }
	}
}
