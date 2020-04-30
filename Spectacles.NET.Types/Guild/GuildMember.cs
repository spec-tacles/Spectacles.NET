using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Represents a member of a guild on Discord.
    /// </summary>
    [DataContract]
    public class GuildMember
    {
        /// <summary>
        ///     the user this guild member represents
        /// </summary>
        [DataMember(Name = "user", Order = 1)]
        public User User { get; set; }

        /// <summary>
        ///     this users guild nickname (if one is set)
        /// </summary>
        [DataMember(Name = "nick", Order = 2)]
        public string Nickname { get; set; }

        /// <summary>
        ///     array of role object ids
        /// </summary>
        [DataMember(Name = "roles", Order = 3)]
        public List<string> Roles { get; set; }

        /// <summary>
        ///     when the user joined the guild
        /// </summary>
        [DataMember(Name = "joined_at", Order = 4)]
        public string JoinedAt { get; set; }

        /// <summary>
        /// The time of when the member used their Nitro boost on the guild, if it was used
        /// </summary>
        [DataMember(Name = "premium_since", Order = 5)]
        public string PremiumSince { get; set; }

        /// <summary>
        ///     whether the user is deafened
        /// </summary>
        [DataMember(Name = "deaf", Order = 6)]
        public bool Deaf { get; set; }

        /// <summary>
        ///     whether the user is muted
        /// </summary>
        [DataMember(Name = "mute", Order = 7)]
        public bool Mute { get; set; }
    }
}