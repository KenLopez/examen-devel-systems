using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Respuesta_Campo
    {
        public int Id { get; set; }
        public int Campo { get; set; }
        public string Informacion { get; set; } = string.Empty;
        public int Respuesta { get; set; }
    }
}
