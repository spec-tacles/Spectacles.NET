using System;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// 	Options to send while Identifying
	/// </summary>
	public class IdentifyOptions : ICloneable
	{
		/// <summary>
		/// 	value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild member list
		/// </summary>
		public int? LargeThreshold { get; set; }
		
		/// <summary>
		/// 	presence structure for initial presence information	
		/// </summary>
		public UpdateStatusDispatch Presence { get; set; }
		
		/// <summary>
		/// 	enables dispatching of guild subscription events (presence and typing events)	
		/// </summary>
		public bool? GuildSubscriptions { get; set; }

		/// <inheritdoc />
		public object Clone()
			=> MemberwiseClone();
	}
}
