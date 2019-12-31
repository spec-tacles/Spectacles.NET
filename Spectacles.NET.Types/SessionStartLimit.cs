using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Information on the current session start limit
	/// </summary>
	public class SessionStartLimit
	{
		/// <summary>
		///     The total number of session starts the current user is allowed
		/// </summary>
		[JsonProperty("total")]
		public int Total { get; set; }

		/// <summary>
		///     The remaining number of session starts the current user is allowed
		/// </summary>
		[JsonProperty("remaining")]
		public int Remaining { get; set; }

		/// <summary>
		///     The number of milliseconds after which the limit resets
		/// </summary>
		[JsonProperty("reset_after")]
		public int ResetAfter { get; set; }
	}
}
