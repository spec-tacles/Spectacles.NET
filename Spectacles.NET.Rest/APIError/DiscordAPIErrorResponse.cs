using Newtonsoft.Json;

namespace Spectacles.NET.Rest.APIError
{
	/// <summary>
	/// JSON Discord Api Error Response
	/// </summary>
	public class DiscordAPIErrorResponse
	{
		/// <summary>
		/// Status Code of JSON Discord Api Error Response
		/// </summary>
		[JsonProperty("code")]
		public int Code { get; set; }

		/// <summary>
		/// Message of JSON Discord Api Error Response
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
