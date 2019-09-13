using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Status of an User
	/// </summary>
	public enum Status
	{
		/// <summary>
		///     The User is online
		/// </summary>
		ONLINE,

		/// <summary>
		///     The User is idle
		/// </summary>
		IDLE,

		/// <summary>
		///     The User is DnD
		/// </summary>
		DND,

		/// <summary>
		///     The User is offline
		/// </summary>
		OFFLINE
	}

	/// <summary>
	///     Active sessions are indicated with an "online", "idle", or "dnd" string per platform. If a user is offline or
	///     invisible, the corresponding field is not present.
	/// </summary>
	public class ClientStatus
	{
		/// <summary>
		///     the user's status set for an active desktop (Windows, Linux, Mac) application session
		/// </summary>
		[JsonProperty("desktop")]
		public Status? Desktop { get; set; }

		/// <summary>
		///     the user's status set for an active mobile (iOS, Android) application session
		/// </summary>
		[JsonProperty("mobile")]
		public Status? Mobile { get; set; }

		/// <summary>
		///     the user's status set for an active web (browser, bot account) application session
		/// </summary>
		[JsonProperty("web")]
		public Status? Web { get; set; }
	}

	/// <summary>
	///     A user's presence is their current state on a guild.
	/// </summary>
	public class Presence
	{
		/// <summary>
		///     the user presence is being updated for
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <summary>
		///     roles this user is in
		/// </summary>
		[JsonProperty("roles")]
		public List<string> Roles { get; set; }

		/// <summary>
		///     null, or the user's current activity
		/// </summary>
		[JsonProperty("game")]
		public Activity Game { get; set; }

		/// <summary>
		///     id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildID { get; set; }

		/// <summary>
		///     either "idle", "dnd", "online", or "offline"
		/// </summary>
		[JsonProperty("status")]
		public Status Status { get; set; }

		/// <summary>
		///     user's current activities
		/// </summary>
		[JsonProperty("activities")]
		public List<Activity> Activities { get; set; }

		/// <summary>
		///     user's platform-dependent status
		/// </summary>
		[JsonProperty("client_status")]
		public ClientStatus ClientStatus { get; set; }
	}
}
