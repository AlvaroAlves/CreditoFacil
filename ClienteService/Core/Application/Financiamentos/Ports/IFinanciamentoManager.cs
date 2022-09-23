using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Financiamentos.Ports
{
    public interface IFinanciamentoManager
    {
        Task<FinanciamentoResponse> CreateFinanciamento(CreateFinanciamentoRequest request);
        Task<FinanciamentoResponse> GetFinanciamento(int id);
    }
}
