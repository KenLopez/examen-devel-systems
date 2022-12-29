using BusinessLayer.Interfaces;
using BusinessLayer.Viewmodels;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBL _usuarioBL;
        private readonly IConfiguration _configuration;
        public UsuarioController(IUsuarioBL usuarioBL, IConfiguration configuration)
        {
            _usuarioBL = usuarioBL;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<UsuarioViewmodel> Login([FromBody] Usuario usuario)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            UsuarioViewmodel resp = _usuarioBL.LoginUsuario(usuario, secretKey);
            if (resp.Id > 0)
            {
                return Ok(resp);
            }
            return BadRequest("Credenciales incorrectas");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostUsuario([FromBody] Usuario usuario)
        {
            bool resp = _usuarioBL.RegistrarUsuario(usuario);
            if (resp)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
