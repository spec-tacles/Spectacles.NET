using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Video of an Embed
	/// </summary>
	public class EmbedVideo
	{
		/// <summary>
		///     source url of video
		/// </summary>
		[JsonProperty("url")]
		public string URL { get; set; }

		/// <summary>
		///     height of video
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }

		/// <summary>
		///     width of video
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }
	}
}
