using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Repositorios.UtilidadBd;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesNegocio;
using System.Data;
using Repositorios.Context;
using System.Data.Entity;

namespace Repositorios
{
    public class RepositorioVacuna : IRepositorioVacuna
    {
       // private RepositorioLaboratorio repoLab = new RepositorioLaboratorio();

        //private RepositorioTipoVacuna repoTVac = new RepositorioTipoVacuna();
     
        public bool Add(Vacuna vac)
        {
            if (vac != null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                        if (FindByName(vac.Nombre) == null && vac.Validar())
                        {

                            db.Vacunas.Add(vac);
                            db.Entry(vac.TipoDeVacuna).State = System.Data.Entity.EntityState.Unchanged;
                            foreach (Laboratorio l in vac.Laboratorios)
                            {
                                db.Entry(l).State = System.Data.Entity.EntityState.Unchanged;
                            }
                            db.SaveChanges();
                            return true;


                        }
                    }

                }
                catch { return false; }

            }
            return false;

        }


        /*Preguntar si esta bien*/
        public IEnumerable<Vacuna> FindAll()
        {
            try {
                using (ObliContext db = new ObliContext())
                {


                    var vacBuscadas = db.Vacunas
                        .Include(c => c.Laboratorios)
                        .Include(c => c.TipoDeVacuna);
                    return vacBuscadas.ToList();
               
            }

        }
                catch (Exception ex)
                { return null; }
}
        
        /*No se usa*/
        public Vacuna FindById(Vacuna vac)
        {
            throw new NotImplementedException();
        }
        /*Falta terminar(mirar por las dudas)*/
        public Vacuna FindByName(string nombre)
        {
            if (nombre != null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                      
                     
                        var vacBuscada = db.Vacunas.Where(c => c.Nombre == nombre)
                            .Include(c=> c.Laboratorios)
                            .Include(c => c.TipoDeVacuna);
                        if (vacBuscada.Count() == 1)
                        {
                            Vacuna unaVac = vacBuscada.ToList()[0];
                            return unaVac;
                        }
                        else { return null; }
                    }

                }
                catch (Exception ex)
                { return null; }
            }
            else { return null; }
        }
        /*No se usa*/
        public bool Remove(Vacuna vac)
        {
            throw new NotImplementedException();
        }
        /*Verificar*/
        public bool Update(string Nombre, decimal Precio,int FAprobacion,string Cedula)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacuna> FindByAlgunos(int? faseAprobacion, decimal? topeMax,decimal? topeMin,int? idTipoVac,string laboratorio,string pais) {
           var totalVacunas = new List<Vacuna>();
            try
            {
                using (ObliContext db = new ObliContext())
                {
                    var vacs = db.Vacunas
                       .Include(v => v.Laboratorios)
                       .Include(v => v.TipoDeVacuna)
                       .ToList();
                    if (faseAprobacion == null && topeMax == null && topeMin == null && idTipoVac == null && String.IsNullOrEmpty(laboratorio) && String.IsNullOrEmpty(pais))
                    {
                        return vacs;
                    }
                    if (faseAprobacion != null)
                    {
                        var listaXFase = vacs.Where(q => q.FaseClinicaAprobacion == faseAprobacion).ToList();
                        totalVacunas.AddRange(listaXFase);

                    }
                    if (topeMax != null && topeMin != null)
                    {

                        var listaXPrecios = vacs.Where(q => q.Precio >= topeMin && q.Precio <= topeMax).ToList();
                        totalVacunas.AddRange(listaXPrecios.FindAll((r) => !totalVacunas.Contains(r)));

                    }
                    if (idTipoVac != null)
                    {
                        var listaXTipoVac = vacs.Where(q => q.IdTipoDeVacuna == idTipoVac).ToList();
                        totalVacunas.AddRange(listaXTipoVac.FindAll((r) => !totalVacunas.Contains(r)));

                    }
                    if (!String.IsNullOrEmpty(laboratorio))
                    {
                        // agregarle StringComparison.InvariantCultureIgnoreCase
                        var listaXLab = vacs.Where(q => q.Laboratorios.Any(lab => lab.Nombre == laboratorio)).ToList();
                        totalVacunas.AddRange(listaXLab.FindAll((r) => !totalVacunas.Contains(r)));

                    }
                    if (!String.IsNullOrEmpty(pais))
                    {
                        // agregarle StringComparison.InvariantCultureIgnoreCase
                        var listaXPais = vacs.Where(q => q.PaisesQueAprobaronLaVacuna.Contains(pais)).ToList();
                        totalVacunas.AddRange(listaXPais.FindAll((r) => !totalVacunas.Contains(r)));

                    }
                }
                return totalVacunas;
            }
            catch { return null; }
          
        }
        public IEnumerable<Vacuna> FindByTodos(int? faseAprobacion, decimal? topeMax, decimal? topeMin, int? idTipoVac, string laboratorio, string pais)
        {
           
            try {

                using (ObliContext db = new ObliContext()) {

                    var vacs = db.Vacunas
                      .Include(v => v.Laboratorios)
                      .Include(v => v.TipoDeVacuna)
                      .ToList();

                    if (faseAprobacion == null && topeMax == null && topeMin == null && idTipoVac == null && String.IsNullOrEmpty(laboratorio) && String.IsNullOrEmpty(pais))
                    {
                        return vacs;
                    }
                    if (faseAprobacion != null)
                    {
                       vacs = vacs.Where(q => q.FaseClinicaAprobacion == faseAprobacion).ToList();
                      

                    }
                    if (topeMax != null && topeMin != null)
                    {

                        vacs = vacs.Where(q => q.Precio >= topeMin && q.Precio <= topeMax).ToList();
                      

                    }
                    if (idTipoVac != null)
                    {
                        vacs = vacs.Where(q => q.IdTipoDeVacuna == idTipoVac).ToList();
                        

                    }
                    if (!String.IsNullOrEmpty(laboratorio))
                    {
                        // agregarle StringComparison.InvariantCultureIgnoreCase
                        vacs = vacs.Where(q => q.Laboratorios.Any(lab => lab.Nombre == laboratorio)).ToList();
                      

                    }
                    if (!String.IsNullOrEmpty(pais))
                    {
                        // agregarle StringComparison.InvariantCultureIgnoreCase
                        vacs = vacs.Where(q => q.PaisesQueAprobaronLaVacuna.Contains(pais)).ToList();
                 

                    }

                    return vacs;

                }

            } catch { return null; }


        }
    }
}
