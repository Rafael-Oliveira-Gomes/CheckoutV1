using Checkout.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definindo a chave estrangeira explicitamente para evitar ambiguidade
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
