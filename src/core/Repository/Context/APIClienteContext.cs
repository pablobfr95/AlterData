using System;
using core.Modelo;
using core.Modelo.Auth;
using core.Repository.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace core.Repository.Context
{
    public class APIClienteContext : IdentityDbContext<Usuario, Role, Guid>
    {
        public APIClienteContext(DbContextOptions<APIClienteContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        
        public DbSet<Contato> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Your custom configs here
            new ClienteConfig(builder.Entity<Cliente>());
            new ContatoConfig(builder.Entity<Contato>());
            
        }

    }
}