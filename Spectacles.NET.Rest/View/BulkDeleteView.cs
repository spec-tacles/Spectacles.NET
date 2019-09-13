using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class BulkDeleteView : View
	{
		public BulkDeleteView(RestClient client, string channelID) : base(client)
			=> ChannelID = channelID;

		public BulkDeleteView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public BulkDeleteView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.BulkDelete(ChannelID)}";

		private string ChannelID { get; }
	}
}
