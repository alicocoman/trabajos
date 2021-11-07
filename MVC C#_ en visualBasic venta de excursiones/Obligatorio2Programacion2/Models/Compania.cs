using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioProgramacion2
{
    //Generamos la clase publica Compania
    public class Compania
    {
        //Creamos las propiedades de la clase Compania
        public int Codigo { get; set; }
        public string Pais { get; set; }

        public Compania(int codigo, string pais)
        {
            Codigo = codigo;
            Pais = pais;
        }

        //reescribimos el metodo ToString() para mostrar en pantalla el objeto cuando nos sea necesario 

        public override string ToString()
        {
            return $"Codigo: {Codigo} Pais: {Pais}";
        }
    }
}
