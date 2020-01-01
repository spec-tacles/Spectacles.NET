namespace Spectacles.NET.Types
{
	/// <summary>
	/// Audit Log Change with the Type Role Array
	/// </summary>
	public class AuditLogRoleChange : AuditLogChangeBase, IAuditLogChange<Role[]>
	{
		/// <inheritdoc />
		public Role[] NewValue { get; set; }
		
		/// <inheritdoc />
		public Role[] OldValue { get; set; }
	}
}
