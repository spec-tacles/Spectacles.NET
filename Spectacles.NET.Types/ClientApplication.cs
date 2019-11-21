using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// OAuth2 application info
	/// </summary>
	public class ClientApplication
	{
		/// <summary>
		/// 	the id of the app
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }
		
		/// <summary>
		/// the name of the app
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// the icon hash of the app
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }
		
		/// <summary>
		/// the description of the app
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
		
		/// <summary>
		/// an array of rpc origin urls, if rpc is enabled
		/// </summary>
		[JsonProperty("rpc_origins")]
		public string[] RPCOrigins { get; set; }
		
		/// <summary>
		/// when false only app owner can join the app's bot to guilds
		/// </summary>
		[JsonProperty("bot_public")]
		public bool BotPublic { get; set; }
		
		/// <summary>
		/// when true the app's bot will only join upon completion of the full oauth2 code grant flow
		/// </summary>
		[JsonProperty("bot_require_code_grant")]
		public bool BotRequireCodeGrant { get; set; }
		
		/// <summary>
		/// partial user object containing info on the owner of the application
		/// </summary>
		[JsonProperty("owner")]
		public User Owner { get; set; }
		
		/// <summary>
		/// 	if this application is a game sold on Discord, this field will be the summary field for the store page of its primary sku
		/// </summary>
		[JsonProperty("summary")]
		public string Summary { get; set; }
		
		/// <summary>
		/// the base64 encoded key for the GameSDK's GetTicket
		/// </summary>
		[JsonProperty("verify_key")]
		public string VerifyKey { get; set; }
		
		/// <summary>
		/// if the application belongs to a team, this will be a list of the members of that team
		/// </summary>
		[JsonProperty("team")]
		public Team Team { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the guild to which it has been linked
		/// </summary>
		[JsonProperty("guild_id")]
		public string GuildId { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the id of the "Game SKU" that is created, if exists
		/// </summary>
		[JsonProperty("primary_sku_id")]
		public string PrimarySkuId { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the URL slug that links to the store page
		/// </summary>
		[JsonProperty("slug")]
		public string Slug { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the hash of the image on store embeds
		/// </summary>
		[JsonProperty("cover_image")]
		public string CoverImage { get; set; }
	}
}
