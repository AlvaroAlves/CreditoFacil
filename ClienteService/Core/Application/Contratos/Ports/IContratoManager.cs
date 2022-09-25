using Application.Contratos.Requests;
using Application.Contratos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contratos.Ports
{
    public interface IContratoManager
    {
        Task<ContratoResponse> CreateContrato(string cpf, CreateContratoRequest request);
    }
}
