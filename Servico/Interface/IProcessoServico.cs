using Negocio;
using System.Collections.Generic;

namespace Servico.Interface
{
    public interface IProcessoServico
    {
        Processo Insira(Processo processo);

        Processo Atualize(Processo processo);

        Processo ObtenhaProcessoPorNumero(string numeroDoProcesso);

        void Exclua(string numeroDoProcesso);

        List<Processo> ObtenhaTodos();
    }
}
