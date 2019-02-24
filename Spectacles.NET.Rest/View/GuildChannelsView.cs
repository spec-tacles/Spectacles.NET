using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildChannelsView : View
	{
		public GuildChannelsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildChannelsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		protected override string Route
			=> $"{APIEndpoints.GuildChannels(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildChannelsView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}