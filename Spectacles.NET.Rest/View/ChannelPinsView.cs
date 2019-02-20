using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelPinsView : View
	{
		protected override string Route
			=> $"{(ID != null ? APIEndpoints.ChannelPins(ChannelID) : APIEndpoints.ChannelPin(ChannelID, ID))}";
		
		private string ChannelID { get; }
		
		public ChannelPinsView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}