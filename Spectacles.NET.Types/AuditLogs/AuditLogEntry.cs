using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     An Audit Log Entry
	/// </summary>
	[DataContract]
	public class AuditLogEntry
	{
		/// <summary>
		///     id of the affected entity (webhook, user, role, etc.)
		/// </summary>
		[DataMember(Name = "target_id", Order = 1)]
		public string TargetId { get; set; }

		/// <summary>
		///     changes made to the target_id
		/// </summary>
		[DataMember(Name = "changes", Order = 2)]
		public AuditLogChangeBase[] Changes { get; set; }

		/// <summary>
		///     the user who made the changes
		/// </summary>
		[DataMember(Name = "user_id", Order = 3)]
		public string UserId { get; set; }

		/// <summary>
		///     id of the entry
		/// </summary>
		[DataMember(Name = "id", Order = 4)]
		public string Id { get; set; }

		/// <summary>
		///     type of action that occured
		/// </summary>
		[DataMember(Name = "action_type", Order = 5)]
		public AuditLogEvent ActionType { get; set; }

		/// <summary>
		///     additional info for certain action types
		/// </summary>
		[DataMember(Name = "options", Order = 6)]
		public AuditLogEntryInfo Options { get; set; }

		/// <summary>
		///     the reason for the change (0-512 characters)
		/// </summary>
		[DataMember(Name = "reason", Order = 7)]
		public string Reason { get; set; }
	}
}