using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A partial guild object. Represents an Offline Guild, or a Guild whose information has not been provided through
	///     Guild Create events during the Gateway connect.
	/// </summary>
	public class UnavailableGuild
	{
		/// <summary>
		///     guild id
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		///     is this guild unavailable
		/// </summary>
		[JsonProperty("unavailable")]
		public bool Unavailable { get; set; }
	}
}
