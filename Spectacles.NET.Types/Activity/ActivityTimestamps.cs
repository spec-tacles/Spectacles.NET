using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{

    /// <summary>
	/// Unix timestamps for start and/or end of the game
	/// </summary>
	[DataContract]
	public class ActivityTimestamps
	{
		/// <summary>
		///     unix time (in milliseconds) of when the activity started
		/// </summary>
		[DataMember(Name="start", Order=1)]
		public long? Start { get; set; }

		/// <summary>
		///     unix time (in milliseconds) of when the activity ends
		/// </summary>
		[DataMember(Name="end", Order=2)]
		public long? End { get; set; }
	}
}
