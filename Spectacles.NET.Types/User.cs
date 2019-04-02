// ReSharper disable UnusedMember.Global

using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	[Flags]
	public enum UserFlags
	{
		NONE = 0,
		HYPESQUAD_EVENTS = 1 << 2,
		HOUSE_BRAVERY = 1 << 6,
		HOUSE_BRILLIANCE = 1 << 7,
		HOUSE_BALANCE = 1 << 8
	}

	public enum PremiumType
	{
		CLASSIC = 1,
		NITRO = 2
	}
	
	/// <summary>
	/// Users in Discord are generally considered the base entity. Users can spawn across the entire platform, be members of guilds, participate in text and voice chat, and much more. Users are separated by a distinction of "bot" vs "normal." Although they are similar, bot users are automated users that are "owned" by another user. Unlike normal users, bot users do not have a limitation on the number of Guilds they can be a part of.
	/// </summary>
	public class User
	{
		/// <summary>
		/// the user's id
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }
		
		/// <summary>
		/// the user's username, not unique across the platform
		/// </summary>
		[JsonProperty("username")]
		public string Username { get; set; }
		
		/// <summary>
		/// the user's 4-digit discord-tag
		/// </summary>
		[JsonProperty("discriminator")]
		public string Discriminator { get; set; }
		
		/// <summary>
		/// the user's avatar hash	
		/// </summary>
		[JsonProperty("avatar")]
		public string Avatar { get; set; }
		
		/// <summary>
		/// whether the user belongs to an OAuth2 application
		/// </summary>
		[JsonProperty(PropertyName = "bot", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(false)]
		public bool Bot { get; set; }
		
		/// <summary>
		/// whether the user has two factor enabled on their account	
		/// </summary>
		[JsonProperty(PropertyName = "mfa_enabled", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(false)]
		public bool MfaEnabled { get; set; }
		
		/// <summary>
		/// the user's chosen language option
		/// </summary>
		[JsonProperty("locale")]
		public string Locale { get; set; }
		
		/// <summary>
		/// whether the email on this account has been verified	
		/// </summary>
		[JsonProperty("verified")]
		public bool Verified { get; set; }
		
		/// <summary>
		/// the user's email
		/// </summary>
		[JsonProperty("email")]
		public string Email { get; set; }
		
		/// <summary>
		/// the <see cref="UserFlags"/> on a user's account
		/// </summary>
		[JsonProperty("flags")]
		public UserFlags Flags { get; set; }
		
		/// <summary>
		/// the <see cref="PremiumType"/> of Nitro subscription on a user's account	
		/// </summary>
		[JsonProperty("premium_type")]
		public PremiumType PremiumType { get; set; }
		
		/// <summary>
		/// Optional Field for <see cref="Message"/> Mention Field
		/// </summary>
		[JsonProperty("member")]
		public GuildMember Member { get; set; }
	}
}