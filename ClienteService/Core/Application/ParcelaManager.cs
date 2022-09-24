using Application.Parcelas.DTO;
using Application.Parcelas.Ports;
using Application.Parcelas.Requests;
using Application.Parcelas.Responses;
using Domain.Exceptions;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ParcelaManager : IParcelaManager
    {
        private IParcelaRepository _repository;
        public ParcelaManager(IParcelaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ParcelaResponse> CreateParcela(CreateParcelaRequest parcelaRequest)
        {
            try
            {
                var parcela = ParcelaDTO.MapToEntity(parcelaRequest.Data);
                await parcela.Save(_repository);
                return new ParcelaResponse
                {
                    Data = parcelaRequest.Data,
                    Success = true
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new ParcelaResponse
                {
                    ErrorCode = ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    Success = false,
                    Message = "As informações obrigatórias não foram informadas."
                };
            }
            catch (Exception)
            {
                return new ParcelaResponse
                {
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Success = false,
                    Message = "Não foi possível incluir a(s) Parcela(s) no banco."
                };
            }

        }

        public async Task<ParcelaResponse> GetParcela(int id)
        {
            var res = await _repository.Get(id);

            if (res == null)
                return new ParcelaResponse
                {
                    ErrorCode = ErrorCodes.NOT_FOUND,
                    Success = false,
                    Message = "Não foi encontrada nenhuma Parcela com o Id informado."
                };

            return new ParcelaResponse
            {
                Data = ParcelaDTO.MapToDTO(res),
                Success = true
            };

        }
    }
}
