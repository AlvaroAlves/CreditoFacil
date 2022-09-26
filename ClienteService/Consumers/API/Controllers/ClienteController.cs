using Application;
using Application.Clientes.DTO;
using Application.Clientes.Queries;
using Application.Clientes.Requests;
using Application.Ports;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Area("Cliente")]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteManager _clienteManager;
        private readonly IMediator _mediator;

        public ClienteController(ILogger<ClienteController> logger, IClienteManager clienteManager, IMediator mediator)
        {
            _logger = logger;
            _clienteManager = clienteManager;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post(InsertClienteDTO cliente)
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

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ClienteDTO>> Get(string cpf)
        {
            var res = await _clienteManager.GetCliente(cpf);
            if (res.Success) return Ok(res.Data);
            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return NotFound(res);
            _logger.LogError("Código de erro não tratado", res);
            return BadRequest(res);
        }

        [HttpGet]
        [Route("clientesEmAtraso")]
        public async Task<ActionResult<List<ClienteDTO>>> Get()
        {
            var query = new GetCincoClientesAtrasoQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
