using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUsuarioDA
    {
        bool Registrar(Usuario usuario);
        DataSet Login(Usuario usuario);
        
    }
}
