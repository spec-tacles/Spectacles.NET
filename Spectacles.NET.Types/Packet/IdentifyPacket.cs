using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The Identify data we send over the Discord Gateway
	/// </summary>
	[DataContract]
	public class IdentifyPacket
	{
		/// <summary>
		///     authentication token
		/// </summary>
		[DataMember(Name="token", Order=1)]
		public string Token { get; set; }

		/// <summary>
		///     <see cref="IdentifyProperties" />
		/// </summary>
		[DataMember(Name="properties", Order=2)]
		public IdentifyProperties Properties { get; set; }

		/// <summary>
		///     whether this connection supports compression of packets
		/// </summary>
		[DataMember(Name="compress", Order=3)]
		public bool? Compress { get; set; }

		/// <summary>
		///     value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild
		///     member list
		/// </summary>
		[DataMember(Name="large_threshold", Order=4)]
		public int? LargeThreshold { get; set; }

		/// <summary>
		///     enables dispatching of guild subscription events (presence and typing events)
		/// </summary>
		[DataMember(Name="guild_subscriptions", Order=5)]
		public bool? GuildSubscription { get; set; }

		/// <summary>
		///     used for Guild Sharding
		/// </summary>
		[DataMember(Name="shard", Order=6)]
		public int[] Shard { get; set; }

		/// <summary>
		///     presence structure for initial presence information
		/// </summary>
		[DataMember(Name="presence", Order=7)]
		public UpdateStatusDispatch Presence { get; set; }
		
		/// <summary>
		///		used for Intents System
		/// </summary>
		[DataMember(Name="intents", Order=8)]
		public Intents? Intents { get; set; }
	}
}
