using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IFinanciamentoRepository
    {
        Task<Financiamento> Get(int id);
        Task<int> Create(Financiamento financiamento);
        Task<Financiamento> Update(Financiamento financiamento);
    }
}
