using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildRegionsView : View
	{
		public GuildRegionsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildRegionsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		protected override string Route
			=> $"{APIEndpoints.GuildVoiceRegion(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildRegionsView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}