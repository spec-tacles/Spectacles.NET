using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class InvitesView : View
	{
		public InvitesView(RestClient client) : base(client)
		{
		}

		public InvitesView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public InvitesView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.Invite(Id)}";
	}
}
