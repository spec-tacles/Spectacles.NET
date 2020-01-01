namespace Spectacles.NET.Types
{
	/// <summary>
	/// Audit Log Change with the Type Bool
	/// </summary>
	public class AuditLogBoolChange : AuditLogChangeBase, IAuditLogChange<bool>
	{
		/// <inheritdoc />
		public bool NewValue { get; set; }


		/// <inheritdoc />
		public bool OldValue { get; set; }
	}
}
