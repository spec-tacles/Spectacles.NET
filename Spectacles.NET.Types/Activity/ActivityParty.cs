using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class ActivityParty
	{
		/// <summary>
		///     the id of the party
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     used to show the party's current and maximum size
		/// </summary>
		[JsonProperty("size")]
		public List<int> Size { get; set; }
	}
}
