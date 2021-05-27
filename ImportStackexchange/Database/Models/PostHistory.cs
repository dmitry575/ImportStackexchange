using System;
using System.Xml.Serialization;

namespace ImportStackexchange.Database.Models
{
    [Serializable]
    [XmlRoot(ElementName = "row", IsNullable = true)]
    public class PostHistory
    {
        [XmlAttribute("Id")]
        public long Id { get; set; }

        [XmlAttribute("PostId")]
        public long PostId{ get; set; }

        [XmlAttribute("UserId")]
        public long UserId { get; set; }

        [XmlAttribute("PostHistoryTypeId")]
        public int PostHistoryTypeId { get; set; }

        [XmlAttribute("RevisionGUID")]
        public Guid RevisionGUID { get; set; }

        [XmlAttribute("CreationDate")]
        public DateTime CreationDate { get; set; }

        [XmlAttribute("Text")]
        public string Text{ get; set; }

        [XmlAttribute("Comment")]
        public string Comment { get; set; }

        [XmlAttribute("ContentLicense")]
        public string ContentLicense { get; set; }
    }
}
