using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class DMChannelRecipientView : View
	{
		public DMChannelRecipientView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public DMChannelRecipientView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public DMChannelRecipientView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelRecipient(ChannelId, Id)}";

		private string ChannelId { get; }
	}
}
