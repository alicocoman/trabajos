using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioCompra
    {
        bool Add(Compra unaCompra);
        IEnumerable<Compra> FindByVacuna(string nombreVac);
        IEnumerable<Compra> FindAll();
        Compra FindById(int Id);
        IEnumerable<Compra> FindByComprador(int NroCompradorMSP);
        bool Remove(Compra unaCompra);
        bool Update(Compra unaCompra);
    }
}
