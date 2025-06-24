using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Application.Usuario.Responsavel
{
    public class ResponsavelRequest
    {
        public string Username { get; set; }
        public string Senha { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
    }
}
