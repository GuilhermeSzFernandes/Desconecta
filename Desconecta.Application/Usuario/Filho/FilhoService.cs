using Desconecta.Repository;
using Desconecta.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Application.Usuario.Filho
{
    public class FilhoService
    {
        private readonly DesconectaContext _context;

        public FilhoService(DesconectaContext context)
        {
            _context = context;
        } 

        public bool adicionarCrianca(FilhoRequest obj)
        {
            try
            {
                tabDispositivosFilhos dispositivosFilhos = new tabDispositivosFilhos()
                {
                    id = obj.Id,
                    responsavelId = obj.ResponsavelId,
                    nomeDispositivo = obj.NomeDispositivo,
                    bloqueado = obj.Bloqueado,
                    codigoMaquina = obj.CodigoMaquina,
                    dataCadastro = DateTime.SpecifyKind( DateTime.Now, DateTimeKind.Utc)
                };

                _context.DispositivosFilhos.Add(dispositivosFilhos);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("ERRRRRRRRRRRRRRRRRRO: " + ex.InnerException?.Message ?? ex.Message);
                return false;
            }
        }

        public List<FilhoResponse> listarFilhosPorResponsavel(int responsavelId)
        {
            try
            {
                return _context.DispositivosFilhos
               .Where(f => f.responsavelId == responsavelId)
               .Select(f => new FilhoResponse
               {
                   Id = f.id,
                   ResponsavelId = f.responsavelId,
                   NomeDispositivo = f.nomeDispositivo,
                   Bloqueado = f.bloqueado,
                   CodigoMaquina = f.codigoMaquina,
                   DataCadastro = f.dataCadastro
               }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool VerificarCadastro(string codigoMaquina)
        {
            var count = _context.DispositivosFilhos.Where(x => x.codigoMaquina == codigoMaquina).ToList();
            if(count.Count != 0)
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
