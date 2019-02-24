namespace Spectacles.NET.Rest.View
{
	public class CurrentUserDMView : View
	{
		protected override string Route { get; }
		
		public CurrentUserDMView(RestClient client) : base(client)
		{
		}
	}
}