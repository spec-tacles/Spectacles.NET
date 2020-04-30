using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spectacles.NET.Types
{
    /// <summary>
    /// Represents an embed in a message (image/video preview, rich embed, etc.)
    /// </summary>
    [DataContract]
    public class Embed
    {
        /// <summary>
        ///     title of embed
        /// </summary>
        [DataMember(Name = "title", Order = 1)]
        public string Title { get; set; }

        /// <summary>
        ///     type of embed (always "rich" for webhook embeds)
        /// </summary>
        [DataMember(Name = "type", Order = 2)]
        public string Type { get; set; }

        /// <summary>
        ///     description of embed
        /// </summary>
        [DataMember(Name = "description", Order = 3)]
        public string Description { get; set; }

        /// <summary>
        ///     url of embed
        /// </summary>
        [DataMember(Name = "url", Order = 4)]
        public string URL { get; set; }

        /// <summary>
        ///     timestamp of embed content
        /// </summary>
        [DataMember(Name = "timestamp", Order = 5)]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        ///     color code of the embed
        /// </summary>
        [DataMember(Name = "color", Order = 6)]
        public int? Color { get; set; }

        /// <summary>
        ///     footer information
        /// </summary>
        [DataMember(Name = "footer", Order = 7)]
        public EmbedFooter Footer { get; set; }

        /// <summary>
        ///     image information
        /// </summary>
        [DataMember(Name = "image", Order = 8)]
        public EmbedImage Image { get; set; }

        /// <summary>
        ///     thumbnail information
        /// </summary>
        [DataMember(Name = "thumbnail", Order = 9)]
        public EmbedThumbnail Thumbnail { get; set; }

        /// <summary>
        ///     video information
        /// </summary>
        [DataMember(Name = "video", Order = 10)]
        public EmbedVideo Video { get; set; }

        /// <summary>
        ///     provider information
        /// </summary>
        [DataMember(Name = "provider", Order = 11)]
        public EmbedProvider Provider { get; set; }

        /// <summary>
        ///     author information
        /// </summary>
        [DataMember(Name = "author", Order = 12)]
        public EmbedAuthor Author { get; set; }

        /// <summary>
        ///     fields information
        /// </summary>
        [DataMember(Name = "fields", Order = 13)]
        public List<EmbedField> Fields { get; set; }
    }
}