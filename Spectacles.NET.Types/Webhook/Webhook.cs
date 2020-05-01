using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{

	/// <summary>
	///     Webhooks are a low-effort way to post messages to channels in Discord. They do not require a bot user or
	///     authentication to use.
	/// </summary>
	[DataContract]
	public class Webhook
	{
		/// <summary>
		///     the id of the webhook
		/// </summary>
		[DataMember(Name = "id", Order = 1)]
		public long Id { get; set; }

		/// <summary>
		///     the guild id this webhook is for
		/// </summary>
		[DataMember(Name = "guild_id", Order = 2)]
		public long? GuildId { get; set; }

		/// <summary>
		///     the channel id this webhook is for
		/// </summary>
		[DataMember(Name = "channel_id", Order = 3)]
		public long ChannelId { get; set; }

		/// <summary>
		///     the user this webhook was created by (not returned when getting a webhook with its token)
		/// </summary>
		[DataMember(Name = "user", Order = 4)]
		public User User { get; set; }

		/// <summary>
		///     the default name of the webhook
		/// </summary>
		[DataMember(Name = "name", Order = 5)]
		public string Name { get; set; }

		/// <summary>
		///     the default avatar of the webhook
		/// </summary>
		[DataMember(Name = "avatar", Order = 6)]
		public string Avatar { get; set; }

		/// <summary>
		///     the secure token of the webhook
		/// </summary>
		[DataMember(Name = "token", Order = 7)]
		public string Token { get; set; }
	}
}
