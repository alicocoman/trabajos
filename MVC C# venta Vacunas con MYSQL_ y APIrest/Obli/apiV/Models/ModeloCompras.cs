using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace apiV.Models
{
    public class ModeloCompras
    {
        
        [Display(Name = "Numero de compra")]
        public int Id { get; set; }

   
        [Display(Name = "Nombre Vacuna")]
        public string NombreVacuna { get; set; }
        
      
        [Display(Name = "Numero de comprador")]
        public int NroCompradorMSP { get; set; }

   
        [Display(Name = "Dosis compradas")]
        public int CantDosisCompradas { get; set; }
   
        [Display(Name = "Monto total")]
        public decimal TotalCompra { get; set; }
      
        [Display(Name = "Precio unitario de la vacuna (al momento de compra)")]
        public decimal PrecioUnitVacuna { get; set; }
        
        [Display(Name = "Fecha de la compra")]
        public DateTime FechaCompra { get; set; }
    }
}