using Data.Financiamentos;
using Entities = Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Data.Clientes;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){ }

        public virtual DbSet<Entities.Cliente> Clientes { get; set; }
        public virtual DbSet<Entities.Financiamento> Financiamentos { get; set; }
        public virtual DbSet<Entities.Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ClienteConfiguration())
                .ApplyConfiguration(new FinanciamentoConfiguration());
        }
    }
}