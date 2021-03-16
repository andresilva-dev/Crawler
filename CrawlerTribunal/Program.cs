using Negocio;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace CrawlerTribunal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Obtém informações do processo: 0809979-67.2015.8.05.0080 através do crawler");
            var processo = ObtensorTribunalDeJusticaBahia.ObtenhaInformacoesDoProcesso("0809979-67.2015.8.05.0080");

            Console.WriteLine("Aguarda alguns segundos para que a Api seja iniciada");
            Thread.Sleep(5000);

            var apiHelper = new ApiProcessoHelper();
            Console.WriteLine("Insere processo 0809979-67.2015.8.05.0080 e suas movimentações no banco de dados através da API");
            apiHelper.ExecutePostAsync<Processo>(processo);

            var processoNovo = new Processo()
            {
                Assunto = "Teste Assunto",
                Area = "Teste Area",
                Classe = "Teste Classe",
                Distribuicao = "Teste Distribuição",
                NumeroDeOrigem = "5555555-22.2015.4.94.5555",
                NumeroDoProcesso = "5555555-22.2015.4.94.5555",
                Origem = "Teste Origem",
                Relator = "Teste Relator",
                Movimentacoes = new List<Movimentacao>() { new Movimentacao() { Data = "10/02/2021", Conteudo = "Teste"} }
            };

            Console.WriteLine("Insere processo mock número 5555555-22.2015.4.94.5555 e suas movimentações no banco de dados através da API");
            apiHelper.ExecutePostAsync<Processo>(processoNovo);

            Console.WriteLine("Consulta o processo 0809979-67.2015.8.05.0080 e suas movimentações no banco de dados através da API");
            var processoObtido = apiHelper.ExecuteGetAsync<Processo>("0809979-67.2015.8.05.0080");

            Console.WriteLine("Consulta os processos e suas movimentações no banco de dados através da API");
            var processos = apiHelper.ExecuteGetAsync<List<Processo>>("");

            Console.WriteLine("Deleta o processo 0809979-67.2015.8.05.0080 e suas movimentações no banco de dados através da API");
            apiHelper.ExecuteDeleteAsync("0809979-67.2015.8.05.0080");

            Console.WriteLine("Deleta o processo mock número 5555555-22.2015.4.94.5555 e suas movimentações no banco de dados através da API");
            apiHelper.ExecuteDeleteAsync("5555555-22.2015.4.94.5555");

            Console.ReadKey();
        }
    }
}
