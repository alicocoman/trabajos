using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Repositorios.UtilidadBd;
using Repositorios.Context;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesNegocio;

namespace Repositorios
{
   public class RepositorioIpss:IRepositorioIpss
    {

        public bool Add(Ipss unIpss)
        {
            if (unIpss != null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                        if (unIpss != db.Ipss.Find(unIpss.NroMSP))
                        {
                            db.Ipss.Add(unIpss);
                            db.SaveChanges();
                            return true;

                        }
                    }

                }
                catch { return false; }

            }
            return false;
        }


        
        public IEnumerable<Ipss> FindAll()
        {
            using (ObliContext db = new ObliContext())
            {
                var prestadores = db.Ipss.ToList();
                if (prestadores != null)
                {
                    return prestadores;
                }
                else {
                    return null;
                }
            }
        }


        public Ipss FindById(int Id)
        {
            using (ObliContext db = new ObliContext())
            {
                var prestador = db.Ipss.Where(I=>I.NroMSP==Id).ToList();
                if (prestador.Count() == 1)
                {
                    Ipss unIpss = prestador.ToList()[0];
                    return unIpss;
                }
                else
                {
                    return null;
                }
            }
        }
        /*No se usa*/
        public bool Remove(Ipss unIpss)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Update(Ipss unIpss)
        {
            throw new NotImplementedException();
        }
    }
}

