using Desconecta.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Application.Dispositivo
{
    public class DispositivoService
    {

        private readonly DesconectaContext _context;

        public DispositivoService(DesconectaContext context)
        {
            _context = context;
        }

        public bool verificarBloqueio(string codigo)
        {
            var count = _context.DispositivosFilhos.Where(x => x.codigoMaquina == codigo && x.bloqueado == true).ToList();
            if (count.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
