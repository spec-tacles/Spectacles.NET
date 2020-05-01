using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     The properties send along with the Identify data
	/// </summary>
	[DataContract]
	public class IdentifyProperties
	{
		/// <summary>
		///     your operating system
		/// </summary>
		[DataMember(Name="$os", Order=1)]
		public string OS { get; set; }

		/// <summary>
		///     your library name
		/// </summary>
		[DataMember(Name="$browser", Order=2)]
		public string Browser { get; set; }

		/// <summary>
		///     your library name
		/// </summary>
		[DataMember(Name="$device", Order=3)]
		public string Device { get; set; }
	}
}
