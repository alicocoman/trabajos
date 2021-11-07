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
    [Table("TipoVacuna")]
    public class TipoVacuna
    {
        [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required,StringLength(10,MinimumLength =1)]
        public string Tipo { get; set; }
        [Required,StringLength(200,MinimumLength =1)]
        public string Descripcion { get; set; }

       
    }
}
