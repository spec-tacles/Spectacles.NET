using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Returns an object with a single valid WSS URL, which the client can use for Connecting. Clients should cache this
	///     value and only call this endpoint to retrieve a new URL if they are unable to properly establish a connection using
	///     the cached version of the URL.
	/// </summary>
	public class Gateway
	{
		/// <summary>
		///     The WSS URL that can be used for connecting to the gateway
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }
	}

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
