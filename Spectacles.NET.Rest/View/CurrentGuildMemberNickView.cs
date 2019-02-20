using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.View
{
	public class CurrentGuildMemberNickView : View
	{
		protected override string Route
			=> $"{APIEndpoints.CurrentGuildMember(GuildID)}";
		
		private string GuildID { get; }
		
		public CurrentGuildMemberNickView(RestClient client, string guildID) : base(client)
		{
			GuildID = guildID;
		}
	}
}