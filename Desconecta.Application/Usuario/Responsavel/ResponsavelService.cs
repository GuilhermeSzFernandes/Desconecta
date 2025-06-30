using Desconecta.Repository;
using Desconecta.Repository.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desconecta.Application.Usuario.Responsavel
{
    public class ResponsavelService
    {
        private readonly DesconectaContext _context;

        public ResponsavelService(DesconectaContext context)
        {
            _context = context;
        }

        public int adicionarResponsavel(ResponsavelRequest obj)
        {
            try
            {
                var usuario = new tabUsuariosResponsaveis
                {
                    userName = obj.Username,
                    email = obj.Email,
                    nomeCompleto = obj.NomeCompleto
                };

                usuario.senhaHash = BCrypt.Net.BCrypt.HashPassword(obj.Senha);

                _context.UsuariosResponsaveis.Add(usuario);
                _context.SaveChanges();

                return usuario.id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<ResponsavelResponse> BuscarTodosOsUsuarios()
        {
            try
            {
                return _context.UsuariosResponsaveis.Select(x => new ResponsavelResponse { 
                    id = x.id,
                    email = x.email,
                    username = x.userName,
                    nomeCompleto = x.nomeCompleto
                }).ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}
