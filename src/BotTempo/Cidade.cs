using System.Xml.Serialization;

namespace BotTempo {
    [XmlRoot("cidade")]
    public class Cidade {

        [XmlElement("nome")]
        public string nome;
        [XmlElement("uf")]
        public string uf;
        [XmlElement("id")]
        public int id;
    }
}


