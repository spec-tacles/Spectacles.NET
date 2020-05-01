using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Sent by the client to indicate a presence or status update.
	/// </summary>
	[DataContract]
	public class UpdateStatusDispatch
	{
		/// <summary>
		///     unix time (in milliseconds) of when the client went idle, or null if the client is not idle
		/// </summary>
		[DataMember(Name="since", Order=1)]
		public int? Since { get; set; }

		/// <summary>
		///     null, or the user's new activity
		/// </summary>
		[DataMember(Name="game", Order=2)]
		public Activity Game { get; set; }

		/// <summary>
		///     the user's new status
		/// </summary>
		[DataMember(Name="status", Order=3)]
		public string Status { get; set; }

		/// <summary>
		///     whether or not the client is afk
		/// </summary>
		[DataMember(Name="afk", Order=4)]
		public bool AFK { get; set; }
	}
}
