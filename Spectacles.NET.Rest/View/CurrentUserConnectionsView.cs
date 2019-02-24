using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserConnectionsView : View
	{
		protected override string Route
			=> $"{APIEndpoints.CurrentUserConnections}";
		
		public CurrentUserConnectionsView(RestClient client) : base(client)
		{
		}
	}
}