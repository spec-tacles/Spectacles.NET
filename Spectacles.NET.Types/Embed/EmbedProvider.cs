using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Provider of an Embed
    /// </summary>
    [DataContract]
    public class EmbedProvider
    {
        /// <summary>
        ///     name of provider
        /// </summary>
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     url of provider
        /// </summary>
        [DataMember(Name = "url", Order = 2)]
        public string URL { get; set; }
    }
}