using System;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// The flags on a user's account.
	/// </summary>
	[Flags]
	public enum UserFlags
	{
		/// <summary>
		/// 	None
		/// </summary>
		NONE = 0,
		
		/// <summary>
		/// 	Discord Employee
		/// </summary>
		DISCORD_EMPLOYEE = 1,
		
		/// <summary>
		/// Discord Partner
		/// </summary>
		DISCORD_PARTNER = 1 << 1,
		
		/// <summary>
		/// HypeSquad Events
		/// </summary>
		HYPESQUAD_EVENTS = 1 << 2,
		
		/// <summary>
		/// Bug Hunter
		/// </summary>
		BUG_HUNTER = 1 << 3,
		
		/// <summary>
		/// House Bravery
		/// </summary>
		HOUSE_BRAVERY = 1 << 6,
		
		/// <summary>
		/// House Brilliance
		/// </summary>
		HOUSE_BRILLIANCE = 1 << 7,
		
		/// <summary>
		/// House Balance

		/// </summary>
		HOUSE_BALANCE = 1 << 8,
		
		/// <summary>
		/// Early Supporter
		/// </summary>
		EARLY_SUPPORTER = 1 << 9,
		
		/// <summary>
		/// Team User
		/// </summary>
		TEAM_USER = 1 << 10,
		
		/// <summary>
		/// System
		/// </summary>
		SYSTEM = 1 << 12
	}
}
