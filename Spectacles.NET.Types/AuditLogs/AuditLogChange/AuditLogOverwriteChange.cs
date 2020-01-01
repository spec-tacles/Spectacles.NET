namespace Spectacles.NET.Types
{
	/// <summary>
	/// Audit Log Change with the Type Permission Overwrite Array
	/// </summary>
	public class AuditLogOverwriteChange : AuditLogChangeBase, IAuditLogChange<PermissionOverwrite[]>
	{
		/// <inheritdoc />
		public PermissionOverwrite[] NewValue { get; set; }


		/// <inheritdoc />
		public PermissionOverwrite[] OldValue { get; set; }
	}
}
