namespace Domain.Entities
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Financiamento> Financiamentos { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }

    }
}
