using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelWebhooksView : View
	{
		public ChannelWebhooksView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		protected override string Route
			=> $"{APIEndpoints.ChannelWebhooks(ChannelID)}";

		private string ChannelID { get; }
	}
}
