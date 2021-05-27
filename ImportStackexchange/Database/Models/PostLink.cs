using System;
using System.Xml.Serialization;

namespace ImportStackexchange.Database.Models
{
    [Serializable]
    [XmlRoot(ElementName = "row", IsNullable = true)]
    public class PostLink
    {
        [XmlAttribute("Id")]
        public long Id { get; set; }

        [XmlAttribute("CreationDate")]
        public DateTime CreationDate { get; set; }

        [XmlAttribute("PostId")]
        public long PostId { get; set; }

        [XmlAttribute("RelatedPostId")]
        public long RelatedPostId { get; set; }

        [XmlAttribute("LinkTypeId")]
        public int LinkTypeId { get; set; }
    }
}
