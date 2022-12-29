using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using BusinessLayer.Viewmodels;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaBL _encuestaBL;
        public EncuestaController(IEncuestaBL encuestaBL)
        {
            _encuestaBL = encuestaBL;
        }

        [Authorize]
        [HttpPost]
        public ActionResult PostEncuesta([FromBody] Encuesta encuesta)
        {
            bool resp = _encuestaBL.CrearEncuesta(encuesta);
            if (resp)
            {
                return Ok(resp);
            }
            return BadRequest("Error al crear encuesta");
        }

        [Authorize]
        [HttpPost]
        [Route("Campo")]
        public ActionResult PostCampo([FromBody] Campo campo)
        {
            bool resp = _encuestaBL.CrearCampo(campo);
            if (resp)
            {
                return Ok(resp);
            }
            return BadRequest("Error al crear campo");
        }

        [Authorize]
        [HttpPost]
        [Route("Respuesta")]
        public ActionResult PostRespuesta([FromBody] EncuestaViewmodel respuesta)
        {
            bool resp = _encuestaBL.CrearRespuesta(respuesta);
            if (resp)
            {
                return Ok(resp);
            }
            return BadRequest("Error al registrar respuesta");
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteEncuesta(int id)
        {
            bool resp = _encuestaBL.EliminarEncuesta(id);
            if (resp)
            {
                return Ok(resp);
            }
            return BadRequest("Error al eliminar encuesta");
        }

        [Authorize]
        [HttpDelete]
        [Route("Campo/{id}")]
        public ActionResult DeleteCampo(int id)
        {
            bool resp = _encuestaBL.EliminarCampo(id);
            if (resp)
            {
                return Ok(resp);
            }
            return BadRequest("Error al eliminar campo");
        }

        [Authorize]
        [HttpGet]
        [Route("Usuario/{id}")]
        public ActionResult<List<Encuesta>> GetEncuestas(int id)
        {
            List<Encuesta> resp = _encuestaBL.ObtenerEncuestas(id);
            return Ok(resp);
        }

        [Authorize]
        [HttpGet]
        [Route("Reporte/{id}")]
        public ActionResult<List<Respuesta>> GetRespuestas(int id)
        {
            List<Respuesta> resp = _encuestaBL.ObtenerRespuestas(id);
            return Ok(resp);
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public ActionResult<EncuestaViewmodel> GetEncuesta(int id)
        {
            EncuestaViewmodel resp = _encuestaBL.ObtenerEncuesta(id);
            return Ok(resp);
        }

        [Authorize]
        [HttpGet]
        [Route("Respuesta/{id}")]
        public ActionResult<EncuestaViewmodel> GetRespuesta(int id)
        {
            EncuestaViewmodel resp = _encuestaBL.ObtenerRespuesta(id);
            return Ok(resp);
        }

    }
}
