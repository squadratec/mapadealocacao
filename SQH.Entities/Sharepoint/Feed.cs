using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SQH.Entities.Sharepoint
{
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        public Guid id { get; set; }
        public DateTime updated { get; set; }
        public string title { get; set; }

        [XmlElement(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
        public List<Entry> entry { get; set; }
    }
}
