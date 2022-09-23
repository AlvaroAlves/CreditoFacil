using Data.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){ }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Financiamento> Financiamentos { get; set; }
        public virtual DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ClienteConfiguration())
                .ApplyConfiguration(new FinanciamentoConfiguration());
        }
    }
}