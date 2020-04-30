using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    ///     Active sessions are indicated with an "online", "idle", or "dnd" string per platform. If a user is offline or
    ///     invisible, the corresponding field is not present.
    /// </summary>
    [DataContract]
    public class ClientStatus
    {
        /// <summary>
        ///     the user's status set for an active desktop (Windows, Linux, Mac) application session
        /// </summary>
        [DataMember(Name = "desktop", Order = 1)]
        public Status? Desktop { get; set; }

        /// <summary>
        ///     the user's status set for an active mobile (iOS, Android) application session
        /// </summary>
        [DataMember(Name = "mobile", Order = 2)]
        public Status? Mobile { get; set; }

        /// <summary>
        ///     the user's status set for an active web (browser, bot account) application session
        /// </summary>
        [DataMember(Name = "web", Order = 3)]
        public Status? Web { get; set; }
    }
}
