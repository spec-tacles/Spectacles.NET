using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildAuditLogsView : View
	{
		public GuildAuditLogsView(RestClient client, string guildId) : base(client)
			=> GuildId = guildId;

		public GuildAuditLogsView this[long id]
		{
			get
			{
				Id = id.ToString();
				return this;
			}
		}

		public GuildAuditLogsView this[string id]
		{
			get
			{
				Id = id;
				return this;
			}
		}

		protected override string Route
			=> $"{APIEndpoints.GuildAuditLogs(GuildId)}";

		private string GuildId { get; }
	}
}
