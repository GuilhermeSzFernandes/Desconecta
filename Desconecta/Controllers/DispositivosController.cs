using Desconecta.Application.Dispositivo;
using Desconecta.Application.WebSocket;
using Desconecta.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Desconecta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispositivosController : ControllerBase
    {
        private readonly IHubContext<ConnectionHub> _hub;
        private readonly DesconectaContext _context;

        public DispositivosController(IHubContext<ConnectionHub> hub, DesconectaContext context)
        {
            _hub = hub;
            _context = context;
        }

        [HttpPost("bloquear/{codigo}")]
        public async Task<IActionResult> Bloquear(string codigo)
        {
            await _hub.Clients.Group(codigo).SendAsync("ReceberBloqueio", true);
            var computadorFilho = _context.DispositivosFilhos.FirstOrDefault(x => x.codigoMaquina == codigo);
            computadorFilho.bloqueado = true;
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("desbloquear/{codigo}")]
        public async Task<IActionResult> Desbloquear(string codigo)
        {
            await _hub.Clients.Group(codigo).SendAsync("ReceberBloqueio", false);
            var computadorFilho = _context.DispositivosFilhos.FirstOrDefault(x => x.codigoMaquina == codigo);
            computadorFilho.bloqueado = false;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("verificarBloqueio/{codigo}")]
        public IActionResult verificarBloqueio(string codigo)
        {
            var service = new DispositivoService(_context);
            var verificar = service.verificarBloqueio(codigo);
            if (verificar)
                return Ok();
            return BadRequest();
        }
    }
}
