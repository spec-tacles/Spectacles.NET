using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class WebhooksView : View
	{
		public WebhooksView(RestClient client) : base(client)
		{
		}

		public ExecuteWebhookView Execute
			=> new ExecuteWebhookView(Client, ID);

		public WebhooksView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public WebhooksView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.Webhook(ID)}";
	}
}
