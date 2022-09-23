using Application;
using Application.Clientes.DTO;
using Application.Clientes.Requests;
using Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteManager _clienteManager;

        public ClienteController(ILogger<ClienteController> logger, IClienteManager clienteManager)
        {
            _logger = logger;
            _clienteManager = clienteManager;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post(ClienteDTO cliente)
        {
            var request = new CreateClienteRequest
            {
                Data = cliente,
            };
            var res = await _clienteManager.CreateCliente(request);
            if (res.Success) return Created("",res.Data);
            if (res.ErrorCode == ErrorCodes.MISSING_REQUIRED_INFORMATION)
                return BadRequest(res);
            else if (res.ErrorCode == ErrorCodes.INVALID_CPF)
                return BadRequest(res);
            else if (res.ErrorCode == ErrorCodes.COULD_NOT_STORE_DATA)
                return BadRequest(res);
            else if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return BadRequest(res);
            
            _logger.LogError("Código de erro não tratado", res);
            return BadRequest(res);
        }

        [HttpGet]
        public async Task<ActionResult<ClienteDTO>> Get(string cpf)
        {
            var res = await _clienteManager.GetCliente(cpf);
            if (res.Success) return Ok(res.Data);
            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return NotFound(res);
            _logger.LogError("Código de erro não tratado", res);
            return BadRequest(res);
        }
    }
}
