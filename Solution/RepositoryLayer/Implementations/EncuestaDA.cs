using DataLayer.Context;
using DataLayer.Models;
using RepositoryLayer.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLayer.Implementations
{
    public class EncuestaDA :IEncuestaDA
    {
        private readonly IContexto _contexto;
        public EncuestaDA(IContexto contexto) { 
            _contexto = contexto;
        }
        public DataSet ObtenerEncuestas(int usuario)
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OBTENER_ENCUESTAS";
                cmd.Parameters.Add("@pUsuario", SqlDbType.VarChar).Value = usuario;
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }

        public DataSet ObtenerEncuesta(int encuesta)
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OBTENER_ENCUESTA";
                cmd.Parameters.Add("@pEncuesta", SqlDbType.VarChar).Value = encuesta;
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }

        public DataSet ObtenerRespuestas(int encuesta)
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OBTENER_RESPUESTAS";
                cmd.Parameters.Add("@pEncuesta", SqlDbType.VarChar).Value = encuesta;
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }

        public DataSet ObtenerRespuesta(int respuesta)
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OBTENER_RESPUESTA";
                cmd.Parameters.Add("@pRespuesta", SqlDbType.VarChar).Value = respuesta;
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }

        public bool RegistrarEncuesta(Encuesta encuesta)
        {
            try
            {
                DataSet resp = new DataSet();
                using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CREAR_ENCUESTA";
                    cmd.Parameters.Add("@pUsuario", SqlDbType.Int).Value = encuesta.Usuario;
                    cmd.Parameters.Add("@pNombre", SqlDbType.VarChar).Value =   encuesta.Nombre;
                    cmd.Parameters.Add("@pDescripcion", SqlDbType.VarChar).Value = encuesta.Descripcion;
                    cmd.Connection = sqlConn;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                return false;
            }
        }

        public bool RegistrarCampo(Campo campo)
        {
            try
            {
                DataSet resp = new DataSet();
                using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CREAR_CAMPO";
                    cmd.Parameters.Add("@pEncuesta", SqlDbType.Int).Value = campo.Encuesta;
                    cmd.Parameters.Add("@pTitulo", SqlDbType.VarChar).Value = campo.Titulo;
                    cmd.Parameters.Add("@pRequerido", SqlDbType.Bit).Value = campo.Requerido ? 1 : 0;
                    cmd.Parameters.Add("@pTipo", SqlDbType.Int).Value = campo.Tipo;
                    cmd.Connection = sqlConn;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public DataSet RegistrarRespuesta(int encuesta)
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RESPONDER_ENCUESTA";
                cmd.Parameters.Add("@pEncuesta", SqlDbType.VarChar).Value = encuesta;
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }

        public bool RegistrarRespuestaCampo(Respuesta_Campo respuesta)
        {
            try
            {
                DataSet resp = new DataSet();
                using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "RESPONDER_CAMPO";
                    cmd.Parameters.Add("@pCampo", SqlDbType.VarChar).Value = respuesta.Campo;
                    cmd.Parameters.Add("@pInformacion", SqlDbType.VarChar).Value = respuesta.Informacion;
                    cmd.Parameters.Add("@pRespuesta", SqlDbType.VarChar).Value = respuesta.Respuesta;
                    cmd.Connection = sqlConn;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarEncuesta(int encuesta)
        {
            try
            {
                DataSet resp = new DataSet();
                using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ELIMINAR_ENCUESTA";
                    cmd.Parameters.Add("@pEncuesta", SqlDbType.VarChar).Value = encuesta;
                    cmd.Connection = sqlConn;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarCampo(int campo)
        {
            try
            {
                DataSet resp = new DataSet();
                using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ELIMINAR_CAMPO";
                    cmd.Parameters.Add("@pCampo", SqlDbType.VarChar).Value = campo;
                    cmd.Connection = sqlConn;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }


}
