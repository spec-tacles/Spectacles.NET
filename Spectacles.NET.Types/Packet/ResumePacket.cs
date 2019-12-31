using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Used to replay missed events when a disconnected client resumes.
	/// </summary>
	public class ResumePacket
	{
		/// <summary>
		///     session token
		/// </summary>
		[JsonProperty("token")]
		public string Token { get; set; }

		/// <summary>
		///     session id
		/// </summary>
		[JsonProperty("session_id")]
		public string SessionId { get; set; }

		/// <summary>
		///     session id
		/// </summary>
		[JsonProperty("seq")]
		public int Sequence { get; set; }
	}
}
