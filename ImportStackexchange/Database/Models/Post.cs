

using System;
using System.Xml.Serialization;

namespace ImportStackexchange.Database.Models
{
    [Serializable]
    [XmlRoot(ElementName = "row", IsNullable = true)]
    public class Post: BaseXmlModel
    {
        [XmlAttribute("PostTypeId")]
        public int PostTypeId { get; set; }

        [XmlAttribute("AcceptedAnswerId")]
        public long AcceptedAnswerId { get; set; }

        [XmlAttribute("CreationDate")]
        public DateTime CreationDate { get; set; }

        [XmlAttribute("Score")]
        public long Score { get; set; }

        [XmlElement(ElementName = "ViewCount", IsNullable = true)]
        public long? ViewCount { get; set; }

        [XmlAttribute("Body")]
        public string Body { get; set; }

        [XmlAttribute("OwnerUserId")] 
        public long OwnerUserId { get; set; }

        [XmlAttribute("LastEditorUserId")]
        public long LastEditorUserId { get; set; }

        [XmlElement(ElementName = "LastEditDate", IsNullable = true)]
        public DateTime? LastEditDate { get; set; }

        [XmlAttribute("LastActivityDate")]
        public DateTime LastActivityDate { get; set; }

        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("Tags")]
        public string Tags { get; set; }

        [XmlAttribute("AnswerCount")]
        public int AnswerCount { get; set; }

        [XmlAttribute("CommentCount")]
        public int CommentCount { get; set; }

        [XmlAttribute("FavoriteCount")]
        public int FavoriteCount { get; set; }

        [XmlAttribute("ContentLicense")]
        public string ContentLicense { get; set; }

        [XmlElement(ElementName = "ParentId", IsNullable = true)]
        public int? ParentId { get; set; }

        [XmlElement(ElementName = "CommunityOwnedDate", IsNullable = true)]
        public DateTime? CommunityOwnedDate { get; set; }

        [XmlElement(ElementName = "ClosedDate", IsNullable = true)]
        public DateTime? ClosedDate { get; set; }
        
    }
}
