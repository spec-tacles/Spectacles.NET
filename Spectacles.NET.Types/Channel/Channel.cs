// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Discord Channel Represents a guild or DM channel within Discord.
	///     See <a href="http://discordapp.com/developers/docs/resources/channel">here</a>.
	/// </summary>
	[DataContract]
	public class Channel
	{
		/// <summary>
		///     The id of this channel
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     the type of channel see <see cref="ChannelType" />
		/// </summary>
		[DataMember(Name="type", Order=2)]
		public ChannelType Type { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[DataMember(Name="guild_id", Order=3)]
		public string GuildId { get; set; }

		/// <summary>
		///     sorting position of the channel
		/// </summary>
		[DataMember(Name="position", Order=4)]
		public int? Position { get; set; }

		/// <summary>
		///     explicit permission overwrites for members and roles
		/// </summary>
		[DataMember(Name="permission_overwrites", Order=5)]
		public List<PermissionOverwrite> PermissionOverwrites { get; set; }

		/// <summary>
		///     the name of the channel (2-100 characters)
		/// </summary>
		[DataMember(Name="name", Order=6)]
		public string Name { get; set; }

		/// <summary>
		///     the channel topic (0-1024 characters)
		/// </summary>
		[DataMember(Name="topic", Order=7)]
		public string Topic { get; set; }

		/// <summary>
		///     whether the channel is nsfw
		/// </summary>
		[DataMember(Name="nsfw", Order=8)]
		public bool? NSFW { get; set; }

		/// <summary>
		///     the id of the last message sent in this channel (may not point to an existing or valid message)
		/// </summary>
		[DataMember(Name="last_message_id", Order=9)]
		public string LastMessageId { get; set; }

		/// <summary>
		///     the bitrate (in bits) of the voice channel
		/// </summary>
		[DataMember(Name="bitrate", Order=10)]
		public int? Bitrate { get; set; }

		/// <summary>
		///     the user limit of the voice channel
		/// </summary>
		[DataMember(Name="user_limit", Order=11)]
		public int? UserLimit { get; set; }

		/// <summary>
		///     amount of seconds a user has to wait before sending another message (0-120); bots, as well as users with the
		///     permission manage_messages or manage_channel, are unaffected
		/// </summary>
		[DataMember(Name="rate_limit_per_user", Order=12)]
		public int? RateLimitPerUser { get; set; }

		/// <summary>
		///     the recipients of the DM
		/// </summary>
		[DataMember(Name="recipients", Order=13)]
		public List<User> Recipients { get; set; }

		/// <summary>
		///     icon hash
		/// </summary>
		[DataMember(Name="icon", Order=14)]
		public string Icon { get; set; }

		/// <summary>
		///     id of the DM creator
		/// </summary>
		[DataMember(Name="owner_id", Order=15)]
		public string OwnerId { get; set; }

		/// <summary>
		///     application id of the group DM creator if it is bot-created
		/// </summary>
		[DataMember(Name="application_id", Order=16)]
		public string ApplicationId { get; set; }

		/// <summary>
		///     id of the parent category for a channel
		/// </summary>
		[DataMember(Name="parent_id", Order=17)]
		public string ParentId { get; set; }

		/// <summary>
		///     when the last pinned message was pinned
		/// </summary>
		[DataMember(Name="last_pin_timestamp", Order=18)]
		public string LastPinTimestamp { get; set; }
	}
}
