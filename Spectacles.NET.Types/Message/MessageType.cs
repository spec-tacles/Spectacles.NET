namespace Spectacles.NET.Types
{
	/// <summary>
	/// Type of a Message in Discord.
	/// </summary>
	public enum MessageType
	{
		/// <summary>
		/// Default Message Type
		/// </summary>
		DEFAULT,
		
		/// <summary>
		/// Recipient Add Message Type
		/// </summary>
		RECIPIENT_ADD,
		
		/// <summary>
		/// Recipient Remove Message Type
		/// </summary>
		RECIPIENT_REMOVE,
		
		/// <summary>
		/// Call Message Type
		/// </summary>
		CALL,
		
		/// <summary>
		/// Channel Name Change Type
		/// </summary>
		CHANNEL_NAME_CHANGE,
		
		/// <summary>
		/// Channel Icons Change Type
		/// </summary>
		CHANNEL_ICON_CHANGE,
		
		/// <summary>
		/// Channel Pinned Message Change Type
		/// </summary>
		CHANNEL_PINNED_MESSAGE,
		
		/// <summary>
		/// Guild Member Join Message Type
		/// </summary>
		GUILD_MEMBER_JOIN,
		
		/// <summary>
		/// User Premium Guild Subscription Message Type
		/// </summary>
		USER_PREMIUM_GUILD_SUBSCRIPTION,
		
		/// <summary>
		/// User Premium Guild Subscription Tier 1 Message Type
		/// </summary>
		USER_PREMIUM_GUILD_SUBSCRIPTION_TIER_1,
		
		/// <summary>
		/// User Premium Guild Subscription Tier 2 Message Type
		/// </summary>
		USER_PREMIUM_GUILD_SUBSCRIPTION_TIER_2,
		
		/// <summary>
		/// User Premium Guild Subscription Tier 3 Message Type
		/// </summary>
		USER_PREMIUM_GUILD_SUBSCRIPTION_TIER_3,
		
		/// <summary>
		/// Channel Follow Add Message Type
		/// </summary>
		CHANNEL_FOLLOW_ADD
	}
}
