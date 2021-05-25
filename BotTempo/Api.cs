using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotTempo {
    public class Api {
        public static async Task<string> GetXmlAsync(string url)
        {
            HttpClient client = new HttpClient();
            string BaseUrl = "http://servicos.cptec.inpe.br/XML/";

            Console.WriteLine("URL:"+BaseUrl+url);

            try
            {
                HttpResponseMessage response = await client.GetAsync(BaseUrl + url);
                response.EnsureSuccessStatusCode();
                if(response.StatusCode == HttpStatusCode.OK) {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;

                }
            }
            catch
            {
                throw;
            }
            return null;
        }
    }
}
