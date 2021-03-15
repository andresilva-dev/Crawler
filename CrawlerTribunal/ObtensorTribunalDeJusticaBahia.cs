using HtmlAgilityPack;
using Negocio;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CrawlerTribunal
{
    public static class ObtensorTribunalDeJusticaBahia
    {
        public static Processo ObtenhaInformacoesDoProcesso()
        {
            var url = @"http://esaj.tjba.jus.br/cpo/sg/search.do;jsessionid=51F6CF2B414333AB2B6AF450D7980B05.cposg4?paginaConsulta=1&cbPesquisa=NUMPROC&tipoNuProcesso=UNIFICADO&numeroDigitoAnoUnificado=0809979-67.2015&foroNumeroUnificado=0080&dePesquisaNuUnificado=0809979-67.2015.8.05.0080&dePesquisa=";

            string markup;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = CodePagesEncodingProvider.Instance.GetEncoding(1252);
                markup = wc.DownloadString(url);
            }

            var html = new HtmlAgilityPack.HtmlDocument();
            
            html.LoadHtml(markup);
            
            var processo = ObtenhaProcesso(html);

            return processo;
        }

        private static Processo ObtenhaProcesso(HtmlAgilityPack.HtmlDocument html)
        {
            var secao = html.DocumentNode.SelectNodes("//table[@class='secaoFormBody']").Last();

            var listaDeElementos = secao.SelectNodes(".//tr");
            var processo = new Processo();
            foreach (var elemento in listaDeElementos)
            {
                var div = elemento.SelectSingleNode(".//div[@class='labelClass']");

                if (div == null)
                    continue;

                if (div.InnerText.StartsWith("Processo:"))
                {
                    processo.NumeroDoProcesso = ObtenhaValorDoElemento(elemento);
                }
                if (div.InnerText.StartsWith("Classe:"))
                {
                    processo.Classe = ObtenhaValorDoElemento(elemento);
                    var elemtentoArea = elemento.SelectSingleNode("//td[contains(span, 'Área:')]");

                    processo.Area = elemtentoArea.InnerText.Replace("Área:", "").Trim();
                }
                if (div.InnerText.StartsWith("Assunto:"))
                {
                    processo.Assunto = ObtenhaValorDoElemento(elemento);
                }
                if (div.InnerText.StartsWith("Origem:"))
                {
                    processo.Origem = ObtenhaValorDoElemento(elemento);
                }
                if (div.InnerText.StartsWith("Números de origem:"))
                {
                    processo.NumeroDeOrigem = ObtenhaValorDoElemento(elemento);
                }
                if (div.InnerText.StartsWith("Distribuição:"))
                {
                    processo.Distribuicao = ObtenhaValorDoElemento(elemento);
                }
                if (div.InnerText.StartsWith("Relator:"))
                {
                    processo.Relator = ObtenhaValorDoElemento(elemento);
                }
            }

            processo.Movimentacoes = ObtenhaMovimentacoesDoProcesso(html);
            return processo;
        }

        private static List<Movimentacao> ObtenhaMovimentacoesDoProcesso(HtmlAgilityPack.HtmlDocument html)
        {
            var secao = html.DocumentNode.SelectSingleNode("//table[@id='tabelaUltimasMovimentacoes']");

            var listaDeElementos = secao.SelectNodes(".//tr");

            var movimentacoes = new List<Movimentacao>();
            foreach (var elemento in listaDeElementos)
            {
                var itens = elemento.SelectNodes(".//td");

                movimentacoes.Add(new Movimentacao()
                {
                    Data = itens.First().InnerText.Trim(),
                    Conteudo = ObtenhaConteudoDecodificado(itens.Last().InnerText.Replace("\n", "").Replace("\t", "").Replace("\r", "").Trim())
                });
            }
            
            return movimentacoes;
        }

        private static string ObtenhaConteudoDecodificado(string conteudoCodificado)
        {
            var conteudoDecodificado = new StringWriter();
            HttpUtility.HtmlDecode(conteudoCodificado, conteudoDecodificado);

            return conteudoDecodificado.ToString();
        }
        private static string ObtenhaValorDoElemento(HtmlNode elemento)
        {
            return elemento.SelectNodes(".//span").First().InnerText.Trim();
        }
    }
}
