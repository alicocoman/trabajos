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
    public class RepositorioCompra:IRepositorioCompra
    {
       
        public bool Add(Compra unaCompra)
        {
            if (unaCompra != null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                        if (unaCompra != db.Compras.Find(unaCompra.Id))
                        {
                            
                            db.Compras.Add(unaCompra);
                            db.SaveChanges();
                            return true;

                        }
                    }

                }
                catch { return false; }

            }
            return false;
        }
      

        public IEnumerable<Compra> FindByVacuna(string nombreVac)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<Compra> FindAll()
        {
            throw new NotImplementedException();

        }

       public IEnumerable<Compra> FindByComprador(int NroCompradorMSP)
        {
            if (NroCompradorMSP > 0)
                using (ObliContext db = new ObliContext())
                {
                    var q = db.Compras.Where(p => p.NroCompradorMSP == NroCompradorMSP).ToList();
                    return q;

                }return null;
            
        }
        public Compra FindById(int Id)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Remove(Compra unaCompra)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Update(Compra unaCompra)
        {
            throw new NotImplementedException();
        }
    }
}

