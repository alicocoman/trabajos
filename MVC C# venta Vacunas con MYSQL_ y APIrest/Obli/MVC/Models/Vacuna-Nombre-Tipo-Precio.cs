using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models
{
    public class Vacuna_Nombre_Tipo_Precio
    {
        [ReadOnly(true)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Tipo")]
        public string IdTipoVacuna { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        

    }
}