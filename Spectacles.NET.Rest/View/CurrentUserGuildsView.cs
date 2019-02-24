using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserGuildsView : View
	{
		protected override string Route
			=> $"{APIEndpoints.CurrentUserGuilds}";
		
		public CurrentUserGuildsView(RestClient client) : base(client)
		{
		}
	}
}