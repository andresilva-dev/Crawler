using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Negocio
{
    public static class UtilidadeDeFormatacao
    {
        public static string ObtenhaSomenteParteNumerica(string valor)
        {
            var regex = new Regex("[^0-9]");
            return regex.Replace(valor ?? string.Empty, string.Empty);
        }

        public static string ObtenhaTextoSemEspacos(string valor)
        {
            return Regex.Replace(valor, @"\r\n?|\n|\t", String.Empty).Trim();
        }

        public static string ObtenhaConteudoDecodificado(string conteudoCodificado)
        {
            var conteudoDecodificado = new StringWriter();
            HttpUtility.HtmlDecode(conteudoCodificado, conteudoDecodificado);

            return conteudoDecodificado.ToString();
        }
    }
}
