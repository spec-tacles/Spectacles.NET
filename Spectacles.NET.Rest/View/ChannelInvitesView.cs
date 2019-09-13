using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelInvitesView : View
	{
		public ChannelInvitesView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		public ChannelInvitesView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ChannelInvitesView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelInvites(ChannelID)}";

		private string ChannelID { get; }
	}
}
