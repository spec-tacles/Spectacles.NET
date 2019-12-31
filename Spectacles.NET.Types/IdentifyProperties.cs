using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The properties send along with the Identify data
	/// </summary>
	public class IdentifyProperties
	{
		/// <summary>
		///     your operating system
		/// </summary>
		[JsonProperty("$os")]
		public string OS { get; set; }

		/// <summary>
		///     your library name
		/// </summary>
		[JsonProperty("$browser")]
		public string Browser { get; set; }

		/// <summary>
		///     your library name
		/// </summary>
		[JsonProperty("$device")]
		public string Device { get; set; }
	}
}
