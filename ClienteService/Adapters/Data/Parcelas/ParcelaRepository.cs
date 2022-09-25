using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parcelas
{
    public class ParcelaRepository : IParcelaRepository
    {
        private Context _context;

        public ParcelaRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> Create(Parcela parcela)
        {
            _context.Parcelas.Add(parcela);
            await _context.SaveChangesAsync();
            return parcela.Id;
        }

        public async Task<List<Parcela>> CreateRange(IEnumerable<Parcela> parcelas)
        {
            _context.Parcelas.AddRange(parcelas);
            await _context.SaveChangesAsync();
            return parcelas.ToList();
        }

        public async Task<Parcela> Update(Parcela parcela)
        {
            _context.Parcelas.Update(parcela);
            await _context.SaveChangesAsync();
            return parcela;
        }

        public async Task<Parcela?> Get(int id)
        {
            return await _context.Parcelas.Where(c => c.Id == id).Include(x => x.Financiamento).FirstOrDefaultAsync();
        }
    }
}
