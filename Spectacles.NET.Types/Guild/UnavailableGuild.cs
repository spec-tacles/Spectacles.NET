using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A partial guild object. Represents an Offline Guild, or a Guild whose information has not been provided through
	///     Guild Create events during the Gateway connect.
	/// </summary>
	[DataContract]
	public class UnavailableGuild
	{
		/// <summary>
		///     guild id
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     is this guild unavailable
		/// </summary>
		[DataMember(Name="unavailable", Order=2)]
		public bool Unavailable { get; set; }
	}
}
