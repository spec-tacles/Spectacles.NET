using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildsView : View
	{
		protected override string Route 
			=> $"{APIEndpoints.BaseURL}/{(ID == null ? APIEndpoints.Guilds : APIEndpoints.Guild((int) ID))}";

		public GuildsView(RestClient client) : base(client)
		{
		}
	}
}