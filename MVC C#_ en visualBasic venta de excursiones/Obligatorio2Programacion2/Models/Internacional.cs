using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioProgramacion2
{
    //Generamos la clase Internacional Hija de la clase Excursion
    public class Internacional : Excursion
    {
        private readonly Agencia  a = Agencia.GetInstancia();
        //Creamos las propiedades de la clase Internacional
        public Compania CompaniaAerea { get; set; }
        public string ciudades;
    	public int totalDias;
       



        // Generamos el constructor de la clase Internacional con parametros  
        public Internacional( string descripcion, DateTime fechaComienzo, int cantDias, int lugaresDisponibles, Compania companiaAerea)
        {
            Id = UltimoId;
	        UltimoId = UltimoId+100;
            Taza = 1.1;
            Descripcion = descripcion;
            FechaComienzo = fechaComienzo;
            CantDias = cantDias;
            LugaresDisponibles = lugaresDisponibles;
            CompaniaAerea= companiaAerea;
            Tipo = "Internacional";
            
        }

        public Internacional()
        {
        }

     

        // Usamos los metodos heredados de la clase padre Excursion y los " sobreescribimos " con el atributo override
        public override List<Destino> AgregarDestinosExcursion(Destino d)
        {
            listaDestinosDeExcursion.Add(d);
            
                d.AgregarExcursionDestinos(Id);
               

            return listaDestinosDeExcursion;

        }
        public override string ToString()
        {
		ciudades = "";
            totalDias = CantDias;
            //recorremos los destinos de la excursion para saber por que ciudades pasa , concatenando las mismas en un string
            // y el acumulado de dias por destino 
            foreach (Destino d in listaDestinosDeExcursion)
            {
		totalDias = totalDias + d.CantidadDeDias ;
                ciudades = ciudades + d.Ciudad+"("+d.Pais+") , ";
            }
            // ya que el destino terminaria en " , " borramos los ultimos 3 caracteres del string para no mostrar de mas en pantalla
            ciudades = ciudades.Substring(0, ciudades.Length - 3);

            return $@"
Excursion

########################################################

-ID: {Id}
-Descripcion: {Descripcion}
-Fecha de Comienzo: {FechaComienzo}
-Lugares disponibles: {LugaresDisponibles}
-Cantidad de dias de traslado: {CantDias}
-Total de dias de la excurcion : {totalDias}
-Costo total de la excursion : {CalcularCostoDolares()} USD |o| {CalcularCostoPesos()} Pesos
-Compania Aerea: {CompaniaAerea.ToString()}
-Destinos: {ciudades}

";

        }
        //usamos el metodo heredado que sobreescribimos para calcular el costo en pesos de la excursion
        public override double CalcularCostoDolares()
        {
            //creamos una variable en donde vamos a guardar el acumulado de los destinos
            int costoDolares = 0;

            foreach (Destino d in listaDestinosDeExcursion)
            {
                //recorremos cada destino y multiplicamos el costo diario por la cantidad de dias 
                costoDolares = costoDolares + (d.CostoDiario * d.CantidadDeDias);

            }
            //devolvemos el costo total en dolares de la excursion
            return costoDolares;
        }
        //hacemos lo mismo que en el metodo anterior 
        public override double CalcularCostoPesos()
        {
            //creamos una variable en donde guardamos el acumulado en dolares
            int costoPesos = 0;
            double costoTotalPesos;
            foreach (Destino d in listaDestinosDeExcursion)
            {
                // calculamos el costo por destino multiplicando la cantidad de dias del mismo por el precio diario del mismo 
                costoPesos = costoPesos + (d.CostoDiario * d.CantidadDeDias);

            }
            //creamos una variable para importar la cotizacion de la clase Agencia( clase administradora)
            double cotizacion = a.GetCotizacion();

            //conevertimos el tipo de variable int en double para que no genere problemas entre las operaciones de variables 
            costoTotalPesos = Convert.ToDouble(costoPesos);
            costoTotalPesos = costoTotalPesos * cotizacion;
            //retornamos el costo total en pesos de la excursion
            return costoTotalPesos;
        }

        public override double obtenerDescuentoORecargo()
        {
            

            return Taza;
        }

    }
}
