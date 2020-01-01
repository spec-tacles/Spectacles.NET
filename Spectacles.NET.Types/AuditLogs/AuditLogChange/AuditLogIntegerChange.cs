namespace Spectacles.NET.Types
{
	/// <summary>
	/// Audit Log Change with the Type int
	/// </summary>
	public class AuditLogIntegerChange : AuditLogChangeBase, IAuditLogChange<int>
	{
		/// <inheritdoc />
		public int NewValue { get; set; }


		/// <inheritdoc />
		public int OldValue { get; set; }
	}
}
