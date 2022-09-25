using Application;
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

        public ContratoController(ILogger<FinanciamentoController> logger, IContratoManager contratoManager)
        {
            _logger = logger;
            _contratoManager = contratoManager;
        }

        [HttpPost]
        [Route("{cpf}/contrato")]
        public async Task<ActionResult<ContratoDTO>> Post(string cpf, ContratoDTO cliente)
        {

            var request = new CreateContratoRequest
            {
                Data = cliente,
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
