using System.Runtime.Serialization;

namespace Spectacles.NET.Types.Voice
{
    /// <summary>
    /// A voice region of a discord guild
    /// </summary>
    [DataContract]
    public class VoiceRegion
    {
        /// <summary>
        /// 	unique ID for the region
        /// </summary>
        [DataMember(Name = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// 	name of the region
        /// </summary>
        [DataMember(Name = "name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// 	true if this is a vip-only server
        /// </summary>
        [DataMember(Name = "vip", Order = 3)]
        public bool Vip { get; set; }

        /// <summary>
        /// 	whether this is a custom voice region (used for events/etc)
        /// </summary>
        [DataMember(Name = "custom", Order = 4)]
        public bool Custom { get; set; }

        /// <summary>
        ///		whether this is a deprecated voice region (avoid switching to these)
        /// </summary>
        [DataMember(Name = "deprecated", Order = 5)]
        public bool Deprecated { get; set; }

        /// <summary>
        /// 	true for a single server that is closest to the current user's client
        /// </summary>
        [DataMember(Name = "optimal", Order = 6)]
        public bool Optimal { get; set; }
    }
}