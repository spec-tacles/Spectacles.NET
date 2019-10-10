using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelMessagesView : View
	{
		public ChannelMessagesView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public ChannelMessagesView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ChannelMessagesView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		public MessageReactionView Reactions
			=> new MessageReactionView(Client, ChannelId, Id);

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.Message(ChannelId, Id) : APIEndpoints.ChannelMessages(ChannelId))}";

		private string ChannelId { get; }
	}
}
