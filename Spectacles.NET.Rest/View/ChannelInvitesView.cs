using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelInvitesView : View
	{
		protected override string Route
			=> $"{APIEndpoints.ChannelInvites(ChannelID)}";
		
		private string ChannelID { get; }
		
		public ChannelInvitesView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}