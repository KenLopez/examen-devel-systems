using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public interface IContexto
    {
        DbSet<Campo> Campos { get; set; }
        DbSet<Tipo> Tipos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Encuesta> Encuestas { get; set; }
        DbSet<Respuesta> Respuestas { get; set; }
        DbSet<Respuesta_Campo> Respuestas_Campos { get; set; }

        string GetConnectionString();
    }
}
