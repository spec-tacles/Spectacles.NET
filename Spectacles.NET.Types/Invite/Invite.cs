using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Represents a code that when used, adds a user to a guild or group DM channel.
	/// </summary>
	[DataContract]
	public class Invite
	{
		/// <summary>
		///     the invite code (unique Id)
		/// </summary>
		[DataMember(Name="code", Order=1)]
		public string Code { get; set; }

		/// <summary>
		///     the guild this invite is for
		/// </summary>
		[DataMember(Name="Guild", Order=2)]
		public Guild Guild { get; set; }

		/// <summary>
		///     the channel this invite is for
		/// </summary>
		[DataMember(Name="channel", Order=3)]
		public Channel Channel { get; set; }

		/// <summary>
		///     the target user for this invite
		/// </summary>
		[DataMember(Name="target_user", Order=4)]
		public User TargetUser { get; set; }

		/// <summary>
		///     the type of target user for this invite
		/// </summary>
		[DataMember(Name="target_user_type", Order=5)]
		public UserType? TargetUserType { get; set; }

		/// <summary>
		///     approximate count of online members
		/// </summary>
		[DataMember(Name="approximate_presence_count", Order=6)]
		public int ApproximatePresenceCount { get; set; }

		/// <summary>
		///     approximate count of total members
		/// </summary>
		[DataMember(Name="approximate_member_count", Order=7)]
		public int ApproximateMemberCount { get; set; }
	}
}
