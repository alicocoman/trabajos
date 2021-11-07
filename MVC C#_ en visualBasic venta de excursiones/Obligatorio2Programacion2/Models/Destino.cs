using System;
using System.Collections.Generic;
using Obligatorio2Programacion2.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioProgramacion2
{
    //Creamos la clase Destino publica para que se pueda acceder desde todas partes del programa
    public class Destino
    {
        private readonly Agencia a = Agencia.GetInstancia();
        //Creamos las propiedades de la clase Destino
        public int Id { get; set; }
        //creamos un contador interno para que lleve cada destino lleve un Id unico y sea mas facil de encontrarlo a la hora de buscarlo 
        private static int UltimoId =1 ;
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int CostoDiario { get; set; }
        public int CantidadDeDias { get; set; }
        public List<Excursion> ExcursionesDeEsteDestino = new List<Excursion>();
        
        //Generamos los constructores de la clase Destino sin y con parametros
        public Destino()
        {
        }

        public Destino(string ciudad, string pais, int costoDiario, int cantidadDeDias)
        {
            Id = UltimoId;
            UltimoId++;
            Ciudad = ciudad;
            Pais = pais;
            CostoDiario = costoDiario;
            CantidadDeDias = cantidadDeDias;
        }
        public override string ToString()
        {
            return $@"

-Id: {Id}                                                                                  
-Ciudad: {Ciudad}                                                                                                                              
-Pais: {Pais}
-Costo por dia: {CostoDiario}
-Cantidad de dias: {CantidadDeDias}
-Costo total del destino: {CostoEnDolares()} USD |o| {CostoEnPesos()}

";
        }
        public int CostoEnDolares()
        {
            return CostoDiario*CantidadDeDias;
        }
        public double CostoEnPesos()
        {
            double totalEnPesos;
            totalEnPesos =Convert.ToDouble(CantidadDeDias * CostoDiario);
            double cotizacion = a.GetCotizacion();
            totalEnPesos = totalEnPesos * cotizacion;
            return totalEnPesos;
        }
        public List<Excursion> AgregarExcursionDestinos(int id)
        {
          
            foreach (Excursion e in a.GetExcursiones()) {
                if (e.Id == id) {
                    ExcursionesDeEsteDestino.Add(e);
                   
                }
            }
           

            return ExcursionesDeEsteDestino;

        }

    }
}
