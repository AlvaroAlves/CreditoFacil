using Application.Clientes.Requests;
using Application.Clientes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ports
{
    public interface IClienteManager
    {
        Task<ClienteResponse> CreateCliente(CreateClienteRequest clienteRequest);
        Task<ClienteResponse> GetCliente(string cpf);
    }
}
