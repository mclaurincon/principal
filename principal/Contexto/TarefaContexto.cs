using Microsoft.EntityFrameworkCore;
using principal.Modelo;

namespace principal.Contexto
   
{
    public class TarefaContexto : DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto> options)
            :base(options)
        {

        }
        public DbSet<TarefaItem> Tarefas { get; set; } = null;
    }
}
