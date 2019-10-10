using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelWebhooksView : View
	{
		public ChannelWebhooksView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		protected override string Route
			=> $"{APIEndpoints.ChannelWebhooks(ChannelId)}";

		private string ChannelId { get; }
	}
}
