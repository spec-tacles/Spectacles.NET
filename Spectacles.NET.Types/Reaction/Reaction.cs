using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Represents a reaction to a message.
    /// </summary>
    [DataContract]
    public class Reaction
    {
        /// <summary>
        ///     times this emoji has been used to react
        /// </summary>
        [DataMember(Name = "count", Order = 1)]
        public int Count { get; set; }

        /// <summary>
        ///     whether the current user reacted using this emoji
        /// </summary>
        [DataMember(Name = "me", Order = 2)]
        public bool Me { get; set; }

        /// <summary>
        ///     emoji information
        /// </summary>
        [DataMember(Name = "emoji", Order = 3)]
        public Emoji Emoji { get; set; }
    }
}