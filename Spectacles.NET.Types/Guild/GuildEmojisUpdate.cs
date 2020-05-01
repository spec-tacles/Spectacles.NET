using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The payload for the GuildEmojisUpdate event.
	/// </summary>
	[DataContract]
	public class GuildEmojisUpdate
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     array of emojis
		/// </summary>
		[DataMember(Name="emojis", Order=2)]
		public Emoji[] Emojis { get; set; }
	}
}
