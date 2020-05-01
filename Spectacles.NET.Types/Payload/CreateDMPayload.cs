using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Payload to create a DM Channel
	/// </summary>
	[DataContract]
	public class CreateDMPayload
	{
		/// <summary>
		/// The Id of the Recipient
		/// </summary>
		[DataMember(Name="recipient_id", Order=1)]
		public string RecipientId { get; set; }
	}
}
