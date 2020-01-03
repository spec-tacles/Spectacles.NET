using System;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Flags a Message can have.
	/// </summary>
	[Flags]
	public enum MessageFlags
	{
		/// <summary>
		/// Message comes from a Cross Post.
		/// </summary>
		CROSSPOSTED = 1,
		
		/// <summary>
		/// Message is Cross Posted.
		/// </summary>
		IS_CROSSPOST = 1 << 1,
		
		/// <summary>
		/// Message Embeds are Suppressed.
		/// </summary>
		SUPPRESS_EMBEDS = 1 << 2,
		
		/// <summary>
		/// Message comes from a Cross Post which was Deleted.
		/// </summary>
		SOURCE_MESSAGE_DELETED = 1 << 3,
		
		/// <summary>
		/// Message comes from the Urgent System.
		/// </summary>
		URGENT = 1 << 4
	}
}
