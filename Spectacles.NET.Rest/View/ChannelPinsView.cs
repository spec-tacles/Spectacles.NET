using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ChannelPinsView : View
	{
		public ChannelPinsView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public ChannelPinsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ChannelPinsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{(Id != null ? APIEndpoints.ChannelPins(ChannelId) : APIEndpoints.ChannelPin(ChannelId, Id))}";

		private string ChannelId { get; }
	}
}
