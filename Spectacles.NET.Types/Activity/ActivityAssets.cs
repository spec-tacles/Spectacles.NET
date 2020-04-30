using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Assets for an Activity
	/// </summary>
	[DataContract]
	public class ActivityAssets
	{
		/// <summary>
		///     the id for a large asset of the activity, usually a snowflake
		/// </summary>
		[DataMember(Name="large_image", Order=1)]
		public string LargeImage { get; set; }

		/// <summary>
		///     text displayed when hovering over the large image of the activity
		/// </summary>
		[DataMember(Name="large_text", Order=2)]
		public string LargeText { get; set; }

		/// <summary>
		///     the id for a small asset of the activity, usually a snowflake
		/// </summary>
		[DataMember(Name="small_image", Order=3)]
		public string SmallImage { get; set; }

		/// <summary>
		///     text displayed when hovering over the small image of the activity
		/// </summary>
		[DataMember(Name="small_text", Order=4)]
		public string SmallText { get; set; }
	}
}
