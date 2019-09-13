using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserChannelsView : View
	{
		public CurrentUserChannelsView(RestClient client) : base(client)
		{
		}

		protected override string Route
			=> $"{APIEndpoints.CurrentUserDMs}";
	}
}
