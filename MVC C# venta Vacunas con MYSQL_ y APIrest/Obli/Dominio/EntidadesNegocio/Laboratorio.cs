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
    [Table("Laboratorios")]
    public class Laboratorio
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Index(IsUnique = true), Required, StringLength(20, MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required,StringLength(100,MinimumLength =3)]
        public string PaisDeOrigen { get; set; }
        [Required]
        public bool ExpEnFabricacionDeVacunas { get; set; }
        public virtual ICollection<Vacuna> Vacunas { get; set; }
        

   
       
    }
}
