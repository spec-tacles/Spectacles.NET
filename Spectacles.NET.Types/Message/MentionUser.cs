using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <inheritdoc />
	[DataContract]
	public class MentionUser : User
	{
		/// <summary>
		///     Optional Field for <see cref="Message" /> Mention Field
		/// </summary>
		[DataMember(Name="member", Order=1)]
		public GuildMember Member { get; set; }
	}
}
