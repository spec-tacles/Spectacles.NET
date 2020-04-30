using System;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Represents a guild integration.
    /// </summary>
    public class Integration
    {
        /// <summary>
        ///     integration id
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        ///     integration name
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// 	integration type (twitch, youtube, etc)
        /// </summary>
        [DataMember(Name = "type", Order = 3)]
        public string Type { get; set; }

        /// <summary>
        /// 	is this integration enabled
        /// </summary>
        [DataMember(Name = "enabled", Order = 4)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 	is this integration syncing
        /// </summary>
        [DataMember(Name = "syncing", Order = 5)]
        public bool? Syncing { get; set; }

        /// <summary>
        /// 	is that this integration uses for "subscribers"
        /// </summary>
        [DataMember(Name = "role_id", Order = 6)]
        public string RoleId { get; set; }

        /// <summary>
        /// 	the behavior of expiring subscribers
        /// </summary>
        [DataMember(Name = "expire_behavior", Order = 7)]
        public int? ExpireBehavior { get; set; }

        /// <summary>
        /// 	the grace period before expiring subscribers
        /// </summary>
        [DataMember(Name = "expire_grace_period", Order = 8)]
        public int? ExpireGracePeriod { get; set; }

        /// <summary>
        /// 	user for this integration
        /// </summary>
        [DataMember(Name = "user", Order = 9)]
        public User User { get; set; }

        /// <summary>
        /// 	integration account information
        /// </summary>
        [DataMember(Name = "account", Order = 10)]
        public IntegrationAccount Account { get; set; }

        /// <summary>
        /// 	when this integration was last synced
        /// </summary>
        [DataMember(Name = "synced_at", Order = 11)]
        public DateTime SyncedAt { get; set; }
    }
}
