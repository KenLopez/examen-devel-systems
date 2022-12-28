using DataLayer.Context;
using DataLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementations
{
    public class UsuarioDA :IUsuarioDA
    {
        private readonly IContexto _contexto;
        public UsuarioDA(IContexto contexto) { 
            _contexto = contexto;
        }
        public DataSet Login(Usuario usuario)
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LOGUEAR_USUARIO";
                cmd.Parameters.Add("@pUsuario", SqlDbType.VarChar).Value = usuario.Username;
                cmd.Parameters.Add("@pPasswd", SqlDbType.VarChar).Value = usuario.Passwd;
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }

        public bool Registrar(Usuario usuario)
        {
            try
            {
                DataSet resp = new DataSet();
                using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CREAR_USUARIO";
                    cmd.Parameters.Add("@pUsuario", SqlDbType.VarChar).Value = usuario.Username;
                    cmd.Parameters.Add("@pPasswd", SqlDbType.VarChar).Value = usuario.Passwd;
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
    }


}
