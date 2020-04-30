using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Channel Mentioned in a Cross Posted Message
	/// </summary>
	[DataContract]
	public class ChannelMention
	{
		/// <summary>
		///     id of the channel
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     id of the guild containing the channel
		/// </summary>
		[DataMember(Name="guild_id", Order=2)]
		public string GuildId { get; set; }

		/// <summary>
		///     the type of channel
		/// </summary>
		[DataMember(Name="type", Order=3)]
		public ChannelType Type { get; set; }

		/// <summary>
		///     the name of the channel
		/// </summary>
		[DataMember(Name="name", Order=4)]
		public string Name { get; set; }
	}
}
