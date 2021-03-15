using Newtonsoft.Json;
using System;
using System.Net;

namespace CrawlerTribunal
{
    public class ApiProcessoHelper : IDisposable
    {
        private string _uri => "https://localhost:44369/api/processo";
        private WebClient _webClient;
        private WebClient WebClient
        {
            get
            {
                if (_webClient == null)
                {
                    _webClient = new WebClient();
                    _webClient.Headers.Add("Content-Type:application/json");
                    _webClient.Headers.Add("Accept:application/json");
                }
                return _webClient;
            }
        }

        public T ExecutePostAsync<T>(object conteudo)
        {
            var resultado = WebClient.UploadString(_uri, JsonConvert.SerializeObject(conteudo));
            return JsonConvert.DeserializeObject<T>(resultado);
        }

        public void ExecuteDeleteAsync(object conteudo)
        {
            WebClient.UploadString(_uri+"/"+ conteudo.ToString(), "DELETE", "");
        }

        public T ExecuteGetAsync<T>(object conteudo)
        {
            var resultado = WebClient.DownloadString($"{_uri}/{conteudo}");
            return JsonConvert.DeserializeObject<T>(resultado);
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }
    }
}

