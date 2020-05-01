using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Base Class for AuditLogChanges
	/// </summary>
	[DataContract]
	public class AuditLogChangeBase
	{
		/// <summary>
		///     type of audit log change key
		/// </summary>
		[DataMember(Name = "key", Order = 1)]
		public string Key { get; set; }

		/// <summary>
		///		new value of the affected change.
		/// </summary>
		[DataMember(Name = "new_value", IsRequired = false, Order = 2)]
		public object NewValue { get; set; }

		/// <summary>
		///		old value of the affected change.
		/// </summary>
		[DataMember(Name = "old_value", IsRequired = false, Order = 3)]
		public object OldValue { get; set; }
	}
}
