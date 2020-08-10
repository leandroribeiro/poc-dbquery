using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable(TarefaContext.TAREFAS_TABLE, TarefaContext.DEFAULT_SCHEMA);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Concluida).HasDefaultValue(0);
            builder.HasOne(u => u.Usuario).WithMany(u => u.Tarefas).OnDelete(DeleteBehavior.SetNull);
        }
    }
}