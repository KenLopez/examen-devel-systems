using BusinessLayer.Interfaces;
using BusinessLayer.Viewmodels;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    internal class EncuestaBL:IEncuestaBL
    {
        private readonly IEncuestaDA _encuestaDA;
        public EncuestaBL(IEncuestaDA encuestaDA)
        {
            _encuestaDA = encuestaDA;
        }

        public bool EliminarEncuesta(int encuesta)
        {
            return _encuestaDA.EliminarEncuesta(encuesta);
        }

        public bool EliminarCampo(int campo)
        {
            return _encuestaDA.EliminarCampo(campo);
        }

        public bool CrearEncuesta(Encuesta encuesta)
        {
            return _encuestaDA.RegistrarEncuesta(encuesta);
        }

        public bool CrearCampo(Campo campo)
        {
            return _encuestaDA.RegistrarCampo(campo);
        }

        public bool CrearRespuesta(EncuestaViewmodel respuesta)
        {
            DataSet ds = _encuestaDA.RegistrarRespuesta(respuesta.Encabezado.Id);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            try
            {
                DataTable res = ds.Tables[0];
                int resp = res.AsEnumerable().Select(row => row.Field<int>("Id")).ToList()[0];
                foreach (CampoViewmodel campo in respuesta.Campos)
                {
                    _encuestaDA.RegistrarRespuestaCampo(new Respuesta_Campo
                    {
                        Campo = campo.campo.Id,
                        Informacion = campo.Informacion,
                        Respuesta = resp
                    });
                }
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public List<Encuesta> ObtenerEncuestas(int usuario)
        {
            DataSet ds = _encuestaDA.ObtenerEncuestas(usuario);
            List<Encuesta> result = new();
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return result;
            }
            DataTable dt = ds.Tables[0];
            result = dt.AsEnumerable().Select(row => new Encuesta
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre") ?? string.Empty,
                Descripcion = row.Field<string>("Descripcion") ?? string.Empty,
                Usuario = usuario
            }).ToList();
            
            return result;
        }

        public List<Respuesta> ObtenerRespuestas(int encuesta)
        {
            DataSet ds = _encuestaDA.ObtenerRespuestas(encuesta);
            List<Respuesta> result = new();
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return result;
            }
            DataTable dt = ds.Tables[0];
            result = dt.AsEnumerable().Select(row => new Respuesta
            {
                Id = row.Field<int>("Id"),
                Fecha = row.Field<string>("Fecha") ?? string.Empty,
                Encuesta = row.Field<int>("Encuesta")
            }).ToList();

            return result;
        }

        public EncuestaViewmodel ObtenerEncuesta(int encuesta)
        {
            DataSet ds = _encuestaDA.ObtenerEncuesta(encuesta);
            EncuestaViewmodel result = new();
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return result;
            }
            EncabezadoViewmodel encabezado = ds.Tables[0].AsEnumerable().Select(row => new EncabezadoViewmodel
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre") ?? string.Empty,
                Descripcion = row.Field<string>("Descripcion") ?? string.Empty
            }).ToList()[0];

            List<CampoViewmodel> campos = ds.Tables[1].AsEnumerable().Select(row => new CampoViewmodel
            {
                campo = new Campo
                {
                    Id = row.Field<int>("Id"),
                    Titulo = row.Field<string>("Titulo") ?? string.Empty,
                    Requerido = row.Field<bool>("Requerido")
                },
                Tipo = row.Field<string>("Tipo") ?? string.Empty
            }).ToList();

            result.Encabezado = encabezado;
            result.Campos = campos;

            return result;
        }

        public EncuestaViewmodel ObtenerRespuesta(int respuesta)
        {
            DataSet ds = _encuestaDA.ObtenerRespuesta(respuesta);
            EncuestaViewmodel result = new();
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return result;
            }
            EncabezadoViewmodel encabezado = ds.Tables[0].AsEnumerable().Select(row => new EncabezadoViewmodel
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre") ?? string.Empty,
                Descripcion = row.Field<string>("Descripcion") ?? string.Empty,
                Fecha = row.Field<string>("Fecha") ?? string.Empty
            }).ToList()[0];

            List<CampoViewmodel> campos = ds.Tables[1].AsEnumerable().Select(row => new CampoViewmodel
            {
                campo = new Campo
                {
                    Id = row.Field<int>("Id"),
                    Titulo = row.Field<string>("Titulo") ?? string.Empty
                },
                Informacion = row.Field<string>("Informacion") ?? string.Empty
            }).ToList();

            result.Encabezado = encabezado;
            result.Campos = campos;

            return result;
        }

    }
}
