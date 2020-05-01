using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Used to represent a user's voice connection status.
	/// </summary>
	[DataContract]
	public class VoiceState
	{
		/// <summary>
		///     the guild id this voice state is for
		/// </summary>
		[DataMember(Name = "guild_id", Order = 1)]
		public string GuildId { get; set; }

		/// <summary>
		///     the channel id this user is connected to
		/// </summary>
		[DataMember(Name = "channel_id", Order = 2)]
		public string ChannelId { get; set; }

		/// <summary>
		///     the user id this voice state is for
		/// </summary>
		[DataMember(Name = "user_id", Order = 3)]
		public string UserId { get; set; }

		/// <summary>
		///     the guild member this voice state is for
		/// </summary>
		[DataMember(Name = "member", Order = 4)]
		public GuildMember Member { get; set; }

		/// <summary>
		///     the session id for this voice state
		/// </summary>
		[DataMember(Name = "session_id", Order = 5)]
		public string SessionId { get; set; }

		/// <summary>
		///     whether this user is deafened by the server
		/// </summary>
		[DataMember(Name = "deaf", Order = 6)]
		public bool Deaf { get; set; }

		/// <summary>
		///     whether this user is muted by the server
		/// </summary>
		[DataMember(Name = "mute", Order = 7)]
		public bool Mute { get; set; }

		/// <summary>
		///     whether this user is locally deafened
		/// </summary>
		[DataMember(Name = "self_deaf", Order = 8)]
		public bool SelfDeaf { get; set; }

		/// <summary>
		///     whether this user is locally muted
		/// </summary>
		[DataMember(Name = "self_mute", Order = 9)]
		public bool SelfMute { get; set; }

		/// <summary>
		///     whether this user is muted by the current user
		/// </summary>
		[DataMember(Name = "suppress", Order = 10)]
		public bool Suppress { get; set; }
	}
}
