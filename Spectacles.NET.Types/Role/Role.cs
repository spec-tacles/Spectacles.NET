using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Roles represent a set of permissions attached to a group of users. Roles have unique names, colors, and can be
	///     "pinned" to the side bar, causing their members to be listed separately. Roles are unique per guild, and can have
	///     separate permission profiles for the global context (guild) and channel context.
	/// </summary>
	[DataContract]
	public class Role
	{
		/// <summary>
		///     role id
		/// </summary>
		[DataMember(Name = "id", Order = 1)]
		public string Id { get; set; }

		/// <summary>
		///     role name
		/// </summary>
		[DataMember(Name = "name", Order = 2)]
		public string Name { get; set; }

		/// <summary>
		///     integer representation of hexadecimal color code
		/// </summary>
		[DataMember(Name = "color", Order = 3)]
		public int Color { get; set; }

		/// <summary>
		///     if this role is pinned in the user listing
		/// </summary>
		[DataMember(Name = "hoist", Order = 4)]
		public bool Hoist { get; set; }

		/// <summary>
		///     position of this role
		/// </summary>
		[DataMember(Name = "position", Order = 5)]
		public int Position { get; set; }

		/// <summary>
		///     permission bit set
		/// </summary>
		[DataMember(Name = "permissions", Order = 6)]
		public int Permissions { get; set; }

		/// <summary>
		///     whether this role is managed by an integration
		/// </summary>
		[DataMember(Name = "managed", Order = 7)]
		public bool Managed { get; set; }

		/// <summary>
		///     whether this role is mentionable
		/// </summary>
		[DataMember(Name = "mentionable", Order = 8)]
		public bool Mentionable { get; set; }
	}
}
