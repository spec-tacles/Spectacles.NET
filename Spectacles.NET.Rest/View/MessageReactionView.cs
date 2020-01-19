using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class MessageReactionView : View
	{
		public MessageReactionView(RestClient client, string channelId, string messageId) : base(client)
		{
			ChannelId = channelId;
			MessageId = messageId;
		}

		public MessageReactionView this[long id]
		{
			get
			{
				var idString = id.ToString();
				if (Id == null) Id = idString;
				else User = idString;
				return this;
			}
		}

		public MessageReactionView this[string id]
		{
			get
			{
				if (Id == null) Id = id;
				else User = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.MessageReaction(ChannelId, MessageId, Id)}/{User}";

		private string ChannelId { get; }

		private string MessageId { get; }

		private string User { get; set; }
	}
}
