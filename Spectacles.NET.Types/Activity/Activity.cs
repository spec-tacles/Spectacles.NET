// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Represents an activity which is part of a user's presence.
    /// </summary>
    [DataContract]
    public class Activity
    {
        /// <summary>
        ///     the activity's name
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     <see cref="ActivityType" />
        /// </summary>
        [DataMember(Name = "type", Order = 2)]
        public ActivityType Type { get; set; }

        /// <summary>
        ///     stream url, is validated when type is 1
        /// </summary>
        [DataMember(Name = "url", Order = 3)]
        public string URL { get; set; }

        /// <summary>
        ///     unix timestamps for start and/or end of the game
        /// </summary>
        [DataMember(Name = "timestamps", Order = 4)]
        public ActivityTimestamps Timestamps { get; set; }

        /// <summary>
        ///     application id for the game
        /// </summary>
        [DataMember(Name = "application_id", Order = 5)]
        public string ApplicationId { get; set; }

        /// <summary>
        ///     what the player is currently doing
        /// </summary>
        [DataMember(Name = "details", Order = 6)]
        public string Details { get; set; }

        /// <summary>
        ///     the user's current party status
        /// </summary>
        [DataMember(Name = "state", Order = 7)]
        public string State { get; set; }

        /// <summary>
        /// 	the emoji used for a custom status
        /// </summary>
        [DataMember(Name = "emoji", Order = 8)]
        public Emoji Emoji { get; set; }

        /// <summary>
        ///     information for the current party of the player
        /// </summary>
        [DataMember(Name = "party", Order = 9)]
        public ActivityParty Party { get; set; }

        /// <summary>
        ///     images for the presence and their hover texts
        /// </summary>
        [DataMember(Name = "assets", Order = 10)]
        public ActivityAssets Assets { get; set; }

        /// <summary>
        ///     secrets for Rich Presence joining and spectating
        /// </summary>
        [DataMember(Name = "secrets", Order = 11)]
        public ActivitySecrets Secrets { get; set; }

        /// <summary>
        ///     whether or not the activity is an instanced game session
        /// </summary>
        [DataMember(Name = "instance", Order = 12)]
        public bool? Instance { get; set; }

        /// <summary>
        ///     activity flags ORd together, describes what the payload includes
        /// </summary>
        [DataMember(Name = "flags", Order = 13)]
        public ActivityFlags Flags { get; set; }
    }
}