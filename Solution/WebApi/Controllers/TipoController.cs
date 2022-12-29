using BusinessLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {

        private readonly ITipoBL _tipoBL;
        public TipoController(ITipoBL tipoBL)
        {
            _tipoBL = tipoBL;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Tipo>> GetTipos()
        {
            List<Tipo> result = _tipoBL.ObtenerTipos();
            return result;
        }

    }
}
