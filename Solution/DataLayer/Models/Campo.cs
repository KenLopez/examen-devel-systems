using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Campo
    {
        public int Id { get; set; }
        public int Encuesta { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public bool Requerido { get; set; }
        public int Tipo { get; set; }
    }
}
