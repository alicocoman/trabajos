using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MVC.Models
{
    public class ModeloCompras
    {
        [ReadOnly(true)]
        [Display(Name = "Numero de compra")]
        public int Id { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Nombre Vacuna")]
        public string NombreVacuna { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Numero de comprador")]
        public int NroCompradorMSP { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Dosis compradas")]
        public int CantDosisCompradas { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Monto total")]
        public decimal TotalCompra { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Precio unitario de la vacuna (al momento de compra)")]
        public decimal PrecioUnitVacuna { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Fecha de la compra")]
        public DateTime FechaCompra { get; set; }
    }
}