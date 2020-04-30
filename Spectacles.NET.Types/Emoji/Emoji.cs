using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     An Emoji Represents a custom or unicode emote.
	///		See <a href="http://discordapp.com/developers/docs/resources/emoji">this</a>.
	/// </summary>
	[DataContract]
	public class Emoji
	{
		/// <summary>
		///     emoji id
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     emoji name
		/// </summary>
		[DataMember(Name="name", Order=1)]
		public string Name { get; set; }

		/// <summary>
		///     roles this emoji is whitelisted to
		/// </summary>
		[DataMember(Name="roles", Order=1)]
		public List<string> Roles { get; set; }

		/// <summary>
		///     user that created this emoji
		/// </summary>
		[DataMember(Name="user", Order=1)]
		public User User { get; set; }

		/// <summary>
		///     whether this emoji must be wrapped in colons
		/// </summary>
		[DataMember(Name="require_colons", Order=1)]
		public bool? RequireColons { get; set; }

		/// <summary>
		///     whether this emoji is managed
		/// </summary>
		[DataMember(Name="managed", Order=1)]
		public bool? Managed { get; set; }

		/// <summary>
		///     whether this emoji is animated
		/// </summary>
		[DataMember(Name="animated", Order=1)]
		public bool? Animated { get; set; }
	}
}
