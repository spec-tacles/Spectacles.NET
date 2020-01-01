using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a permission overwrite for a role or member in a guild channel.
	/// </summary>
	public class PermissionOverwrite
	{
		/// <summary>
		///     role or user id
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     either "role" or "member"
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		///     permission bit set
		/// </summary>
		[JsonProperty("allow")]
		public Permission Allow { get; set; }

		/// <summary>
		///     permission bit set
		/// </summary>
		[JsonProperty("deny")]
		public Permission Deny { get; set; }
	}
}
