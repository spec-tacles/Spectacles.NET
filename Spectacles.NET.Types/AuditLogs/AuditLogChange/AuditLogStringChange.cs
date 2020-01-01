namespace Spectacles.NET.Types
{
	/// <summary>
	/// Audit Log Change with the Type String
	/// </summary>
	public class AuditLogStringChange : AuditLogChangeBase, IAuditLogChange<string>
	{
		/// <inheritdoc />
		public string NewValue { get; set; }


		/// <inheritdoc />
		public string OldValue { get; set; }
	}
}
