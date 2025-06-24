using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Desconecta.Repository;
using BCrypt.Net;

namespace Desconecta.Application.Autenticacao
{
    public class AutenticacaoService
    {
        private readonly DesconectaContext _context;

        public AutenticacaoService(DesconectaContext context)
        {
            _context = context;
        }

        public string Autenticar(AutenticacaoRequest obj)
        {
            var responsavel = _context.UsuariosResponsaveis.FirstOrDefault(x => x.email == obj.Email);

            if (responsavel != null && BCrypt.Net.BCrypt.Verify(obj.Senha, responsavel.senhaHash))
            {
                var tokenString = GerarToken();
                return tokenString;
            }
            else
            {
                return null;
            }
        }

        private string GerarToken()
        {
            var issuer = "Desconecta";
            var audience = "Clientes";
            var key = "f363cbe7-40c3-47b6-bb52-9252a7d66106";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
