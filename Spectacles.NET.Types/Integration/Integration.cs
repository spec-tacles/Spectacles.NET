using System;
using Newtonsoft.Json;

namespace Spectacles.NET.Types
{
	public class Integration
	{
		/// <summary>
		///     integration id
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     integration name
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// 	integration type (twitch, youtube, etc)
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }
		
		/// <summary>
		/// 	is this integration enabled
		/// </summary>
		[JsonProperty("enabled")]
		public bool? Enabled { get; set; }
		
		/// <summary>
		/// 	is this integration syncing
		/// </summary>
		[JsonProperty("syncing")]
		public bool? Syncing { get; set; }
		
		/// <summary>
		/// 	is that this integration uses for "subscribers"
		/// </summary>
		[JsonProperty("role_id")]
		public string RoleId { get; set; }
		
		/// <summary>
		/// 	the behavior of expiring subscribers
		/// </summary>
		[JsonProperty("expire_behavior")]
		public int? ExpireBehavior { get; set; }
		
		/// <summary>
		/// 	the grace period before expiring subscribers
		/// </summary>
		[JsonProperty("expire_grace_period")]
		public int? ExpireGracePeriod { get; set; }
		
		/// <summary>
		/// 	user for this integration
		/// </summary>
		[JsonProperty("user")]
		public User User { get; set; }
		
		/// <summary>
		/// 	integration account information
		/// </summary>
		[JsonProperty("account")]
		public IntegrationAccount Account { get; set; }
		
		/// <summary>
		/// 	when this integration was last synced
		/// </summary>
		[JsonProperty("synced_at")]
		public DateTime SyncedAt { get; set; }
	}
}
