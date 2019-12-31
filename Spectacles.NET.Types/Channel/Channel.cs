// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     A Discord Channel Represents a guild or DM channel within Discord.
	///     <see cref="http://discordapp.com/developers/docs/resources/channel" />
	/// </summary>
	public class Channel
	{
		/// <summary>
		///     The id of this channel
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     the type of channel see <see cref="ChannelType" />
		/// </summary>
		[JsonProperty("type")]
		public ChannelType Type { get; set; }

		/// <summary>
		///     the id of the guild
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }

		/// <summary>
		///     sorting position of the channel
		/// </summary>
		[JsonProperty("position")]
		public int? Position { get; set; }

		/// <summary>
		///     explicit permission overwrites for members and roles
		/// </summary>
		[JsonProperty("permission_overwrites")]
		public List<PermissionOverwrite> PermissionOverwrites { get; set; }

		/// <summary>
		///     the name of the channel (2-100 characters)
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     the channel topic (0-1024 characters)
		/// </summary>
		[JsonProperty("topic")]
		public string Topic { get; set; }

		/// <summary>
		///     whether the channel is nsfw
		/// </summary>
		[JsonProperty("nsfw")]
		public bool? NSFW { get; set; }

		/// <summary>
		///     the id of the last message sent in this channel (may not point to an existing or valid message)
		/// </summary>
		[JsonProperty("last_message_id")]
		public string LastMessageId { get; set; }

		/// <summary>
		///     the bitrate (in bits) of the voice channel
		/// </summary>
		[JsonProperty("bitrate")]
		public int? Bitrate { get; set; }

		/// <summary>
		///     the user limit of the voice channel
		/// </summary>
		[JsonProperty("user_limit")]
		public int? UserLimit { get; set; }

		/// <summary>
		///     amount of seconds a user has to wait before sending another message (0-120); bots, as well as users with the
		///     permission manage_messages or manage_channel, are unaffected
		/// </summary>
		[JsonProperty("rate_limit_per_user")]
		public int? RateLimitPerUser { get; set; }

		/// <summary>
		///     the recipients of the DM
		/// </summary>
		[JsonProperty("recipients")]
		public List<User> Recipients { get; set; }

		/// <summary>
		///     icon hash
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		///     id of the DM creator
		/// </summary>
		[JsonProperty("owner_id")]
		public string OwnerId { get; set; }

		/// <summary>
		///     application id of the group DM creator if it is bot-created
		/// </summary>
		[JsonProperty("application_id")]
		public string ApplicationId { get; set; }

		/// <summary>
		///     id of the parent category for a channel
		/// </summary>
		[JsonProperty("parent_id")]
		public string ParentId { get; set; }

		/// <summary>
		///     when the last pinned message was pinned
		/// </summary>
		[JsonProperty("last_pin_timestamp")]
		public string LastPinTimestamp { get; set; }
	}
}
