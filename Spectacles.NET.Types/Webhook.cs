using System.Security.Principal;

namespace Spectacles.NET.Types
{
	public class Webhook
	{
		public long ID { get; set; }
		
		public long? GuildID { get; set; }
		
		public long ChannelID { get; set; }
		
		public User User { get; set; }
		
		public string Name { get; set; }
		
		public string Avatar { get; set; }
		
		public string Token { get; set; }
	}
}