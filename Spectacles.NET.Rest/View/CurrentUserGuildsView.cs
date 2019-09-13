using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserGuildsView : View
	{
		public CurrentUserGuildsView(RestClient client) : base(client)
		{
		}

		protected override string Route
			=> $"{APIEndpoints.CurrentUserGuilds}";
	}
}
