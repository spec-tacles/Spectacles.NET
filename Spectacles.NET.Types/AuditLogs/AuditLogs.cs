using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Whenever an admin action is performed on the API, an entry is added to the respective guild's audit log. You can
	///     specify the reason by attaching the X-Audit-Log-Reason request header. This header supports url encoded utf8
	///     characters.
	/// </summary>
	public class AuditLogs
	{
		/// <summary>
		///     list of webhooks found in the audit log
		/// </summary>
		[JsonProperty("webhooks")]
		public Webhook[] Webhooks { get; set; }

		/// <summary>
		///     list of users found in the audit log
		/// </summary>
		[JsonProperty("users")]
		public User[] Users { get; set; }

		/// <summary>
		///     list of audit log entries
		/// </summary>
		[JsonProperty("audit_log_entries")]
		public AuditLogEntry[] AuditLogEntries { get; set; }
		
		/// <summary>
		/// 	list of partial integration objects
		/// </summary>
		[JsonProperty("integrations")]
		public Integration[] Integration { get; set; }
	}
}
