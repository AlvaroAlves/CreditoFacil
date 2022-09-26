using Application.AnaliseDeCredito;
using Application.AnaliseDeCredito.DTO;
using Application.Contratos.DTO;

namespace AnaliseDeCredito.AnaliseNovaProposta
{
    public class NovaPropostaAdapter : IAnaliseDeCredito
    {
        public async Task<AnaliseDeCreditoDTO> ValidarProposta(ContratoDTO req)
        {
            if (req == null)
                return new AnaliseDeCreditoDTO
                {
                    Aprovado = false,
                    Mensagem = "Não foram informados parâmetros para análise de crédito."
                };
            if (req.ValorTotal > 1000000)
                return new AnaliseDeCreditoDTO
                {
                    Aprovado = false,
                    Mensagem = "O valor do crédito Excede o limite permitido."
                };
            if (req.TipoFinanciamento == 3 && req.ValorTotal < 15000)
                return new AnaliseDeCreditoDTO
                {
                    Aprovado = false,
                    Mensagem = "O Valor do crédito mínimo para o tipo de contrato mencionado não foi suficiente."
                };

            var dataMinima = DateTime.Now.AddDays(15);
            var dataMaxima = DateTime.Now.AddDays(40);
            if (req.DataPrimeiroVencimento < dataMinima || req.DataPrimeiroVencimento > dataMaxima)
                return new AnaliseDeCreditoDTO
                {
                    Aprovado = false,
                    Mensagem = "A primeira parcela deve estar entre 15 e 45 dias a partir da data atual."
                };
            if (req.ValorTotal < 1)
                return new AnaliseDeCreditoDTO
                {
                    Aprovado = false,
                    Mensagem = "O Valor do crédito não pode ser inferior a 1."
                };
            if (req.NumeroDeParcelas  < 5 || req.NumeroDeParcelas > 72)
                return new AnaliseDeCreditoDTO
                {
                    Aprovado = false,
                    Mensagem = "A quantidade de parcelas deve ser entre 5 e 72 vezes."
                };

            decimal taxaDeJuros = 0;
            switch (req.TipoFinanciamento)
            {
                case 1:
                    taxaDeJuros = 2;
                    break;
                case 2:
                    taxaDeJuros = 1;
                    break;
                case 3:
                    taxaDeJuros = 5;
                    break;
                case 4:
                    taxaDeJuros = 3;
                    break;
                case 5:
                    taxaDeJuros = 9;
                    break;
                default:
                    return new AnaliseDeCreditoDTO
                    {
                        Aprovado = false,
                        Mensagem = "O tipo de crédito informado é inválido"
                    };
            }

            var valorJuros = Math.Truncate(((taxaDeJuros / 100) * req.ValorTotal) * 100 / 100);
            return new AnaliseDeCreditoDTO
            {
                Aprovado = true,
                ValorDosJuros = valorJuros,
                ValorTotalComJuros = req.ValorTotal + valorJuros
            };
        }
    }
}
