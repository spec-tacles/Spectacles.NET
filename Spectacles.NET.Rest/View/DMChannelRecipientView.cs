using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class DMChannelRecipientView : View
	{
		protected override string Route
			=> $"{APIEndpoints.ChannelRecipient(ChannelID, ID)}";
		
		private string ChannelID { get; }
		
		public DMChannelRecipientView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}