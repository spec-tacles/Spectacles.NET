using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Represents a code that when used, adds a user to a guild or group DM channel.
	/// </summary>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Invite
	{
		/// <summary>
		/// the invite code (unique ID)
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }
		
		/// <summary>
		/// the guild this invite is for
		/// </summary>
		[JsonProperty("Guild")]
		public Guild Guild { get; set; }
		
		/// <summary>
		/// the channel this invite is for
		/// </summary>
		[JsonProperty("channel")]
		public Channel Channel { get; set; }
		
		/// <summary>
		/// approximate count of online members
		/// </summary>
		[JsonProperty("approximate_presence_count")]
		public int ApproximatePresenceCount { get; set; }
		
		/// <summary>
		/// approximate count of total members
		/// </summary>
		[JsonProperty("approximate_member_count")]
		public int ApproximateMemberCount { get; set; }
	}
}