using Application.Clientes.Responses;
using Application.Contratos.DTO;
using Application.Contratos.Ports;
using Application.Contratos.Requests;
using Application.Contratos.Responses;
using Application.Financiamentos.DTO;
using Application.Parcelas.DTO;
using Domain.Entities;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ContratoManager : IContratoManager
    {
        private IClienteRepository _clienteRepository;
        private IFinanciamentoRepository _financiamentoRepository;
        private IParcelaRepository _parcelaRepository;
        public ContratoManager(IClienteRepository clienteRepository,
            IFinanciamentoRepository financiamentoRepository,
            IParcelaRepository parcelaRepository)
        {
            _clienteRepository = clienteRepository;
            _financiamentoRepository = financiamentoRepository;
            _parcelaRepository = parcelaRepository;
        }
        public async Task<ContratoResponse> CreateContrato(string cpf, CreateContratoRequest contratoRequest)
        {
            try
            {
                var cliente = await _clienteRepository.Get(cpf);
                if(cliente == null)
                    return new ContratoResponse
                    {
                        ErrorCode = ErrorCodes.INVALID_CPF,
                        Success = false,
                        Message = "O Contrato não pode ser salvo, o CPF informado não encontra-se cadastrado no banco de dados."
                    };

                var parcelas = new List<Parcela>();
                DateTime dataVencimento = contratoRequest.Data.DataPrimeiroVencimento;
                var valorTotal = contratoRequest.Data.ValorTotal;
                var quantidadeParcelas = contratoRequest.Data.NumeroDeParcelas;
                var valorParcela = Math.Truncate((valorTotal / quantidadeParcelas) * 100 / 100);
                for (int i = 1; i <= quantidadeParcelas; i++)
                {
                    if (i == quantidadeParcelas)
                        valorParcela = valorTotal != (valorParcela * quantidadeParcelas) ? (valorTotal - (valorParcela * (quantidadeParcelas - 1)))  : valorParcela;

                    if (i != 1)
                        dataVencimento = dataVencimento.AddDays(30);

                    parcelas.Add(new Parcela
                    {
                        DataVencimento = dataVencimento,
                        NumeroParcela = i,
                        ValorParcela = valorParcela
                    });
                }

                var financiamento = new Financiamento
                {
                    DataUltimoVencimento = dataVencimento,
                    Parcelas = parcelas,
                    TipoFinanciamento = (Domain.Enums.TipoFinanciamento)contratoRequest.Data.TipoFinanciamento,
                    ValorTotal = valorTotal,
                    Cliente = cliente
                };


                financiamento.Id = await _financiamentoRepository.Create(financiamento);
                parcelas.ForEach(x => x.Financiamento = financiamento);
                parcelas.ForEach(x => _parcelaRepository.Create(x));

                return new ContratoResponse
                {
                    Data = FinanciamentoDTO.MapToDTO(financiamento),
                    Success = true
                };
            }
            catch (Exception)
            {
                return new ContratoResponse
                {
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Success = false,
                    Message = "Não foi possível incluir o cliente no banco."
                };
            }

        }
    }
}
