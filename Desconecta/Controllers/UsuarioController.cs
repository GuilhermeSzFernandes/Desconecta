using Desconecta.Application.Usuario;
using Desconecta.Application.Usuario.Filho;
using Desconecta.Application.Usuario.Responsavel;
using Desconecta.Repository;
using Desconecta.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desconecta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DesconectaContext _context;

        public UsuarioController(DesconectaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirResponsavel([FromBody] ResponsavelRequest obj)
        {
            var service = new ResponsavelService(_context);
            var inserirUser = service.adicionarResponsavel(obj);

            if(inserirUser > 0)
                return Ok(new {codigo = inserirUser});

            return BadRequest();

        }

        [HttpPost]
        [Route("Filhos")]
        public IActionResult InserirFilho([FromBody] FilhoRequest request)
        {
            var service = new FilhoService(_context);
            var inserirFilho = service.adicionarCrianca(request);
            if (inserirFilho)
            {
                return Ok();
            }
            else
            {
                return BadRequest();

            }
        }

        [HttpGet]
        [Route("{responsavelId}/Filhos")]
        public IActionResult ListarFilhos(int responsavelId)
        {
            try
            {
                var service = new FilhoService(_context);
                var listar = service.listarFilhosPorResponsavel(responsavelId);

                return Ok(listar);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("VerificarCadastro/{codigoMaquina}")]
        public IActionResult VerificarCadastro(string codigoMaquina)
        {
            var service = new FilhoService(_context);
            var verificar = service.VerificarCadastro(codigoMaquina);
            if (verificar)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("BuscarResponsavel")]
        public IActionResult BuscarTodosUsuariosResponsaveis()
        {
            var service = new ResponsavelService(_context);
            var consulta = service.BuscarTodosOsUsuarios();
            if(consulta != null)
            {
                return Ok(consulta);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("health")]
        public IActionResult Health()
        {
            return Ok("OK");
        }
    }
}
    