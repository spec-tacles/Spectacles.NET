using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class BulkDeleteView : View
	{
		public BulkDeleteView(RestClient client, string channelId) : base(client)
			=> ChannelId = channelId;

		public BulkDeleteView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public BulkDeleteView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.BulkDelete(ChannelId)}";

		private string ChannelId { get; }
	}
}
