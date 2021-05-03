using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BotTempo
{
    [XmlRoot("cidades")]
    public class GetCidadeId
    {
        [XmlElement("cidade")]
        public Cidade[] cidade;

        private static T Deserializer<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(xml))
            {
                return  (T)serializer.Deserialize(reader);
            }

        }



        public static async Task<GetCidadeId> GetCityAsync(string cidade)
        {
            try {
                string responseBody = await Api.GetXmlAsync("listaCidades?city=" + cidade);
                return Deserializer<GetCidadeId>(responseBody);
            }
            catch(Exception ex) {
                Console.WriteLine("error:" + ex.Message);
            }
            Console.WriteLine("CHEGO");
            return null;
        }
    }
}
