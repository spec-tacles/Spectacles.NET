using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Used to replay missed events when a disconnected client resumes.
	/// </summary>
	[DataContract]
	public class ResumePacket
	{
		/// <summary>
		///     session token
		/// </summary>
		[DataMember(Name="token", Order=1)]
		public string Token { get; set; }

		/// <summary>
		///     session id
		/// </summary>
		[DataMember(Name="session_id", Order=2)]
		public string SessionId { get; set; }

		/// <summary>
		///     session id
		/// </summary>
		[DataMember(Name="seq", Order=3)]
		public int Sequence { get; set; }
	}
}
