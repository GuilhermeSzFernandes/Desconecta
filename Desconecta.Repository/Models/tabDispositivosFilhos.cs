using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Repository.Models
{
    public class tabDispositivosFilhos
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("tabUsuariosResponsaveis")]
        public int responsavelId { get; set; }
        public string nomeDispositivo { get; set; }
        public string codigoMaquina { get; set; }
        public bool bloqueado { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}
