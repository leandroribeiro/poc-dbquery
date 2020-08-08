using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class TarefaContextFactory : IDesignTimeDbContextFactory<TarefaContext>
    {
        public TarefaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TarefaContext>();
            builder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=TarefaDb;User Id=sa;Password=Dev123456789;");
            
            return new TarefaContext(builder.Options);
        }
    }
}