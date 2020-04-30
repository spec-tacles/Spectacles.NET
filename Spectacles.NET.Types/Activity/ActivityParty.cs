using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Party of an activity
	/// </summary>
	[DataContract]
	public class ActivityParty
	{
		/// <summary>
		///     the id of the party
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     used to show the party's current and maximum size
		/// </summary>
		[DataMember(Name="size", Order=2)]
		public List<int> Size { get; set; }
	}
}
