using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public int Encuesta { get; set; }
    }
}
