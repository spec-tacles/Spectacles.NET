using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
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
		public string GuildId { get; set; }

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
