using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Application.Usuario.Filho
{
    public class FilhoResponse
    {
        public int Id { get; set; }
        public int ResponsavelId { get; set; }
        public string NomeDispositivo { get; set; }
        public string CodigoMaquina { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
