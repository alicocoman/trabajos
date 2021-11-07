using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Repositorios.UtilidadBd;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesNegocio;
using Repositorios.Context;



namespace Repositorios
{
    public class RepositorioLaboratorio : IRepositorioLaboratorio
    {
        /*No se usa*/
        public bool Add(Laboratorio lab)
        {
            if (lab != null) {
                try {
                    using (ObliContext db = new ObliContext()) {
                       if (db.Laboratorios.Find(lab.Id)==null) {
                            db.Laboratorios.Add(lab);
                            db.SaveChanges();
                            return true;
                        
                        }
                    }

                }
                catch { return false; }

            }
            return false;
        }
        /*Pronto*/

        public IEnumerable<Laboratorio> FindByVacuna(string nombreVac)
        {
            throw new NotImplementedException();

        }
        /*Pronto*/
        public IEnumerable<Laboratorio> FindAll()
        {
            List<Laboratorio> labs = new List<Laboratorio>();
            try
            {
                using (ObliContext db = new ObliContext())
                {
                    labs = db.Laboratorios.ToList();

                    return labs;
                }

            }
            catch { return null; }

                     
        }

        /*No se usa*/
        public Laboratorio FindById(int Id)
        {
            if (Id > 0) {
                using (ObliContext db = new ObliContext())
                {
                    try
                    {
                        return db.Laboratorios.Find(Id);
                    }
                    catch { return null; }
            }
        }
            return null;
        }
        /*No se usa*/
        public bool Remove(Laboratorio lab)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Update(Laboratorio lab)
        {
            throw new NotImplementedException();
        }


        
    }
}
