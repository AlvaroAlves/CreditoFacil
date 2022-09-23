using Application.Clientes.DTO;
using Application.Clientes.Requests;
using Application.Clientes.Responses;
using Application.Ports;
using Domain.Exceptions;
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
                await cliente.Save(_repository);
                return new ClienteResponse
                {
                    Data = clienteRequest.Data,
                    Success = true
                };
            }
            catch (InvalidCpfException)
            {
                return new ClienteResponse
                {
                    ErrorCode = ErrorCodes.INVALID_CPF,
                    Success = false,
                    Message = "O CPF informado é nulo ou inválido."
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new ClienteResponse
                {
                    ErrorCode = ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    Success = false,
                    Message = "As informações obrigatórias não foram informadas."
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
