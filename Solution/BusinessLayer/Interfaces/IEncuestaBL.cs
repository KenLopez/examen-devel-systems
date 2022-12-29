using BusinessLayer.Viewmodels;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IEncuestaBL
    {
        bool CrearEncuesta(Encuesta encuesta);
        bool CrearCampo(Campo campo);
        bool CrearRespuesta(EncuestaViewmodel respuesta);
        bool EliminarEncuesta(int encuesta);
        bool EliminarCampo(int campo);
        List<Encuesta> ObtenerEncuestas(int usuario);
        List<Respuesta> ObtenerRespuestas(int encuesta);
        EncuestaViewmodel ObtenerEncuesta(int encuesta);
        EncuestaViewmodel ObtenerRespuesta(int respuesta);
    }
}
