using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.EntidadesNegocio
{
    [Table("Compras")]
    public class Compra
    {
        
        [Key,Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UnaVacuna")]
        public string NombreVacuna { get; set; }
        public virtual Vacuna UnaVacuna { get; set; }
        [ForeignKey("Comprador")]
        public int NroCompradorMSP { get; set; }
        public virtual Ipss Comprador { get; set; }
        [Required]
        public int CantDosisCompradas { get; set; }
        [Required]
        public decimal TotalCompra { get; set; }
        [Required]
        public decimal PrecioUnitVacuna { get; set; }
        [DataType(DataType.Date),Required]
        public DateTime FechaCompra { get; set; }

        

        public decimal CalcularTotal()
        {
            decimal precioTotal=PrecioUnitVacuna * CantDosisCompradas;
            return precioTotal;
        }



    }
}
