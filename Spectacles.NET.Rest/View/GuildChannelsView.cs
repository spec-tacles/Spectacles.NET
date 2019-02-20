using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildChannelsView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildChannels(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildChannelsView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}