using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Whenever an admin action is performed on the API, an entry is added to the respective guild's audit log. You can
	///     specify the reason by attaching the X-Audit-Log-Reason request header. This header supports url encoded utf8
	///     characters.
	/// </summary>
	[DataContract]
	public class AuditLogs
	{
		/// <summary>
		///     list of webhooks found in the audit log
		/// </summary>
		[DataMember(Name = "webhooks", Order = 1)]
		public Webhook[] Webhooks { get; set; }

		/// <summary>
		///     list of users found in the audit log
		/// </summary>
		[DataMember(Name = "users", Order = 2)]
		public User[] Users { get; set; }

		/// <summary>
		///     list of audit log entries
		/// </summary>
		[DataMember(Name = "audit_log_entries", Order = 3)]
		public AuditLogEntry[] AuditLogEntries { get; set; }

		/// <summary>
		/// 	list of partial integration objects
		/// </summary>
		[DataMember(Name = "integrations", Order = 4)]
		public Integration[] Integration { get; set; }
	}
}
