using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelTypingView : View
	{
		public ChannelTypingView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		public ChannelTypingView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ChannelTypingView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelTyping(ChannelID)}";

		private string ChannelID { get; }
	}
}
