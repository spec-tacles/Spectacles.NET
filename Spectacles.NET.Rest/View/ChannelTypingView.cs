using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelTypingView : View
	{
		protected override string Route
			=> $"{APIEndpoints.ChannelTyping(ChannelID)}";

		private string ChannelID { get; }
		
		public ChannelTypingView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}