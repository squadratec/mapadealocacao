using System.Xml.Serialization;

namespace SQH.Entities.Sharepoint
{
    public class Content
    {
        [XmlElement(ElementName = "properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public Properties properties { get; set; }
    }
}
