using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Roles represent a set of permissions attached to a group of users. Roles have unique names, colors, and can be "pinned" to the side bar, causing their members to be listed separately. Roles are unique per guild, and can have separate permission profiles for the global context (guild) and channel context.
	/// </summary>
	public class Role
	{
		/// <summary>
		/// role id
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// role name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// integer representation of hexadecimal color code
		/// </summary>
		[JsonProperty("color")]
		public int Color { get; set; }
		
		/// <summary>
		/// if this role is pinned in the user listing
		/// </summary>
		[JsonProperty("hoist")]
		public bool Hoist { get; set; }
		
		/// <summary>
		/// position of this role
		/// </summary>
		[JsonProperty("position")]
		public int Position { get; set; }
		
		/// <summary>
		/// permission bit set
		/// </summary>
		[JsonProperty("permissions")]
		public int Permissions { get; set; }
		
		/// <summary>
		/// whether this role is managed by an integration
		/// </summary>
		[JsonProperty("managed")]
		public bool Managed { get; set; }
		
		/// <summary>
		/// whether this role is mentionable
		/// </summary>
		[JsonProperty("mentionable")]
		public bool Mentionable { get; set; }
	}
}