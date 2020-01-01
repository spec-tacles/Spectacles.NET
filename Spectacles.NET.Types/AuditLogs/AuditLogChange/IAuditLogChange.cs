using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represent an AuditLogChange with T as Value Type
	/// </summary>
	/// <typeparam name="T">The Type of the changed Value</typeparam>
	public interface IAuditLogChange<T>
	{
		/// <summary>
		///     new value of the key
		/// </summary>
		[JsonProperty("new_value")]
		public T NewValue { get; set; }

		/// <summary>
		///     old value of the key
		/// </summary>
		[JsonProperty("old_value")]
		public T OldValue { get; set; }
	}
}
