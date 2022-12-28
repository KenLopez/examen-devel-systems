using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class Contexto:DbContext, IContexto
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Encuesta> Encuestas { get; set;}
        public DbSet<Respuesta> Respuestas { get; set;}
        public DbSet<Respuesta_Campo> Respuestas_Campos { get; set; }

        public string GetConnectionString()
        {
            string conn = this.Database.GetDbConnection().ConnectionString;
            return conn;
        }

    }
}
