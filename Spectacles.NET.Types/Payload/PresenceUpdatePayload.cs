using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Payload for the PresenceUpdate event.
	/// </summary>
	[DataContract]
	public class PresenceUpdatePayload
	{
		/// <summary>
		///     the user presence is being updated for
		/// </summary>
		[DataMember(Name="user", Order=1)]
		public User User { get; set; }

		/// <summary>
		///     roles this user is in
		/// </summary>
		[DataMember(Name="roles", Order=2)]
		public string[] Roles { get; set; }

		/// <summary>
		///     null, or the user's current activity
		/// </summary>
		[DataMember(Name="game", Order=3)]
		public Activity Game { get; set; }

		/// <summary>
		///     id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=4)]
		public string GuildId { get; set; }

		/// <summary>
		///     either "idle", "dnd", "online", or "offline"
		/// </summary>
		[DataMember(Name="status", Order=5)]
		public string Status { get; set; }

		/// <summary>
		///     user's current activities
		/// </summary>
		[DataMember(Name="activities", Order=6)]
		public Activity[] Activities { get; set; }

		/// <summary>
		///     user's platform-dependent status
		/// </summary>
		[DataMember(Name="client_status", Order=7)]
		public ClientStatus ClientStatus { get; set; }
	}
}
