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
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.Query<TarefaConcluidaQuery>().ToView("TarefasConcluidas");

            // Seed
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario(1, "Fulano"),
                new Usuario(2, "Beltrano"),
                new Usuario(3, "Ciclano")
            );

            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa(1, "Fazer 1", true),
                new Tarefa(2, "Fazer 2", true),
                new Tarefa(3, "Fazer 3", true),
                new Tarefa(4, "Fazer 4", true),
                new Tarefa(5, "Fazer 5", true),
                new Tarefa(6, "Fazer 6"),
                new Tarefa(7, "Fazer 7"),
                new Tarefa(8, "Fazer 8"),
                new Tarefa(9, "Fazer 9"),
                new Tarefa(10, "Fazer 10"),
                new Tarefa(11, "Fazer 11"),
                new Tarefa(12, "Fazer 12"),
                new Tarefa(13, "Fazer 13"),
                new Tarefa(14, "Fazer 14"),
                new Tarefa(15, "Fazer 15"),
                new Tarefa(16, "Fazer 16"),
                new Tarefa(17, "Fazer 17"),
                new Tarefa(18, "Fazer 18"),
                new Tarefa(19, "Fazer 19"),
                new Tarefa(20, "Fazer 20")
            );
        }
    }

    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", TarefaContext.DEFAULT_SCHEMA);

            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            builder.Property(u => u.Nome).IsRequired();
            builder.HasMany(u => u.Tarefas).WithOne(t => t.Usuario).OnDelete(DeleteBehavior.SetNull);
        }
    }

    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas", TarefaContext.DEFAULT_SCHEMA);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Concluida).HasDefaultValue(0);
            builder.HasOne(u => u.Usuario).WithMany(u => u.Tarefas).OnDelete(DeleteBehavior.SetNull);
        }
    }
}