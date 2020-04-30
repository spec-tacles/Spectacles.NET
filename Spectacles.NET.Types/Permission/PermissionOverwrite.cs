using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a permission overwrite for a role or member in a guild channel.
	/// </summary>
	[DataContract]
	public class PermissionOverwrite
	{
		/// <summary>
		///     role or user id
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     either "role" or "member"
		/// </summary>
		[DataMember(Name="type", Order=2)]
		public string Type { get; set; }

		/// <summary>
		///     permission bit set
		/// </summary>
		[DataMember(Name="allow", Order=3)]
		public Permission Allow { get; set; }

		/// <summary>
		///     permission bit set
		/// </summary>
		[DataMember(Name="deny", Order=4)]
		public Permission Deny { get; set; }
	}
}
