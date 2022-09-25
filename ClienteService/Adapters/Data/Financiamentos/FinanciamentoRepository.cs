using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Financiamentos
{
    public class FinanciamentoRepository : IFinanciamentoRepository
    {
        private Context _context;

        public FinanciamentoRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> Create(Financiamento financiamento)
        {
            _context.Financiamentos.Add(financiamento);
            await _context.SaveChangesAsync();
            return financiamento.Id;
        }

        public async Task<Financiamento> Update(Financiamento financiamento)
        {
            _context.Financiamentos.Update(financiamento);
            await _context.SaveChangesAsync();
            return financiamento;
        }

        public async Task<Financiamento?> Get(int id)
        {
            return await _context.Financiamentos.Where(c => c.Id == id)
                .Include(x => x.Cliente)
                .Include(y => y.Parcelas)
                .FirstOrDefaultAsync();
        }
    }
}
