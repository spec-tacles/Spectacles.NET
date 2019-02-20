using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class MessageReactionView : View
	{	
		public MessageReactionView this[long id]
		{
			get
			{
				User = id.ToString();
				return this;
			}
		}

		public MessageReactionView this[string id]
		{
			get
			{
				if (ID == null) ID = id;
				else User = id; 
				return this;
			}
		}
		
		protected override string Route
			=> $"{APIEndpoints.MessageReaction(ChannelID, MessageID, ID)}/{User ?? "@me"}";
		
		private string ChannelID { get; }
		
		private string MessageID { get; }
		
		private string User { get; set; }
		
		public MessageReactionView(RestClient client, string channelID, string messageID) : base(client)
		{
			ChannelID = channelID;
			MessageID = messageID;
		}
	}
}