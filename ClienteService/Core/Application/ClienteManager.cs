using Application.Clientes.DTO;
using Application.Clientes.Requests;
using Application.Clientes.Responses;
using Application.Ports;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ClienteManager : IClienteManager
    {
        private IClienteRepository _repository;
        public ClienteManager(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<ClienteResponse> CreateCliente(CreateClienteRequest clienteRequest)
        {
            try
            {
                var cliente = ClienteDTO.MapToEntity(clienteRequest.Data);
                clienteRequest.Data.Cpf = await _repository.Create(cliente);
                return new ClienteResponse
                {
                    Data = clienteRequest.Data,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ClienteResponse
                {
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Success = false,
                    Message = "Não foi possível incluir o cliente no banco."
                };
            }
            
        }
    }
}
