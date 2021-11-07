using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Dominio.EntidadesNegocio;
namespace MVC.Models
{
    public class ModeloPassword
    {
        [Required(ErrorMessage = "Debe ingresar una contraseña"), StringLength(Int32.MaxValue, MinimumLength = 7)]
        [Display(Name = "Password")]
        [RegularExpression("(?=[0-9])(?=.*[a-z])(?=.*[A-Z]).*", ErrorMessage = "La contraseña debe contener 1 numero, una mayuscula y una minuscula")]
        
        public string Pass1 { get; set; }
        
        [Compare(nameof(Pass1)), Required(ErrorMessage = "Passwords do not match")]
         [Display(Name = "Password2")]
        public string Pass2 { get; set; }
    }
   
   
    }