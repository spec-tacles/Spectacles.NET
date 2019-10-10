using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelInvitesView : View
	{
		public ChannelInvitesView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public ChannelInvitesView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ChannelInvitesView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelInvites(ChannelId)}";

		private string ChannelId { get; }
	}
}
