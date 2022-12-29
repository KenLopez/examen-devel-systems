using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Viewmodels
{
    public class EncuestaViewmodel
    {
        public EncabezadoViewmodel Encabezado { get; set; } = new EncabezadoViewmodel();
        public List<CampoViewmodel> Campos { get; set; } = new List<CampoViewmodel>();
    }
}
