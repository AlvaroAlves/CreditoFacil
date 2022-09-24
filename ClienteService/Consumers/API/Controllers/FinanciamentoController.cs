using Application;
using Application.Financiamentos.DTO;
using Application.Financiamentos.Ports;
using Application.Financiamentos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanciamentoController : ControllerBase
    {
        private readonly ILogger<FinanciamentoController> _logger;
        private readonly IFinanciamentoManager _financiamentoManager;

        public FinanciamentoController(ILogger<FinanciamentoController> logger, IFinanciamentoManager financiamentoManager)
        {
            _logger = logger;
            _financiamentoManager = financiamentoManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinanciamentoDTO>> Get(int id)
        {
            var res = await _financiamentoManager.GetFinanciamento(id);
            if (res.Success) return Ok(res.Data);
            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return NotFound(res);
            _logger.LogError("Código de erro não tratado", res);
            return BadRequest(res);
        }
    }
}
