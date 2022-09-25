using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IParcelaRepository
    {
        Task<Parcela> Get(int id);
        Task<int> Create(Parcela parcela);
        Task<List<Parcela>> CreateRange(IEnumerable<Parcela> parcelas);
        Task<Parcela> Update(Parcela parcela);
    }
}
