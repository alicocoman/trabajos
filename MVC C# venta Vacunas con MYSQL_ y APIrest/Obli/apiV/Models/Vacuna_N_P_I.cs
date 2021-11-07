using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiV;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace apiV.Models
{
    public class Vacuna_N_P_I
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