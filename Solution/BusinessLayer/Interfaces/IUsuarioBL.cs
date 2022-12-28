using BusinessLayer.Viewmodels;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUsuarioBL
    {
        bool RegistrarUsuario(Usuario usuario);
        UsuarioViewmodel LoginUsuario(Usuario usuario, string secretKey);
    }
}
