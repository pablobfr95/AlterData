using core.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace core.Repository.EntityConfig
{
    public class ContatoConfig
    {
        public ContatoConfig(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Identificador);

            builder.Property(c => c.Identificador).ValueGeneratedOnAdd().UseIdentityColumn();
            
            builder.Property(c => c.Tipo).IsRequired();

            builder.Property(c => c.Descricao).IsRequired();

            builder.HasOne(e => e.Cliente).WithMany(c => c.Contatos).HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}