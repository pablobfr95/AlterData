using core.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace core.Repository.EntityConfig
{
    public class ClienteConfig
    {
        public ClienteConfig(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Identificador);

            builder.Property(c => c.Identificador).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(c => c.DataNascimento).IsRequired();

            builder.Property(c => c.Endereco).IsRequired();
            
            builder.Property(c => c.Nome).IsRequired();

            builder.Property(c => c.Status).IsRequired().HasMaxLength(1);
        }
    }
}