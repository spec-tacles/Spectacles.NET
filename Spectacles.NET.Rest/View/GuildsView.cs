using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildsView : View
	{
		public GuildsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		protected override string Route 
			=> $"{(ID == null ? APIEndpoints.Guilds : APIEndpoints.Guild(ID))}";

		public GuildsView(RestClient client) : base(client)
		{
		}
	}
}