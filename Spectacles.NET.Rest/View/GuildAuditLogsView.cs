using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class GuildAuditLogsView : View
	{
		protected override string Route
			=> $"{APIEndpoints.GuildAuditLogs(GuildID)}";
		
		private string GuildID { get; }
		
		public GuildAuditLogsView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}