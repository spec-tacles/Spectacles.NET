using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Video of an Embed
    /// </summary>
    [DataContract]
    public class EmbedVideo
    {
        /// <summary>
        ///     source url of video
        /// </summary>
        [DataMember(Name = "url", Order = 1)]
        public string URL { get; set; }

        /// <summary>
        ///     height of video
        /// </summary>
        [DataMember(Name = "height", Order = 2)]
        public int? Height { get; set; }

        /// <summary>
        ///     width of video
        /// </summary>
        [DataMember(Name = "width", Order = 3)]
        public int? Width { get; set; }
    }
}
