using Desconecta.Application.WebSocket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Desconecta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispositivosController : ControllerBase
    {
        private readonly IHubContext<ConnectionHub> _hub;

        public DispositivosController(IHubContext<ConnectionHub> hub)
        {
            _hub = hub;
        }

        [HttpPost("bloquear/{codigo}")]
        public async Task<IActionResult> Bloquear(string codigo)
        {
            await _hub.Clients.Group(codigo).SendAsync("ReceberBloqueio", true);
            return Ok();
        }

        [HttpPost("desbloquear/{codigo}")]
        public async Task<IActionResult> Desbloquear(string codigo)
        {
            await _hub.Clients.Group(codigo).SendAsync("ReceberBloqueio", false);
            return Ok();
        }

    }
}
