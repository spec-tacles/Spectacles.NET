namespace Spectacles.NET.Rest.View
{
	public class ChannelsView : View
	{
		public ChannelsView(RestClient client) : base(client)
		{
		}

		protected override string Route { get; }
	}
}