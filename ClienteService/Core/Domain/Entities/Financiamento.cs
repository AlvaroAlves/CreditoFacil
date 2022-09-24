using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Financiamento
    {
        public int Id { get; set; }
        public TipoFinanciamento TipoFinanciamento { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Parcela> Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataUltimoVencimento { get; set; }

        private void ValidateState()
        {
            
        }

        public async Task Save(IFinanciamentoRepository _repository)
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
