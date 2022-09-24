using Application.Clientes.DTO;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Financiamentos.DTO
{
    public class FinanciamentoDTO
    {
        public int Id { get; set; }
        public int TipoFinanciamento { get; set; }
        public string Cpf { get; set; }
        //public IEnumerable<ParcelaDTO> Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataUltimoVencimento { get; set; }

        public static FinanciamentoDTO MapToDTO(Financiamento financiamento)
        {
            return new FinanciamentoDTO
            {
                DataUltimoVencimento = financiamento.DataUltimoVencimento,
                Id = financiamento.Id,
                TipoFinanciamento = (int)financiamento.TipoFinanciamento,
                ValorTotal = financiamento.ValorTotal,
                Cpf = financiamento.Cliente.Cpf
            };
        }

        public static Financiamento MapToEntity(FinanciamentoDTO financiamento)
        {
            return new Financiamento
            {
                DataUltimoVencimento = financiamento.DataUltimoVencimento,
                Id = financiamento.Id,
                TipoFinanciamento = (TipoFinanciamento)financiamento.TipoFinanciamento,
                ValorTotal = financiamento.ValorTotal,
                //Cliente = financiamento.Cliente
            };
        }
    }
}
