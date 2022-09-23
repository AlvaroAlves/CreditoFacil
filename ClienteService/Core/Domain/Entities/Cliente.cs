using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Entities
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Financiamento> Financiamentos { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }

        private void ValidateState()
        {
            if(string.IsNullOrEmpty(Cpf) || 
                !Utils.IsCpf(Cpf))
            {
                throw new InvalidCpfException();
            }

            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(UF) || string.IsNullOrEmpty(Celular))
            {
                throw new MissingRequiredInformationException();
            }
        }

        public async Task Save(IClienteRepository _repository)
        {
            this.ValidateState();

            if (_repository.Get(Cpf) == null)
            {
                this.Cpf = await _repository.Create(this);
            }
            else
            {
                //await _repository.Update(this);
            }
                
        }
    }
}
