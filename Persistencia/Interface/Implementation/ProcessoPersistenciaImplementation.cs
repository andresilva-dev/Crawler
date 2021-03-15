using Microsoft.EntityFrameworkCore;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia.Inteface.Implementation
{
    public class ProcessoPersistenciaImplementation : IProcessoPersistencia
    {
        private SQLiteContext _contexto;

        public ProcessoPersistenciaImplementation(SQLiteContext contexto)
        {
            _contexto = contexto;
        }
        public Processo Atualize(Processo processoAtualizado)
        {
            var processo = _contexto.Processos.SingleOrDefault(p => p.NumeroDoProcesso == processoAtualizado.NumeroDoProcesso);

            if (processo == null)
            {
                return null;
            }
            
            try
            {
                _contexto.Entry(processo).CurrentValues.SetValues(processoAtualizado);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return processoAtualizado;
        }

        public void Exclua(string numeroDoProcesso)
        {
            var processo = _contexto.Processos.SingleOrDefault(p => p.NumeroDoProcesso == numeroDoProcesso);

            if (processo != null)
            {
                try
                {
                    _contexto.Processos.Remove(processo);
                    _contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public Processo Insira(Processo processo)
        {
            try
            {
                _contexto.Add(processo);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
           
            return processo;
        }

        public Processo ObtenhaProcessoPorNumero(string numeroDoProcesso)
        {
            Processo processo;
            try
            {
                processo = _contexto.Processos.Include(p => p.Movimentacoes).FirstOrDefault(p => p.NumeroDoProcesso == numeroDoProcesso);
                _contexto.Entry(processo).Collection(p => p.Movimentacoes).Load();
            }
            catch (Exception)
            {
                throw;
            }

            return processo;
        }

        public List<Processo> ObtenhaTodos()
        {
            var processos = _contexto.Processos.Include(p => p.Movimentacoes).ToList();

            return processos;
        }
    }
}
