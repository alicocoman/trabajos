using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioProgramacion2
{
    //Generamos la clase padre Excursion  publica y abstracta para que sus hijos( Nacional e Internacional) puedan heredar tanto sus propiedasdes como sus metodos
    public abstract class Excursion :IComparable<Excursion>
    {
        //Creamos las propiedades de la clase Excursion ( estas son las que se comparten entre Nacional e Internacional ) para que sus clases hijas puedan heredarlas
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaComienzo  { get; set; }

        public int CantDias { get; set; }
        public int LugaresDisponibles { get; set; }

        public double Taza { get; set; }
        public string Tipo { get; set; }

        //Creamos un contador incremental para los numeros de excursion
        protected static int UltimoId = 1000;
        //Generamos una lista de destino propia para cada excursion para que sus clases hijas las hereden
        protected List<Destino> listaDestinosDeExcursion = new List<Destino>();
        public List<Destino> GetlistaDestinosDeExcursion()
        {
            return listaDestinosDeExcursion;
        }
       public abstract  List<Destino> AgregarDestinosExcursion(Destino d);
       
       
        //creamos los metodos que compartiran los hijos de forma abstracta para que tengan que si o si usarlos
        public abstract override string ToString();
        public abstract double CalcularCostoDolares();
        public abstract double CalcularCostoPesos();

        public abstract double obtenerDescuentoORecargo();

        public int CompareTo(Excursion other)
        {
            if (this.FechaComienzo.CompareTo(other.FechaComienzo) < 0)
            {
                return 1;
            }
            else if (this.FechaComienzo.CompareTo(other.FechaComienzo) > 0)
            {
                return -1;
            }
            else
            {

                    return 0;
               


            }
        }

    }
}
