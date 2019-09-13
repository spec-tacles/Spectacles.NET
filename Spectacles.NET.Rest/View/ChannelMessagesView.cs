using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelMessagesView : View
	{
		public ChannelMessagesView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		public ChannelMessagesView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ChannelMessagesView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		public MessageReactionView Reactions
			=> new MessageReactionView(Client, ChannelID, ID);

		protected override string Route
			=> $"{(ID != null ? APIEndpoints.Message(ChannelID, ID) : APIEndpoints.ChannelMessages(ChannelID))}";

		private string ChannelID { get; }
	}
}
