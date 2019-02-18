using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class UsersView : View
	{
		protected override string Route
			=> $"{APIEndpoints.User(ID)}";
		
		public UsersView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public UsersView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		public UsersView(RestClient client) : base(client)
		{
		}
	}
}