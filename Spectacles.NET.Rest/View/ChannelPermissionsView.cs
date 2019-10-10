using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelPermissionsView : View
	{
		public ChannelPermissionsView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public ChannelPermissionsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ChannelPermissionsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelPermission(ChannelId, Id)}";

		private string ChannelId { get; }
	}
}
