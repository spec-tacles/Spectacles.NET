using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class BulkDeleteView : View
	{
		protected override string Route
			=> $"{APIEndpoints.BulkDelete(ChannelID)}";

		private string ChannelID { get; }
		
		public BulkDeleteView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}