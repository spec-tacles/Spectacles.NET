using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildIntegrationsUpdate event.
	/// </summary>
	[DataContract]
	public class GuildIntegrationsUpdatePayload
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }
	}
}
