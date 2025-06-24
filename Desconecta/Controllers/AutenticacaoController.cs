using Desconecta.Application.Autenticacao;
using Desconecta.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Desconecta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly DesconectaContext _context;

        public AutenticacaoController(DesconectaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest obj)
        {
            var service = new AutenticacaoService(_context);
            var token = service.Autenticar(obj);

            if (!string.IsNullOrEmpty(token))
                return Ok(new { token });

            return Unauthorized();
        }
    }
}
