using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserChannelsView : View
	{
		protected override string Route
			=> $"{APIEndpoints.CurrentUserDMs}";
		
		public CurrentUserChannelsView(RestClient client) : base(client)
		{
		}
	}
}