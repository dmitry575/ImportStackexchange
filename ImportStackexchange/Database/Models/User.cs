using System;
using System.Xml.Serialization;

namespace ImportStackexchange.Database.Models
{
    [Serializable]
    [XmlRoot(ElementName = "row", IsNullable = true)]
    public class User
    {
        [XmlAttribute("Id")]
        public long Id { get; set; }

        [XmlAttribute("Reputation")] 
        public int Reputation { get; set; }

        [XmlAttribute("CreationDate")]
        public DateTime CreationDate { get; set; }

        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [XmlElement(ElementName = "LastAccessDate", IsNullable = true)]
        public DateTime? LastAccessDate { get; set; }

        [XmlAttribute("WebsiteUrl")]
        public string WebsiteUrl { get; set; }

        [XmlAttribute("Location")]
        public string Location { get; set; }

        [XmlAttribute("AboutMe")]
        public string AboutMe { get; set; }

        [XmlAttribute("Views")]
        public int Views { get; set; }

        [XmlAttribute("UpVotes")]
        public int UpVotes { get; set; }
        
        [XmlAttribute("DownVotes")]
        public int DownVotes { get; set; }
        
        [XmlAttribute("AccountId")]
        public int AccountId { get; set; }
        
        [XmlAttribute("ProfileImageUrl")]
        public string ProfileImageUrl { get; set; }

    }
}
