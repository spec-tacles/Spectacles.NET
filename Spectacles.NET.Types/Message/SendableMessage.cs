using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// A Message which can be sent to Discord's Rest API
	/// </summary>
	[DataContract]
	public class SendableMessage : Message
	{
		/// <summary>
		/// Files to attach to the Message
		/// </summary>
		[DataMember(Name="file", Order=1)]
		public IEnumerable<IFile> File { get; set; }

		/// <summary>
		/// Embed to attach to the Message
		/// </summary>
		[DataMember(Name="embed", Order=2)]
		public Embed Embed { get; set; }
		
		/// <summary>
		/// allowed mentions for a message
		/// </summary>
		[DataMember(Name="allowed_mentions", Order=3)]
		public AllowedMentions AllowedMentions { get; set; }
	}
}
