using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Sent by the client to indicate a presence or status update.
	/// </summary>
	public class UpdateStatusDispatch
	{
		/// <summary>
		///     unix time (in milliseconds) of when the client went idle, or null if the client is not idle
		/// </summary>
		[JsonProperty("since")]
		public int? Since { get; set; }

		/// <summary>
		///     null, or the user's new activity
		/// </summary>
		[JsonProperty("game")]
		public Activity Game { get; set; }

		/// <summary>
		///     the user's new status
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		///     whether or not the client is afk
		/// </summary>
		[JsonProperty("afk")]
		public bool AFK { get; set; }
	}
}
