namespace Spectacles.NET.Rest.View
{
	public class GuildChannelView : View
	{
		protected override string Route
			=> $"{PreviousRoute}";
		
		private string PreviousRoute { get; }
		
		public GuildChannelView(RestClient client, string previousRoute) : base(client)
		{
			PreviousRoute = previousRoute;
		}
	}
}