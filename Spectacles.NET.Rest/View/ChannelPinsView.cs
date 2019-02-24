using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelPinsView : View
	{
		public ChannelPinsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ChannelPinsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		protected override string Route
			=> $"{(ID != null ? APIEndpoints.ChannelPins(ChannelID) : APIEndpoints.ChannelPin(ChannelID, ID))}";
		
		private string ChannelID { get; }
		
		public ChannelPinsView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}