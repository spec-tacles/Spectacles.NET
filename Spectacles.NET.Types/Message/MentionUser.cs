using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <inheritdoc />
	public class MentionUser : User
	{
		/// <summary>
		///     Optional Field for <see cref="Message" /> Mention Field
		/// </summary>
		[JsonProperty("member")]
		public GuildMember Member { get; set; }
	}
}
