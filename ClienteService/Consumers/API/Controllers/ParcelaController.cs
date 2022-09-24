using Application;
using Application.Parcelas.DTO;
using Application.Parcelas.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelaController : ControllerBase
    {
        private readonly ILogger<ParcelaController> _logger;
        private readonly IParcelaManager _ParcelaManager;

        public ParcelaController(ILogger<ParcelaController> logger, IParcelaManager ParcelaManager)
        {
            _logger = logger;
            _ParcelaManager = ParcelaManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelaDTO>> Get(int id)
        {
            var res = await _ParcelaManager.GetParcela(id);
            if (res.Success) return Ok(res.Data);
            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return NotFound(res);
            _logger.LogError("Código de erro não tratado", res);
            return BadRequest(res);
        }
    }
}
