using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;


namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioVacuna
    {
        Vacuna FindById(Vacuna vac);

        bool Add(Vacuna vac);

        bool Remove(Vacuna vac);

        bool Update(string Nombre,decimal Precio,int FAprobacion,string Cedula);

        Vacuna FindByName(string Nombre);
        IEnumerable<Vacuna> FindByTodos(int? faseAprobacion, decimal? topeMax, decimal? topeMin, int? idTipoVac, string laboratorio, string pais);
        IEnumerable<Vacuna> FindByAlgunos(int? faseAprobacion, decimal? topeMax, decimal? topeMin, int? idTipoVac, string laboratorio, string pais);


    }
}
