using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Parcela
    {
        public int Id { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorParcela { get; set; }
        public Financiamento Financiamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        private void ValidateState()
        {

        }

        public async Task Save(IParcelaRepository _repository)
        {
            this.ValidateState();

            var financiamento = await _repository.Get(Id);
            if (financiamento == null)
            {
                this.Id = await _repository.Create(this);
            }
            else
            {
                await _repository.Update(this);
            }
        }
    }
}
