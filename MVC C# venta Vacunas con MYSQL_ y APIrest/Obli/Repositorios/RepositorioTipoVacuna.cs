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
    public class RepositorioTipoVacuna : IRepositorioTipoVacuna
    {
        /*Pronto*/
        public bool Add(TipoVacuna TVac)
        {
            if (TVac != null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                        if (db.TipoVacunas.Find(TVac.Id)==null)
                        {  
                            db.TipoVacunas.Add(TVac);
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
        public IEnumerable<TipoVacuna> FindAll()
        {
            throw new NotImplementedException();
        }

        /*Pronto*/
        public TipoVacuna FindByTipo(string Tipo)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Remove(TipoVacuna TVac)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Update(TipoVacuna TVac)
        {
            throw new NotImplementedException();
        }

        /*Pronto*/
        public TipoVacuna FindById(int? id)
        {
            if (id!= null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                        var Tvac = db.TipoVacunas.Where(t => t.Id == id);
                        if (Tvac != null)
                        {
                         
                            foreach (TipoVacuna t in Tvac) {
                                TipoVacuna tipo = new TipoVacuna
                                {
                                    Id = t.Id,
                                    Tipo = t.Tipo,
                                    Descripcion = t.Descripcion,

                                };
                                return tipo;

                            }

                        }
                    }

                }
                catch { return null; }

            }
            return null;
        }
    }
}
