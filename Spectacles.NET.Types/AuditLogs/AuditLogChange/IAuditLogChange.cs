namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represent an AuditLogChange with T as Value Type
	/// </summary>
	/// <typeparam name="T">The Type of the changed Value</typeparam>
	public interface IAuditLogChange<out T>
	{
		/// <summary>
		///     new value of the key
		/// </summary>
		public T NewValue { get; }

		/// <summary>
		///     old value of the key
		/// </summary>
		public T OldValue { get; }
	}
}
