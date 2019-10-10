using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ExecuteWebhookView : View
	{
		public ExecuteWebhookView(RestClient client, string webhookId) : base(client)
			=> WebhookId = webhookId;

		public ExecuteWebhookView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public ExecuteWebhookView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.Webhook(WebhookId)}/{Id}";

		private string WebhookId { get; }
	}
}
