using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     An Audit Log Entry
	/// </summary>
	public class AuditLogEntry
	{
		/// <summary>
		///     id of the affected entity (webhook, user, role, etc.)
		/// </summary>
		[JsonProperty("target_id")]
		public string TargetId { get; set; }

		/// <summary>
		///     changes made to the target_id
		/// </summary>
		[JsonProperty("changes")]
		public AuditLogChangeBase[] Changes { get; set; }

		/// <summary>
		///     the user who made the changes
		/// </summary>
		[JsonProperty("user_id")]
		public string UserId { get; set; }

		/// <summary>
		///     id of the entry
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     type of action that occured
		/// </summary>
		[JsonProperty("action_type")]
		public AuditLogEvent ActionType { get; set; }

		/// <summary>
		///     additional info for certain action types
		/// </summary>
		[JsonProperty("options")]
		public AuditLogEntryInfo Options { get; set; }

		/// <summary>
		///     the reason for the change (0-512 characters)
		/// </summary>
		[JsonProperty("reason")]
		public string Reason { get; set; }
	}
}
