using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace apiV.Models
{
    public class ModeloIpss
    {
        [Required, Range(1, 1000000, ErrorMessage = "debe ser un numero de hasta 6 cifras")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "el numero de registro no puede empezar en 0")]
        public int NroMSP { get; set; }
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "La compra debe ser mayor a 0")]
        [Display(Name = "Cantidad de compras mensuales")]
        public int CantidadMaxComprasMensuales { get; set; }

        [Required, Range(1, Int32.MaxValue, ErrorMessage = "La cantidad de afiliados debe ser superior a 1")]
        [Display(Name = "Cantidad de afiliados")]
        public int CantAfiliados { get; set; }

        [Required, Range(0.1, Int32.MaxValue, ErrorMessage = "El Gasto maximo debe ser un numero positivo")]
        [Display(Name = "Gasto maximo por afiliado")]
        public decimal GastoMaxXAfiliado { get; set; }
        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string Nombre { get; set; }
        [Required, StringLength(20, MinimumLength = 3, ErrorMessage = "El telefono debe tener al menos 3 digitos")]
        public string Telefono { get; set; }
        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string NombreContacto { get; set; }
    }
}