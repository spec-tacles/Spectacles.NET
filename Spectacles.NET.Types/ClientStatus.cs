using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
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
}
