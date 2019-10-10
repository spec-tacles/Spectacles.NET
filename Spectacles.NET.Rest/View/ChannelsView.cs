using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelsView : View
	{
		public ChannelsView(RestClient client) : base(client)
		{
		}

		public ChannelsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ChannelsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		public ChannelMessagesView Messages
			=> new ChannelMessagesView(Client, Id);

		public ChannelPermissionsView Permissions
			=> new ChannelPermissionsView(Client, Id);

		public ChannelTypingView Typing
			=> new ChannelTypingView(Client, Id);

		public ChannelInvitesView Invites
			=> new ChannelInvitesView(Client, Id);

		public ChannelPinsView Pins
			=> new ChannelPinsView(Client, Id);

		public DMChannelRecipientView Recipient
			=> new DMChannelRecipientView(Client, Id);

		public BulkDeleteView BulkDelete
			=> new BulkDeleteView(Client, Id);

		protected override string Route
			=> Id == null ? APIEndpoints.Channels : APIEndpoints.Channel(Id);
	}
}
