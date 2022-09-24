using Application.Parcelas.Requests;
using Application.Parcelas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parcelas.Ports
{
    public interface IParcelaManager
    {
        Task<ParcelaResponse> CreateParcela(CreateParcelaRequest request);
        Task<ParcelaResponse> GetParcela(int id);
    }
}
