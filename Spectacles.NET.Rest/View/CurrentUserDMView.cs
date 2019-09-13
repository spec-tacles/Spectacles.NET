using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserDMView : View
	{
		public CurrentUserDMView(RestClient client) : base(client)
		{
		}

		protected override string Route
			=> $"{APIEndpoints.CurrentUserDMs}";
	}
}
