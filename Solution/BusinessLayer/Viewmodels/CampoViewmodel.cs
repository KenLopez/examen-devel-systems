using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Viewmodels
{
    public class CampoViewmodel
    {
        public Campo campo = new();
        public string Informacion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}
