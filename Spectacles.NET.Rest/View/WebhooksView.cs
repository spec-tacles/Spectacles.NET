using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class WebhooksView : View
	{
		public WebhooksView(RestClient client) : base(client)
		{
		}

		public ExecuteWebhookView Execute
			=> new ExecuteWebhookView(Client, Id);

		public WebhooksView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public WebhooksView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.Webhook(Id)}";
	}
}
