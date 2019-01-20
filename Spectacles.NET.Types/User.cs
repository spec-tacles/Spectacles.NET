// ReSharper disable UnusedMember.Global

using System.ComponentModel;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
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
	
	public class User
	{
		[JsonProperty("id")]
		public string ID { get; set; }
		
		[JsonProperty("username")]
		public string Username { get; set; }
		
		[JsonProperty("discriminator")]
		public string Discriminator { get; set; }
		
		[JsonProperty("avatar")]
		public string Avatar { get; set; }
		
		[JsonProperty(PropertyName = "bot", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(false)]
		public bool Bot { get; set; }
		
		[JsonProperty(PropertyName = "mfa_enabled", DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(false)]
		public bool MfaEnabled { get; set; }
		
		[JsonProperty("locale")]
		public string Locale { get; set; }
		
		[JsonProperty("verified")]
		public bool Verified { get; set; }
		
		[JsonProperty("email")]
		public string Email { get; set; }
		
		[JsonProperty("flags")]
		public UserFlags Flags { get; set; }
		
		[JsonProperty("premium_type")]
		public PremiumType PremiumType { get; set; }
	}
}