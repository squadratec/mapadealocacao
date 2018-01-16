using System;
using System.Xml.Serialization;

namespace SQH.Entities.Sharepoint
{
    public class Properties
    {
        [XmlElement(ElementName = "ID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public int ID { get; set; }

        [XmlElement(ElementName = "Id", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public int idUsuario { get; set; }

        [XmlElement(ElementName = "GUID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public Guid GUID { get; set; }

        [XmlElement(ElementName = "ContentTypeId", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string ContentTypeId { get; set; }

        [XmlElement(ElementName = "Title", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Ger_x00ea_ncia", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string Ger_x00ea_ncia { get; set; }

        [XmlElement(ElementName = "Classifica_x00e7__x00e3_o", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string Classifica_x00e7__x00e3_o { get; set; }

        [XmlElement(ElementName = "Fim", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public DateTime Fim { get; set; }

        [XmlElement(ElementName = "Fase", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string Fase { get; set; }

        [XmlElement(ElementName = "LoginName", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string LoginName { get; set; }

        [XmlElement(ElementName = "Email", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string Email { get; set; }

        [XmlElement(ElementName = "LiderId", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string LiderId { get; set; }
    }
}
