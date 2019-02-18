using System;
using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class InviteView : View
	{
		public InviteView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public InviteView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}
		
		protected override string Route
			=> $"{APIEndpoints.Invite(ID)}";
		
		public InviteView(RestClient client) : base(client)
		{
		}
	}
}