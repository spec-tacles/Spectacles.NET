using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelTypingView : View
	{
		public ChannelTypingView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public ChannelTypingView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ChannelTypingView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelTyping(ChannelId)}";

		private string ChannelId { get; }
	}
}
