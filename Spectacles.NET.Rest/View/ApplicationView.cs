using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class ApplicationView : View
	{
		public ApplicationView(RestClient client) : base(client)
		{
		}

		protected override string Route
			=> APIEndpoints.Applications;
	}
}
