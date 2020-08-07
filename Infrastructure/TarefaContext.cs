using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    public class TarefaContext : DbContext
    {
        public static string DEFAULT_SCHEMA = "dbo";
        
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbQuery<TarefaConcluidaQuery> TarefasConcluidas { get; set; }
        
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            modelBuilder.Query<TarefaConcluidaQuery>().ToView("TarefasConcluidas");

        }
    }

    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> buyerConfiguration)
        {
            buyerConfiguration.ToTable("Tarefa", TarefaContext.DEFAULT_SCHEMA);

            buyerConfiguration.HasKey(b => b.Codigo);

            buyerConfiguration.Property(b => b.Nome);
        }
    }
}