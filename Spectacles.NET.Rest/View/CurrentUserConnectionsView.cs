using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserConnectionsView : View
	{
		public CurrentUserConnectionsView(RestClient client) : base(client)
		{
		}

		protected override string Route
			=> $"{APIEndpoints.CurrentUserConnections}";
	}
}
