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
    [Table("Vacunas")]
    public class Vacuna
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None), StringLength(10, MinimumLength = 1)]
        public string Nombre { get; set; }
        public virtual ICollection<Laboratorio> Laboratorios { get; set; } = new List<Laboratorio>();
        [ForeignKey("TipoDeVacuna")]
        public int IdTipoDeVacuna { get; set; }
        public virtual TipoVacuna TipoDeVacuna { get; set; }
        [Required, Range(1, maximum: 4)]
        public int CantDosis { get; set; }
        [Required,Range(0,maximum:180)]
        public int DiasEntreDosis { get; set; }
        [Required,Range(0,maximum:100)]
        public int EdadMinima { get; set; }
        [Required,Range(0,maximum:100)]
        public int EdadMaxima { get; set; }
        [Required, Range(0, maximum:100, ErrorMessage = "El rango debe estar entre 0 y 100 ")]
        public decimal EficaciaVsCovid { get; set; }
        [Required, Range(0, maximum: 100 ,ErrorMessage = "El rango debe estar entre 0 y 100 ")]
        public decimal PrevenirHospitalizacion { get; set; }
        [Required, Range(0, maximum: 100, ErrorMessage = "El rango debe estar entre 0 y 100 ")]
        public decimal PrevenirCTI { get; set; }
        [Required, Range(-100 ,maximum: 55, ErrorMessage = "El rango para la temperatura minima es entre -100 y 55 ")]
        public int TempMinima { get; set; }
        [Required, Range(-100, maximum: 55, ErrorMessage = "El rango para la temperatura minima es entre -100 y 55 ")]
        public int TempMaxima { get; set; }

        [Required, Range(1, maximum: 4)]
        public int FaseClinicaAprobacion { get; set; }
       
        public bool AprovacionDeEmergencia { get; set; }
        [Required, StringLength(400, MinimumLength = 1)]
        public string EfectosAdversos { get; set; }

        [Required, Range (0, Int32.MaxValue, ErrorMessage = "No puede ser un numero negativo ")]

        public decimal Precio { get; set; }
        [Required, Range(1,maximum:10000000)]
        public int ProduccionAnual { get; set; }
        [Required]
        public bool FormaParteCovax { get; set; }
        [Required, StringLength(200, MinimumLength = 1)]
        public string PaisesQueAprobaronLaVacuna { get; set; }

        [Required, StringLength(10, MinimumLength = 6)]
        public string CedulaRegistrador { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime FechaUltimaEdicion { get; set; }

        public bool AddLaboratorio(Laboratorio unLab)
        {
            if (unLab == null
                || Laboratorios.Contains(unLab))
                return false;
            Laboratorios.Add(unLab);
            return true;
        }

        public bool Validar() {
            if (EdadMinima<EdadMaxima &&
                                
                DiasEntreDosis>=0 &&
                FaseClinicaAprobacion>0 &&
                FaseClinicaAprobacion<5 &&
                EficaciaVsCovid>=0 &&
                EficaciaVsCovid<=100 &&
                PrevenirHospitalizacion>=0 &&
                PrevenirHospitalizacion<=100 &&
                PrevenirCTI>=0 &&
                PrevenirCTI<=100 &&
                TempMinima>=-100 &&
                TempMinima<TempMaxima &&
                TempMaxima<=55 &&
                EfectosAdversos.Length>0 &&
                Precio>=-1 &&
                CantDosis>=0
                    ) {
                return true;
            }
            else {
                return false;
            }

        }
       

    }
}
