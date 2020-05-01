using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the VoiceServerUpdate event.
	/// </summary>
	[DataContract]
	public class VoiceServerUpdatePayload
	{
		/// <summary>
		///     voice connection token
		/// </summary>
		[DataMember(Name="token", Order=1)]
		public string Token { get; set; }

		/// <summary>
		///     the guild this voice server update is for
		/// </summary>
		[DataMember(Name="guild_id", Order=2)]
		public string GuildId { get; set; }

		/// <summary>
		///     the voice server host
		/// </summary>
		[DataMember(Name="endpoint", Order=3)]
		public string Endpoint { get; set; }
	}
}
