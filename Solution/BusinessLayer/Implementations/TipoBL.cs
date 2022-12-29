using BusinessLayer.Interfaces;
using BusinessLayer.Viewmodels;
using DataLayer.Models;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Implementations;
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
    public class TipoBL:ITipoBL
    {
        private readonly ITipoDA _tipoDA;
        public TipoBL(ITipoDA tipoDA) {
            _tipoDA = tipoDA;
        }

        public List<Tipo> ObtenerTipos()
        {
            DataSet ds = _tipoDA.ObtenerTipos();
            List<Tipo> result = new List<Tipo>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = mapResult(ds);
            }
            return result;
        }

        private List<Tipo> mapResult(DataSet ds)
        {
            DataTable table = ds.Tables[0];
            return table.AsEnumerable().Select(row => new Tipo
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre") ?? string.Empty,
            }).ToList();

        }
    }
}
