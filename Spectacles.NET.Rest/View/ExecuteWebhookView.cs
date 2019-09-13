using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ExecuteWebhookView : View
	{
		public ExecuteWebhookView(RestClient client, string webhookID) : base(client)
			=> WebhookID = webhookID;

		public ExecuteWebhookView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public ExecuteWebhookView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.Webhook(WebhookID)}/{ID}";

		private string WebhookID { get; }
	}
}
