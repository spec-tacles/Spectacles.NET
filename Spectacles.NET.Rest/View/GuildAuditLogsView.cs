using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildAuditLogsView : View
	{
		public GuildAuditLogsView(RestClient client, string guildID) : base(client)
			=> GuildID = guildID;

		public GuildAuditLogsView this[long id]
		{
			get
			{
				ID = id.ToString();
				return this;
			}
		}

		public GuildAuditLogsView this[string id]
		{
			get
			{
				ID = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildAuditLogs(GuildID)}";

		private string GuildID { get; }
	}
}
