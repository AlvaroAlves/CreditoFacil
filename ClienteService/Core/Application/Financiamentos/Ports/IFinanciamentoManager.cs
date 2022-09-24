using Application.Financiamentos.Requests;
using Application.Financiamentos.Responses;

namespace Application.Financiamentos.Ports
{
    public interface IFinanciamentoManager
    {
        Task<FinanciamentoResponse> CreateFinanciamento(CreateFinanciamentoRequest request);
        Task<FinanciamentoResponse> GetFinanciamento(int id);
    }
}
