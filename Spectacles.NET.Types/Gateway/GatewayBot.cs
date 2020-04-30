using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <inheritdoc />
	/// <summary>
	///     Returns an object based on the information in Get Gateway, plus additional metadata that can help during the
	///     operation of large or sharded bots. Unlike the Get Gateway, this route should not be cached for extended periods of
	///     time as the value is not guaranteed to be the same per-call, and changes as the bot joins/leaves guilds.
	/// </summary>
	[DataContract]
	public class GatewayBot : Gateway
	{
		/// <summary>
		///     The recommended number of shards to use when connecting
		/// </summary>
		[DataMember(Name="shards", Order=1)]
		public int Shards { get; set; }

		/// <summary>
		///     Information on the current session start limit
		/// </summary>
		[DataMember(Name="session_start_limit", Order=2)]
		public SessionStartLimit SessionStartLimit { get; set; }
	}
}
