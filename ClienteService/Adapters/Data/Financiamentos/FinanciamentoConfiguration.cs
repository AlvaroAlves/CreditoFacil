using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Financiamentos
{
    public class FinanciamentoConfiguration : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
            builder.HasMany(c => c.Parcelas).WithOne(c => c.Financiamento).HasForeignKey("IdFinanciamento");
        }
    }
}
