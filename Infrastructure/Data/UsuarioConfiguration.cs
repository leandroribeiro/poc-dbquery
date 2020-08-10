using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(TarefaContext.USUARIOS_TABLE, TarefaContext.DEFAULT_SCHEMA);

            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseSqlServerIdentityColumn();
            builder.Property(u => u.Nome).IsRequired();
            builder.HasMany(u => u.Tarefas).WithOne(t => t.Usuario).OnDelete(DeleteBehavior.SetNull);
        }
    }
}