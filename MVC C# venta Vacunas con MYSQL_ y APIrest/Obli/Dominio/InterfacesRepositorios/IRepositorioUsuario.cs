using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;


namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioUsuario
    {
       

        bool Add(Usuario usu);

        bool Remove(Usuario usu);

        bool Update(Usuario usu);

       Usuario FindByCedula(string cedula);

        IEnumerable<Usuario> FindAll();
    }
}
