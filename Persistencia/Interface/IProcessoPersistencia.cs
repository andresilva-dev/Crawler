using Negocio;
using System.Collections.Generic;

namespace Persistencia.Inteface
{
    public interface IProcessoPersistencia    {
        Processo Insira(Processo processo);

        Processo Atualize(Processo processo);

        Processo ObtenhaProcessoPorNumero(string numeroDoProcesso);

        void Exclua(string numeroDoProcesso);

        List<Processo> ObtenhaTodos();
    }
}
