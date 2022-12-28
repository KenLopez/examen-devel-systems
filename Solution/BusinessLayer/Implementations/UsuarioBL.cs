using BusinessLayer.Interfaces;
using BusinessLayer.Viewmodels;
using DataLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class UsuariosBL : IUsuarioBL 
    {
        public readonly IUsuarioDA _usuarioDA;
        public readonly IConfiguration _configuration;
        public UsuariosBL(IUsuarioDA usuarioDA, IConfiguration configuration) {
            _usuarioDA = usuarioDA;
            _configuration = configuration;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            bool resp = _usuarioDA.Registrar(usuario);
            return resp;
        }

        public UsuarioViewmodel LoginUsuario(Usuario usuario, string secretKey)
        {
            DataSet ds = _usuarioDA.Login(usuario);
            UsuarioViewmodel result = new UsuarioViewmodel();
            if (ds.Tables.Count > 0)
            {
                var key = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Username));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                string bearer = tokenHandler.WriteToken(createdToken);
                result = mapResult(ds, bearer);
            }
            return result;
        }

        private UsuarioViewmodel mapResult(DataSet ds, string token)
        {
            DataTable table = ds.Tables[0];
            return table.AsEnumerable().Select(row => new UsuarioViewmodel
            {
                Id = row.Field<int>("Id"),
                Username = row.Field<string>("Username") ?? string.Empty,
                Token = token
            }).ToList()[0];

        }
    }
}
