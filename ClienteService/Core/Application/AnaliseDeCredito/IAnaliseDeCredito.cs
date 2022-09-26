using Application.AnaliseDeCredito.DTO;
using Application.Contratos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AnaliseDeCredito
{
    public interface IAnaliseDeCredito
    {
        Task<AnaliseDeCreditoDTO> ValidarProposta(ContratoDTO req);
    }
}
