using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesNegocio;
using System.Data.Entity;


namespace Repositorios.Context
{
    public class ObliContext:DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoVacuna> TipoVacunas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }
        public DbSet<Ipss> Ipss { get; set; }
        public DbSet<Compra> Compras { get; set; }

       
        public ObliContext() : base("entityFramework")
        {
            
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
          
        }

     
    }
}

