using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Payload to create a DM Channel
	/// </summary>
	public class CreateDMPayload
	{
		/// <summary>
		/// The ID of the Recipient
		/// </summary>
		[JsonProperty("recipient_id")]
		public string RecipientID { get; set; }
	}
}
