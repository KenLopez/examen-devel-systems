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
    public class TipoDA :ITipoDA
    {
        private readonly IContexto _contexto;
        public TipoDA(IContexto contexto) { 
            _contexto = contexto;
        }
        public DataSet ObtenerTipos()
        {
            DataSet resp = new DataSet();
            using (SqlConnection sqlConn = new SqlConnection(_contexto.GetConnectionString()))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "OBTENER_TIPOS";
                cmd.Connection = sqlConn;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    ad.Fill(resp);
                }
            }
            return resp;
        }
    }


}
