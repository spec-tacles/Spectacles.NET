using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelPermissionsView : View
	{
		public ChannelPermissionsView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		public ChannelPermissionsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ChannelPermissionsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelPermission(ChannelID, ID)}";

		private string ChannelID { get; }
	}
}
