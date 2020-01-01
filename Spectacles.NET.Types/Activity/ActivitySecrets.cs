using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// secrets for Rich Presence joining and spectating
	/// </summary>
	public class ActivitySecrets
	{
		/// <summary>
		///     the secret for joining a party
		/// </summary>
		[JsonProperty("join")]
		public string Join { get; set; }

		/// <summary>
		///     the secret for spectating a game
		/// </summary>
		[JsonProperty("spectate")]
		public string Spectate { get; set; }

		/// <summary>
		///     the secret for a specific instanced match
		/// </summary>
		[JsonProperty("match")]
		public string Match { get; set; }
	}
}
