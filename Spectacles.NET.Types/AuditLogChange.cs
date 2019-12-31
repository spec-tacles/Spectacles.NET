using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class AuditLogChange
	{
		/// <summary>
		///     new value of the key
		/// </summary>
		[JsonProperty("new_value")]
		public object NewValue { get; set; }

		/// <summary>
		///     old value of the key
		/// </summary>
		[JsonProperty("old_value")]
		public dynamic OldValue { get; set; }

		/// <summary>
		///     type of audit log change key
		/// </summary>
		[JsonProperty("key")]
		public string Key { get; set; }
	}
}
