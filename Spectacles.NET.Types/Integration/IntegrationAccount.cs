using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// The information account for an integration.
	/// </summary>
	[DataContract]
	public class IntegrationAccount
	{
		/// <summary>
		///     integration account id
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     integration account name
		/// </summary>
		[DataMember(Name="name", Order=2)]
		public string Name { get; set; }
	}
}
