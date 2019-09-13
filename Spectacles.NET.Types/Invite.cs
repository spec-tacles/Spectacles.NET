using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     the type of target user for this invite
	/// </summary>
	public enum UserType
	{
		STREAM = 1
	}

	/// <summary>
	///     Represents a code that when used, adds a user to a guild or group DM channel.
	/// </summary>
	public class Invite
	{
		/// <summary>
		///     the invite code (unique ID)
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		///     the guild this invite is for
		/// </summary>
		[JsonProperty("Guild")]
		public Guild Guild { get; set; }

		/// <summary>
		///     the channel this invite is for
		/// </summary>
		[JsonProperty("channel")]
		public Channel Channel { get; set; }

		/// <summary>
		///     the target user for this invite
		/// </summary>
		[JsonProperty("target_user")]
		public User TargetUser { get; set; }

		/// <summary>
		///     the type of target user for this invite
		/// </summary>
		[JsonProperty("target_user_type")]
		public UserType? TargetUserType { get; set; }

		/// <summary>
		///     approximate count of online members
		/// </summary>
		[JsonProperty("approximate_presence_count")]
		public int ApproximatePresenceCount { get; set; }

		/// <summary>
		///     approximate count of total members
		/// </summary>
		[JsonProperty("approximate_member_count")]
		public int ApproximateMemberCount { get; set; }
	}
}
