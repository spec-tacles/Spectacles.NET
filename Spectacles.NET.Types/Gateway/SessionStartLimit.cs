using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Information on the current session start limit
	/// </summary>
	[DataContract]
	public class SessionStartLimit
	{
		/// <summary>
		///     The total number of session starts the current user is allowed
		/// </summary>
		[DataMember(Name="total", Order=1)]
		public int Total { get; set; }

		/// <summary>
		///     The remaining number of session starts the current user is allowed
		/// </summary>
		[DataMember(Name="remaining", Order=2)]
		public int Remaining { get; set; }

		/// <summary>
		///     The number of milliseconds after which the limit resets
		/// </summary>
		[DataMember(Name="reset_after", Order=3)]
		public int ResetAfter { get; set; }
	}
}
