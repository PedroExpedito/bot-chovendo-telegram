using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BotTempo {
    [XmlRoot("cidade")]
    public class CidadePrevisao : Cidade {

        [XmlElement("atualizacao")]
        public DateTime atualizacao;
        [XmlElement("previsao")]
        public Previsao[] previsao;

        // Essa função é um problema por que duas classes tem função parecidas
        // e seria interessante fazer algo generico

        private static CidadePrevisao Deserializer( string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CidadePrevisao));

            using (TextReader reader = new StringReader(xml)) {
                return  (CidadePrevisao)serializer.Deserialize(reader);
            }
        }

        public static async Task<CidadePrevisao> GetPrevisaoAsync(string id) {
            string xml = await Api.GetXmlAsync("cidade/"+id+"/previsao.xml");
            return Deserializer(xml);
        }

        public static string FormatandoPrevisao(CidadePrevisao previsao) {
            string result = "Cidade: "+previsao.nome+"\n"+
                "Estado:" + previsao.uf + "\n";

            CultureInfo idioma = new CultureInfo("pt-BR");

            for(int i = 0; i < previsao.previsao.Length; i++) {
                result +=
                    "A previsão para " + previsao.previsao[i].dia.
                    ToString("dddd, dd MMMM yyyy",idioma)
                    + "\ncom tempo " + TempoDicionario.FindDictionary(
                            previsao.previsao[i].tempo) +
                    " e temperadura entre "+ previsao.previsao[i].minima +
                    "ºC a " + previsao.previsao[i].maxima +"ºC.\n\n";
            }
            return result;

        }

    }
}
