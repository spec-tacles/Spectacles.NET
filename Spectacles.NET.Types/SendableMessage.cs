using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// A Message which can be sent to Discord's Rest API
	/// </summary>
	public class SendableMessage : Message
	{
		/// <summary>
		/// Files to attach to the Message
		/// </summary>
		[JsonProperty("file")]
		public IEnumerable<IFile> File { get; set; }

		/// <summary>
		/// Embed to attach to the Message
		/// </summary>
		[JsonProperty("embed")]
		public Embed Embed { get; set; }
	}
}
