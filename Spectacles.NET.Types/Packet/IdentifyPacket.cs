using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Identify data we send over the Discord Gateway
	/// </summary>
	public class IdentifyPacket
	{
		/// <summary>
		///     authentication token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		///     <see cref="IdentifyProperties" />
		/// </summary>
		[JsonProperty("properties")]
		public IdentifyProperties Properties { get; set; }

		/// <summary>
		///     whether this connection supports compression of packets
		/// </summary>
		[JsonProperty("compress")]
		public bool? Compress { get; set; }

		/// <summary>
		///     value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild
		///     member list
		/// </summary>
		[JsonProperty("large_threshold")]
		public int? LargeThreshold { get; set; }

		/// <summary>
		///     enables dispatching of guild subscription events (presence and typing events)
		/// </summary>
		[JsonProperty("guild_subscriptions")]
		public bool? GuildSubscription { get; set; }

		/// <summary>
		///     used for Guild Sharding
		/// </summary>
		[JsonProperty("shard")]
		public int[] Shard { get; set; }

		/// <summary>
		///     presence structure for initial presence information
		/// </summary>
		[JsonProperty("presence")]
		public UpdateStatusDispatch Presence { get; set; }
		
		/// <summary>
		///		used for Intents System
		/// </summary>
		[JsonProperty("intents")]
		public Intents? Intents { get; set; }
	}
}
