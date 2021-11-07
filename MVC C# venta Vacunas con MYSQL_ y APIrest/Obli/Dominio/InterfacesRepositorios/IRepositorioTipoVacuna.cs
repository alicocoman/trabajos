using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;


namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioTipoVacuna
    {
      
        bool Add(TipoVacuna TVac);

        bool Remove(TipoVacuna TVac);

        bool Update(TipoVacuna TVac);

        TipoVacuna FindByTipo(string Tipo);

        IEnumerable<TipoVacuna> FindAll();
        TipoVacuna FindById(int? Id);
      
    }
}
