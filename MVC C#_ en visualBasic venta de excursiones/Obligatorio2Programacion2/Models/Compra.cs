using obligatorioProgramacion2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2Programacion2.Models
{
    public class Compra
    {
        public int Id { get; set; }

        
        protected static int UltimoId = 0;


        public Usuario Comprador { get; set; }
        public Excursion ExcursionComprada { get; set; }
        public int CantidadPersonasMayores { get; set; }
        public  int CantidadPersonasMenores { get; set; }
        public double CostoPesosPasajero { get; set; }
        public double CostoDolaresPasajero { get; set; }
        public double costoTotalPesos { get; set; }
        public double costoTotalDolares{ get; set; }
        public bool activa { get; set; }
        public DateTime FechaCompra { get; set; }
        public int TotalPasajeros { get; set; }
        public double DescuentoAumentoPesos { get; set; }
        public double DescuentoAumentoDolares { get; set; }
        public Compra(){}

        public Compra(Usuario comprador, Excursion excursionComprada, int cantidadPersonasMayores, int cantidadPersonasMenores,double pesos,double dolares,double costoPesosPasajero, double costoDolaresPasajero, double descAutPesos,double descAutoDolares)
        {
            Id = UltimoId;
            UltimoId = UltimoId + 1;
            Comprador = comprador;
            ExcursionComprada = excursionComprada;
            CantidadPersonasMayores = cantidadPersonasMayores;
            CantidadPersonasMenores = cantidadPersonasMenores;
            costoTotalPesos = pesos;
            costoTotalDolares = dolares;
            activa = true;
            FechaCompra = DateTime.Today;
            TotalPasajeros = cantidadPersonasMayores + cantidadPersonasMenores;
            CostoPesosPasajero =costoPesosPasajero;
            CostoDolaresPasajero =costoDolaresPasajero;
            DescuentoAumentoPesos = descAutPesos;
            DescuentoAumentoDolares = descAutoDolares;
          
            
        }
        

        
    }
}