using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// secrets for Rich Presence joining and spectating
	/// </summary>
	[DataContract]
	public class ActivitySecrets
	{
		/// <summary>
		///     the secret for joining a party
		/// </summary>
		[DataMember(Name="join", Order=1)]
		public string Join { get; set; }

		/// <summary>
		///     the secret for spectating a game
		/// </summary>
		[DataMember(Name="spectate", Order=2)]
		public string Spectate { get; set; }

		/// <summary>
		///     the secret for a specific instanced match
		/// </summary>
		[DataMember(Name="match", Order=3)]
		public string Match { get; set; }
	}
}
