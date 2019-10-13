using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Payload to create a DM Channel
	/// </summary>
	public class CreateDMPayload
	{
		/// <summary>
		/// The Id of the Recipient
		/// </summary>
		[JsonProperty("recipient_id")]
		public string RecipientId { get; set; }
	}
}
