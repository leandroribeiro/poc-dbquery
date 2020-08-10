using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TarefaContext : DbContext
    {
        public static string DEFAULT_SCHEMA = "dbo";
        public const string USUARIOS_TABLE = "Usuarios";
        public const string TAREFAS_TABLE = "Tarefas";
        private const string TAREFAS_CONCLUIDAS_VIEW = "TarefasConcluidas";

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbQuery<TarefaConcluidaQuery> TarefasConcluidas { get; set; }

        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.Query<TarefaConcluidaQuery>().ToView(TAREFAS_CONCLUIDAS_VIEW);
        }
    }
}