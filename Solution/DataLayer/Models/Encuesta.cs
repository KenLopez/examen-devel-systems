using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Encuesta
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Descripcion { get; set; } = String.Empty;

    }
}
