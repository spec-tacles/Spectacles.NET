using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelPermissionsView : View
	{
		protected override string Route
			=> $"{APIEndpoints.ChannelPermission(ChannelID, ID)}";
		
		private string ChannelID { get; }
		
		public ChannelPermissionsView(RestClient client, string channelID) : base(client)
		{
			ChannelID = channelID;
		}
	}
}