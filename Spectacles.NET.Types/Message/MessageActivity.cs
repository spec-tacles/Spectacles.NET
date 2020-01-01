using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Activity sent in a message.
	/// </summary>
	public class MessageActivity
	{
		/// <summary>
		///     type of message activity
		/// </summary>
		[JsonProperty("type")]
		public MessageActivityType Type { get; set; }

		/// <summary>
		///     id of the player's party, lobby, or group
		/// </summary>
		[JsonProperty("party_id")]
		public string PartyId { get; set; }
	}
}
