using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class TarefaContextFactory : IDesignTimeDbContextFactory<TarefaContext>
    {
        public TarefaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TarefaContext>();
            // TODO mover para ler da própria API
            builder.UseSqlServer("Server=efpoc_database;Database=TarefaDb;User Id=sa;Password=Dev123456789;");
            
            return new TarefaContext(builder.Options);
        }
    }
}