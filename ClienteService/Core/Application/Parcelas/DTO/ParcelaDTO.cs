using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parcelas.DTO
{
    public class ParcelaDTO
    {
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public int IdFinanciamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        public static Parcela MapToEntity(ParcelaDTO parcelaDto)
        {
            return new Parcela
            {
               DataPagamento = parcelaDto.DataPagamento,
               DataVencimento = parcelaDto.DataVencimento,
               Id = parcelaDto.Id,
               NumeroParcela = parcelaDto.NumeroParcela,
               ValorParcela = parcelaDto.ValorParcela
            };
        }

        public static ParcelaDTO MapToDTO(Parcela parcela)
        {
            return new ParcelaDTO
            {
                Id = parcela.Id,
                ValorParcela = parcela.ValorParcela,
                DataPagamento = parcela.DataPagamento,
                NumeroParcela = parcela.NumeroParcela,
                DataVencimento = parcela.DataVencimento,
                IdFinanciamento = parcela.Financiamento.Id
            };
        }
    }
}
