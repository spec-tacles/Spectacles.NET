using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
	/// <summary>
	/// OAuth2 application info
	/// </summary>
	[DataContract]
	public class ClientApplication
	{
		/// <summary>
		/// 	the id of the app
		/// </summary>
		[DataMember(Name="id", Order=1)]
		public string Id { get; set; }
		
		/// <summary>
		/// the name of the app
		/// </summary>
		[DataMember(Name="name", Order=2)]
		public string Name { get; set; }
		
		/// <summary>
		/// the icon hash of the app
		/// </summary>
		[DataMember(Name="icon", Order=3)]
		public string Icon { get; set; }
		
		/// <summary>
		/// the description of the app
		/// </summary>
		[DataMember(Name="description", Order=4)]
		public string Description { get; set; }
		
		/// <summary>
		/// an array of rpc origin urls, if rpc is enabled
		/// </summary>
		[DataMember(Name="rpc_origins", Order=5)]
		public string[] RPCOrigins { get; set; }
		
		/// <summary>
		/// when false only app owner can join the app's bot to guilds
		/// </summary>
		[DataMember(Name="bot_public", Order=6)]
		public bool BotPublic { get; set; }
		
		/// <summary>
		/// when true the app's bot will only join upon completion of the full oauth2 code grant flow
		/// </summary>
		[DataMember(Name="bot_require_code_grant", Order=7)]
		public bool BotRequireCodeGrant { get; set; }
		
		/// <summary>
		/// partial user object containing info on the owner of the application
		/// </summary>
		[DataMember(Name="owner", Order=8)]
		public User Owner { get; set; }
		
		/// <summary>
		/// 	if this application is a game sold on Discord, this field will be the summary field for the store page of its primary sku
		/// </summary>
		[DataMember(Name="summary", Order=9)]
		public string Summary { get; set; }
		
		/// <summary>
		/// the base64 encoded key for the GameSDK's GetTicket
		/// </summary>
		[DataMember(Name="verify_key", Order=10)]
		public string VerifyKey { get; set; }
		
		/// <summary>
		/// if the application belongs to a team, this will be a list of the members of that team
		/// </summary>
		[DataMember(Name="team", Order=11)]
		public Team Team { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the guild to which it has been linked
		/// </summary>
		[DataMember(Name="guild_id", Order=12)]
		public string GuildId { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the id of the "Game SKU" that is created, if exists
		/// </summary>
		[DataMember(Name="primary_sku_id", Order=13)]
		public string PrimarySkuId { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the URL slug that links to the store page
		/// </summary>
		[DataMember(Name="slug", Order=14)]
		public string Slug { get; set; }
		
		/// <summary>
		/// if this application is a game sold on Discord, this field will be the hash of the image on store embeds
		/// </summary>
		[DataMember(Name="cover_image", Order=15)]
		public string CoverImage { get; set; }
	}
}
