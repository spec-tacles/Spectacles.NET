using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Activity sent in a message.
	/// </summary>
	[DataContract]
	public class MessageActivity
	{
		/// <summary>
		///     type of message activity
		/// </summary>
		[DataMember(Name="type", Order=1)]
		public MessageActivityType Type { get; set; }

		/// <summary>
		///     id of the player's party, lobby, or group
		/// </summary>
		[DataMember(Name="party_id", Order=2)]
		public string PartyId { get; set; }
	}
}
