using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IEncuestaDA
    {
        bool RegistrarEncuesta(Encuesta encuesta);
        bool RegistrarCampo(Campo campo);
        bool RegistrarRespuestaCampo(Respuesta_Campo respuesta);
        bool EliminarEncuesta(int encuesta);
        bool EliminarCampo(int campo);
        DataSet ObtenerEncuestas(int usuario);
        DataSet ObtenerRespuestas(int encuesta);
        DataSet ObtenerEncuesta(int encuesta);
        DataSet ObtenerRespuesta(int respuesta);
        DataSet RegistrarRespuesta(int encuesta);

    }
}
