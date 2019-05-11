using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelsView : View
	{
		public ChannelsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ChannelsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		public ChannelMessagesView Messages
			=> new ChannelMessagesView(Client, ID);
		
		public ChannelPermissionsView Permissions
			=> new ChannelPermissionsView(Client, ID);
		
		public ChannelTypingView Typing
			=> new ChannelTypingView(Client, ID);
		
		public ChannelInvitesView Invites
			=> new ChannelInvitesView(Client, ID);
		
		public ChannelPinsView Pins
			=> new ChannelPinsView(Client, ID);
		
		public DMChannelRecipientView Recipient
			=> new DMChannelRecipientView(Client, ID);
		
		public BulkDeleteView BulkDelete
			=> new BulkDeleteView(Client, ID);
		
		protected override string Route
			=> ID == null ? APIEndpoints.Channels : APIEndpoints.Channel(ID);

		public ChannelsView(RestClient client) : base(client)
		{
		}
	}
}