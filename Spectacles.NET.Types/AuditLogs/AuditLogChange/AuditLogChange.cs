namespace Spectacles.NET.Types
{
	/// <summary>
	/// Audit Log Change with the any type
	/// </summary>
	public class AuditLogChange<T> : AuditLogChangeBase, IAuditLogChange<T>
	{
		/// <inheritdoc />
		public new T NewValue
			=> (T) base.NewValue;


		/// <inheritdoc />
		public new T OldValue
			=> (T) base.OldValue;
	}
}
