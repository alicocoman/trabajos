using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;


namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioLaboratorio
    {     
        IEnumerable<Laboratorio> FindByVacuna(string nombreVacuna);
        bool Add(Laboratorio lab);

        bool Remove(Laboratorio lab);

        bool Update(Laboratorio lab);

        Laboratorio FindById(int Id);

        IEnumerable<Laboratorio> FindAll();
    }
}
