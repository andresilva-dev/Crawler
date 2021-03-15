using Negocio;
using Persistencia.Inteface;
using System.Collections.Generic;

namespace Servico.Interface.Implementation
{
    public class ProcessoServicoImplementation : IProcessoServico
    {
        private IProcessoPersistencia _processoPersistencia;
        public ProcessoServicoImplementation(IProcessoPersistencia processoPersistencia)
        {
            _processoPersistencia = processoPersistencia;
        }
        public Processo Atualize(Processo processoAtualizado)
        {
            return _processoPersistencia.Atualize(processoAtualizado);
        }

        public void Exclua(string numeroDoProcesso)
        {
            _processoPersistencia.Exclua(numeroDoProcesso);
        }

        public Processo Insira(Processo processo)
        {
            return _processoPersistencia.Insira(processo);
        }

        public Processo ObtenhaProcessoPorNumero(string numeroDoProcesso)
        {
            var processo = _processoPersistencia.ObtenhaProcessoPorNumero(numeroDoProcesso);

            return processo;
        }

        public List<Processo> ObtenhaTodos()
        {
            var processos = _processoPersistencia.ObtenhaTodos();
            
            return processos;
        }
    }
}
