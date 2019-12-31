using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <inheritdoc />
	/// <summary>
	///     Returns an object based on the information in Get Gateway, plus additional metadata that can help during the
	///     operation of large or sharded bots. Unlike the Get Gateway, this route should not be cached for extended periods of
	///     time as the value is not guaranteed to be the same per-call, and changes as the bot joins/leaves guilds.
	/// </summary>
	public class GatewayBot : Gateway
	{
		/// <summary>
		///     The recommended number of shards to use when connecting
		/// </summary>
		[JsonProperty("shards")]
		public int Shards { get; set; }

		/// <summary>
		///     Information on the current session start limit
		/// </summary>
		[JsonProperty("session_start_limit")]
		public SessionStartLimit SessionStartLimit { get; set; }
	}
}
