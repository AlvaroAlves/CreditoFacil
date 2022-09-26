using Application;
using Application.AnaliseDeCredito;
using Application.AnaliseDeCredito.DTO;
using Application.Contratos.DTO;
using Application.Contratos.Ports;
using Application.Contratos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Area("Cliente")]
    [Route("api/Cliente")]
    public class ContratoController: ControllerBase
    {
        private readonly ILogger<FinanciamentoController> _logger;
        private readonly IContratoManager _contratoManager;
        private readonly IAnaliseDeCredito _analiseDeCredito;

        public ContratoController(ILogger<FinanciamentoController> logger, 
            IContratoManager contratoManager,
            IAnaliseDeCredito analiseDeCredito)
        {
            _logger = logger;
            _contratoManager = contratoManager;
            _analiseDeCredito = analiseDeCredito;
        }

        [HttpPost]
        [Route("validarProposta")]
        public async Task<ActionResult<AnaliseDeCreditoDTO>> Get(ContratoDTO contrato)
        {
            var ret = await _analiseDeCredito.ValidarProposta(contrato);
            if (!ret.Aprovado)
                return BadRequest(ret);
            return Ok(ret);
        }

        [HttpPost]
        [Route("{cpf}/CriarNovoContrato")]
        public async Task<ActionResult<ContratoDTO>> Post(string cpf, ContratoDTO contrato)
        {
            var ret = await _analiseDeCredito.ValidarProposta(contrato);
            if (!ret.Aprovado)
                return BadRequest(ret);

            contrato.ValorTotal = ret.ValorTotalComJuros;

            var request = new CreateContratoRequest
            {
                Data = contrato,
            };
            var res = await _contratoManager.CreateContrato(cpf, request);
            if (res.Success) return Created("", res.Data);
            if (res.ErrorCode == ErrorCodes.INVALID_CPF)
                return BadRequest(res);
            else if (res.ErrorCode == ErrorCodes.COULD_NOT_STORE_DATA)
                return BadRequest(res);
            else if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return BadRequest(res);

            _logger.LogError("Código de erro não tratado", res);
            return BadRequest(res);
        }
    }
}
