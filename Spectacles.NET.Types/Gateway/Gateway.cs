using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Returns an object with a single valid WSS URL, which the client can use for Connecting. Clients should cache this
	///     value and only call this endpoint to retrieve a new URL if they are unable to properly establish a connection using
	///     the cached version of the URL.
	/// </summary>
	[DataContract]
	public class Gateway
	{
		/// <summary>
		///     The WSS URL that can be used for connecting to the gateway
		/// </summary>
		[DataMember(Name="url", Order=1)]
		public string URL { get; set; }
	}
}
