using Newtonsoft.Json;

namespace Spectacles.NET.Types.Voice
{
	/// <summary>
	/// A voice region of a discord guild
	/// </summary>
	public class VoiceRegion
	{
		/// <summary>
		/// 	unique ID for the region
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }
		
		/// <summary>
		/// 	name of the region
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// 	true if this is a vip-only server
		/// </summary>
		[JsonProperty("vip")]
		public bool Vip { get; set; }
		
		/// <summary>
		/// 	whether this is a custom voice region (used for events/etc)
		/// </summary>
		[JsonProperty("custom")]
		public bool Custom { get; set; }
		
		/// <summary>
		///		whether this is a deprecated voice region (avoid switching to these)
		/// </summary>
		[JsonProperty("deprecated")]
		public bool Deprecated { get; set; }
		
		/// <summary>
		/// 	true for a single server that is closest to the current user's client
		/// </summary>
		[JsonProperty("optimal")]
		public bool Optimal { get; set; }
	}
}
