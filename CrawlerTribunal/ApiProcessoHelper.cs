using Newtonsoft.Json;
using System;
using System.Net;

namespace CrawlerTribunal
{
    public class ApiProcessoHelper
    {
        private string _uri => "https://localhost:44369/api/processo";
        public T ExecutePostAsync<T>(object conteudo)
        {
            var resultado = string.Empty;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Content-Type:application/json");
                wc.Headers.Add("Accept:application/json");
                resultado = wc.UploadString(_uri, JsonConvert.SerializeObject(conteudo));
            }
                
            return JsonConvert.DeserializeObject<T>(resultado);
        }

        public void ExecuteDeleteAsync(object conteudo)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Content-Type:application/json");
                wc.Headers.Add("Accept:application/json");
                wc.UploadString(_uri + "/" + conteudo.ToString(), "DELETE", "");
            }
        }

        public T ExecuteGetAsync<T>(object conteudo)
        {
            var resultado = string.Empty;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Content-Type:application/json");
                wc.Headers.Add("Accept:application/json");
                resultado = wc.DownloadString($"{_uri}/{conteudo}");
            }

            return JsonConvert.DeserializeObject<T>(resultado);
        }
    }
}

