using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentUserDMView : View
	{
		protected override string Route
			=> $"{APIEndpoints.CurrentUserDMs}";
		
		public CurrentUserDMView(RestClient client) : base(client)
		{
		}
	}
}