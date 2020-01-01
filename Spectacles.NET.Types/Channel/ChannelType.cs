namespace Spectacles.NET.Types
{
	/// <summary>
	/// Type of a Discord Channel
	/// </summary>
	public enum ChannelType
	{
		/// <summary>
		/// a text channel within a server
		/// </summary>
		GUILD_TEXT,
		
		/// <summary>
		/// 	a direct message between users
		/// </summary>
		DM,
		
		/// <summary>
		/// a voice channel within a server
		/// </summary>
		GUILD_VOICE,
		
		/// <summary>
		/// a direct message between multiple users
		/// </summary>
		GROUP_DM,
		
		/// <summary>
		/// an organizational category that contains channels
		/// </summary>
		GUILD_CATEGORY,
		
		/// <summary>
		/// a channel that users can follow and crosspost into their own server
		/// </summary>
		GUILD_NEWS,
		
		/// <summary>
		/// a channel in which game developers can sell their game on Discord
		/// </summary>
		GUILD_STORE
	}
}
