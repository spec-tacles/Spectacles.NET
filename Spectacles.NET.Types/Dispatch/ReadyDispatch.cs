using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The ready event is dispatched when a client has completed the initial handshake with the gateway (for new
	///     sessions). The ready event can be the largest and most complex event the gateway will send, as it contains all the
	///     state required for a client to begin interacting with the rest of the platform.
	/// </summary>
	[DataContract]
	public class ReadyDispatch
	{
		/// <summary>
		///     gateway protocol version
		/// </summary>
		[DataMember(Name="v", Order=1)]
		public int GatewayVersion { get; set; }

		/// <summary>
		///     information about the user including email
		/// </summary>
		[DataMember(Name="user", Order=2)]
		public User User { get; set; }

		/// <summary>
		///     the guilds the user is in
		/// </summary>
		[DataMember(Name="guilds", Order=3)]
		public UnavailableGuild[] Guilds { get; set; }

		/// <summary>
		///     used for resuming connections
		/// </summary>
		[DataMember(Name="session_id", Order=4)]
		public string SessionId { get; set; }

		/// <summary>
		///     the shard information associated with this session, if sent when identifying
		/// </summary>
		[DataMember(Name="shard", Order=5)]
		public int?[] Shard { get; set; }
	}
}
