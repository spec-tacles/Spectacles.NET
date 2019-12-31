using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The ready event is dispatched when a client has completed the initial handshake with the gateway (for new
	///     sessions). The ready event can be the largest and most complex event the gateway will send, as it contains all the
	///     state required for a client to begin interacting with the rest of the platform.
	/// </summary>
	public class ReadyDispatch
	{
		/// <summary>
		///     gateway protocol version
		/// </summary>
		[JsonProperty("v")]
		public int GatewayVersion { get; set; }

		/// <summary>
		///     information about the user including email
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }

		/// <summary>
		///     the guilds the user is in
		/// </summary>
		[JsonProperty("guilds")]
		public UnavailableGuild[] Guilds { get; set; }

		/// <summary>
		///     used for resuming connections
		/// </summary>
		[JsonProperty("session_id")]
		public string SessionId { get; set; }

		/// <summary>
		///     the shard information associated with this session, if sent when identifying
		/// </summary>
		[JsonProperty("shard")]
		public int?[] Shard { get; set; }
	}
}
