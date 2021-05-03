using System;
using System.Xml.Serialization;

namespace BotTempo {

    [XmlRoot("previsao")]

    public class Previsao {

        [XmlElement("dia")]
        public DateTime dia;
        [XmlElement("tempo")]
        public string tempo;
        [XmlElement("maxima")]
        public int maxima;
        [XmlElement("minima")]
        public int minima;
        [XmlElement("iuv")]
        public double iuv;
    }
}
