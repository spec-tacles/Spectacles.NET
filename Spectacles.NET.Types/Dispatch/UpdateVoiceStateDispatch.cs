// ReSharper disable UnusedMember.Global

using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Sent when a client wants to join, move, or disconnect from a voice channel.
	/// </summary>
	[DataContract]
	public class UpdateVoiceStateDispatch
	{
		/// <summary>
		///     id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=1)]
		public string GuildId { get; set; }

		/// <summary>
		///     id of the voice channel client wants to join (null if disconnecting)
		/// </summary>
		[DataMember(Name="channel_id", Order=2)]
		public string ChannelId { get; set; }

		/// <summary>
		///     is the client muted
		/// </summary>
		[DataMember(Name="self_mute", Order=3)]
		public bool SelfMute { get; set; }

		/// <summary>
		///     is the client deafened
		/// </summary>
		[DataMember(Name="self_deaf", Order=4)]
		public bool SelfDeaf { get; set; }
	}
}
