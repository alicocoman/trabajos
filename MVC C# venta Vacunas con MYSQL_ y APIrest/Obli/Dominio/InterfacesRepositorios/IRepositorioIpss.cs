using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioIpss
    {

        bool Add(Ipss unIpss);
        IEnumerable<Ipss> FindAll();
        Ipss FindById(int Id);
        bool Remove(Ipss unIpss);
        bool Update(Ipss unIpss);
       
    }
}
