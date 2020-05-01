using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	///     Users in Discord are generally considered the base entity. Users can spawn across the entire platform, be members
	///     of guilds, participate in text and voice chat, and much more. Users are separated by a distinction of "bot" vs
	///     "normal." Although they are similar, bot users are automated users that are "owned" by another user. Unlike normal
	///     users, bot users do not have a limitation on the number of Guilds they can be a part of.
	/// </summary>
	[DataContract]
	public class User
	{
		/// <summary>
		///     the user's id
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }

		/// <summary>
		///     the user's username, not unique across the platform
		/// </summary>
		[DataMember(Name="username", Order=2)]
		public string Username { get; set; }

		/// <summary>
		///     the user's 4-digit discord-tag
		/// </summary>
		[DataMember(Name="discriminator", Order=3)]
		public string Discriminator { get; set; }

		/// <summary>
		///     the user's avatar hash
		/// </summary>
		[DataMember(Name="avatar", Order=4)]
		public string Avatar { get; set; }

		/// <summary>
		///     whether the user belongs to an OAuth2 application
		/// </summary>
		[IgnoreDataMember]
		public bool Bot
		{
			get => _bot ?? false;
			set => _bot = value;
		}
		
		/// <summary>
		/// 	whether the user is an Official Discord System user (part of the urgent message system)	
		/// </summary>
		[DataMember(Name="system", Order=5)]
		public bool? System { get; set; }

		/// <summary>
		///     whether the user has two factor enabled on their account
		/// </summary>
		[DataMember(Name="mfa_enabled", Order=6)]
		public bool? MfaEnabled { get; set; }

		/// <summary>
		///     the user's chosen language option
		/// </summary>
		[DataMember(Name="locale", Order=7)]
		public string Locale { get; set; }

		/// <summary>
		///     whether the email on this account has been verified
		/// </summary>
		[DataMember(Name="verified", Order=8)]
		public bool? Verified { get; set; }

		/// <summary>
		///     the user's email
		/// </summary>
		[DataMember(Name="email", Order=9)]
		public string Email { get; set; }

		/// <summary>
		///     the <see cref="UserFlags" /> on a user's account
		/// </summary>
		[DataMember(Name="flags", Order=10)]
		public UserFlags? Flags { get; set; }

		/// <summary>
		///     the <see cref="PremiumType" /> of Nitro subscription on a user's account
		/// </summary>
		[DataMember(Name="premium_type", Order=11)]
		public PremiumType? PremiumType { get; set; }
		
		/// <summary>
		///     whether the user belongs to an OAuth2 application
		/// </summary>
		[DataMember(Name="bot", Order=12)]
		private bool? _bot;
	}
}
