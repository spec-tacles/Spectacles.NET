using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// Field of an Embed
	/// </summary>
	[DataContract]
	public class EmbedField
	{
		/// <summary>
		///     name of the field
		/// </summary>
		[DataMember(Name="name", Order=1)]
		public string Name { get; set; }

		/// <summary>
		///     value of the field
		/// </summary>
		[DataMember(Name="value", Order=2)]
		public string Value { get; set; }

		/// <summary>
		///     whether or not this field should display inline
		/// </summary>
		[DataMember(Name="inline", Order=3)]
		public bool? Inline { get; set; }
	}
}
