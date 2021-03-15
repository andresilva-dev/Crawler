
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Persistencia
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext() { }

        public SQLiteContext(DbContextOptions<SQLiteContext> opcoesDeContexto) : base(opcoesDeContexto)
        {
        }

        public DbSet<Processo> Processos { get; set; }
    }
}
