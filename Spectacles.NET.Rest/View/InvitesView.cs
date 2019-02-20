using System;
using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class InvitesView : View
	{
		public InvitesView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public InvitesView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		protected override string Route
			=> $"{APIEndpoints.Invite(ID)}";
		
		public InvitesView(RestClient client) : base(client)
		{
		}
	}
}