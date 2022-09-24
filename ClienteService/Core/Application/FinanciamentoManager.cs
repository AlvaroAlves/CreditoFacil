using Application.Financiamentos.DTO;
using Application.Financiamentos.Ports;
using Application.Financiamentos.Requests;
using Application.Financiamentos.Responses;
using Domain.Exceptions;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class FinanciamentoManager : IFinanciamentoManager
    {
        private IFinanciamentoRepository _repository;
        public FinanciamentoManager(IFinanciamentoRepository repository)
        {
            _repository = repository;
        }
        public async Task<FinanciamentoResponse> CreateFinanciamento(CreateFinanciamentoRequest financiamentoRequest)
        {
            try
            {
                var financiamento = FinanciamentoDTO.MapToEntity(financiamentoRequest.Data);
                await financiamento.Save(_repository);
                return new FinanciamentoResponse
                {
                    Data = financiamentoRequest.Data,
                    Success = true
                };
            }
            catch (InvalidCpfException)
            {
                return new FinanciamentoResponse
                {
                    ErrorCode = ErrorCodes.INVALID_CPF,
                    Success = false,
                    Message = "O CPF informado é nulo ou inválido."
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new FinanciamentoResponse
                {
                    ErrorCode = ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    Success = false,
                    Message = "As informações obrigatórias não foram informadas."
                };
            }
            catch (Exception)
            {
                return new FinanciamentoResponse
                {
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Success = false,
                    Message = "Não foi possível incluir o Financiamento no banco."
                };
            }

        }

        public async Task<FinanciamentoResponse> GetFinanciamento(int id)
        {
            var res = await _repository.Get(id);

            if (res == null)
                return new FinanciamentoResponse
                {
                    ErrorCode = ErrorCodes.NOT_FOUND,
                    Success = false,
                    Message = "Não foi encontrado um Financiamento com o CPF informado."
                };

            return new FinanciamentoResponse
            {
                Data = FinanciamentoDTO.MapToDTO(res),
                Success = true
            };

        }
    }
}
