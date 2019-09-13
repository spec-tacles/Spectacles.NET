using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class DMChannelRecipientView : View
	{
		public DMChannelRecipientView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		public DMChannelRecipientView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public DMChannelRecipientView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.ChannelRecipient(ChannelID, ID)}";

		private string ChannelID { get; }
	}
}
