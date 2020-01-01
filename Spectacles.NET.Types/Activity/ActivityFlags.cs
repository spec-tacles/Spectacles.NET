using System;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Flags describing an Activity
	/// </summary>
	[Flags]
	public enum ActivityFlags
	{
		/// <summary>
		/// Instance Flag
		/// </summary>
		INSTANCE = 1,
		
		/// <summary>
		/// Join Flag
		/// </summary>
		JOIN = 1 << 1,
		
		/// <summary>
		/// Spectate Flag
		/// </summary>
		SPECTATE = 1 << 2,
		
		/// <summary>
		/// Join Request Flag
		/// </summary>
		JOIN_REQUEST = 1 << 3,
		
		/// <summary>
		/// Sync Flag
		/// </summary>
		SYNC = 1 << 4,
		
		/// <summary>
		/// Play Flag
		/// </summary>
		PLAY = 1 << 5
	}
}
