using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Dominio.InterfacesRepositorios;


namespace Dominio.EntidadesNegocio
{
    [Table("Usuarios")]
    public class Usuario
    {
     
        [Key,Required, DatabaseGenerated(DatabaseGeneratedOption.None),StringLength(10,MinimumLength =5)]
        public string Cedula { get; set; }

        [Required,StringLength(100,MinimumLength =7)]
        public string Password { get; set; }

        public bool PrimeraVes { get; set; }

        public bool Validar() {
        
            if (Cedula.Length > 6 
                && Cedula.Length < 10
                && Password.Length>5
                && Password.Any(c=>char.IsUpper(c))
                && Password.Any(c=>char.IsLower(c))
                && Password.Any(c=>char.IsDigit(c))                
                )
            {
                return true;
            }
                return false;
            
        }
    }
}
