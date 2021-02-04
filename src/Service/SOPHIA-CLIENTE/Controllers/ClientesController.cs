using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOPHIA_CLIENTE.Application.Commands;
using SOPHIA_Core.Mediator;
using SOPHIA_WebApiCore.Controllers;

namespace SOPHIA_CLIENTE.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), "Paulo", "paulo@edu.com", "30314299076"));

            return CustomResponse(resultado);
        }
    }
}
