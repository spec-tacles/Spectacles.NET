using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildEmojisView : View
	{
		protected override string Route
			=> $"{(ID != null ? APIEndpoints.GuildEmoji(GuildID, ID) : APIEndpoints.GuildEmojis(GuildID))}";
		
		private string GuildID { get; }
		
		public GuildEmojisView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}