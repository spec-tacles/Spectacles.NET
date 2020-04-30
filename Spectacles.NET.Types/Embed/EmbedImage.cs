using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Image of an Embed
    /// </summary>
    [DataContract]
    public class EmbedImage
    {
        /// <summary>
        ///     source url of image (only supports http(s) and attachments)
        /// </summary>
        [DataMember(Name = "url", Order = 1)]
        public string URL { get; set; }

        /// <summary>
        ///     a proxied url of the image
        /// </summary>
        [DataMember(Name = "proxy_url", Order = 2)]
        public string ProxyURL { get; set; }

        /// <summary>
        ///     height of image
        /// </summary>
        [DataMember(Name = "height", Order = 3)]
        public int? Height { get; set; }

        /// <summary>
        ///     width of image
        /// </summary>
        [DataMember(Name = "width", Order = 4)]
        public int? Width { get; set; }
    }
}
