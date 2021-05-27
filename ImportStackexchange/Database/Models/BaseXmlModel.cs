using System;
using System.Xml.Serialization;

namespace ImportStackexchange.Database.Models
{
    [Serializable]
    [XmlRoot(ElementName = "row", IsNullable = true)]
    public class BaseXmlModel
    {
        [XmlAttribute("Id")]
        public long Id { get; set; }
    }
}
