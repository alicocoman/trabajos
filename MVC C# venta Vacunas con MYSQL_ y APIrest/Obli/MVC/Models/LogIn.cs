using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Dominio.EntidadesNegocio;

namespace MVC.Models
{
    public class LogIn
    {
        [Required,StringLength(10, MinimumLength = 5)]
        public string Cedula { get; set; }

        [ Required, StringLength(100, MinimumLength = 7)]
        public string Password { get; set; }
    }
}