using Obligatorio2Programacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioProgramacion2
{
    //Creamos la clase administradora Agencia , la cual va a ser la encargada de " administrar" todas las clases del sistema
    public class Agencia
    {
        //SINGLETON
        //genero la instancia nula
        private static Agencia instancia = null;

        // si no existe una instancia va a crear una nueva y me la va a devolver ,
        // si ya existe una instancia me va a devolver la la ya existente
        public static Agencia GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Agencia();
            }
            return instancia;
        }
        //Creamos una variable booleana para saber si ya se precargaron los datos
        private bool Precargado { get; set; }
        //Creamos una variable privada del sistema para la cotizacion del dolar actual
        private double CotizacionDelDolar { get; set; }

        //Generamos las listas pertinentes para guardar los objetos en la clase sistema
        private List<Excursion> listaExcursiones = new List<Excursion>();
        private List<Compania> listaCompanias = new List<Compania>();
        private List<Destino> listaDestinos = new List<Destino>();
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private List<Compra> listaCompras = new List<Compra>();
        private List<Usuario> listaClientes = new List<Usuario>();


        //Generamos los metodos para poder acceder a las listas ( ya que se crean privadas para no modificarlas por accidente)
        public double GetCotizacion()
        {
            return CotizacionDelDolar;
        }
        public bool GetPrecarga() {
            return Precargado;
        }
        public List<Excursion> GetExcursiones()
        {
            listaExcursiones.Sort();
            return listaExcursiones;
        }
        public List<Compania> GetCompanias()
        {
            return listaCompanias;
        }
        public List<Destino> GetDestinos()
        {
            return listaDestinos;
        }
        public List<Usuario> GetUsuarios()
        {
              
            return listaUsuarios;
        }
        public List<Compra> GetCompras() {
            return listaCompras;
        }
        public List<Usuario> GetClientes() {
            listaClientes.Sort();
            return listaClientes;
        }


        //Generamos los metodos para agreger los objetos a las listas creadas anteriormente

        //AGREGAR NACIONAL
        public Excursion AgregarNacional(string descripcion, DateTime fechaComienzo, int cantDias, int lugaresDisponibles, bool interesNacional, double taza)
        {

            Excursion nuevo = new Nacional(descripcion, fechaComienzo, cantDias, lugaresDisponibles, interesNacional, taza);
            listaExcursiones.Add(nuevo);
            

            return nuevo;
        }

        //AGREGAR INTERNACIONAL

        public Excursion AgregarInternacional(string descripcion, DateTime fechaComienzo, int cantDias, int lugaresDisponibles, Compania companiaAerea)
        {
            bool companiaExiste = false;
            bool desBien = false;
            bool diasBien = false;
            bool lugaresBien = false;
            if (descripcion.Length >= 3)
            {
                desBien = true;
            }
            if (cantDias > 0)
            {
                diasBien = true;
            }
            if (lugaresDisponibles > 0)
            {
                lugaresBien = true;
            }
            foreach (Compania c in listaCompanias)
            {
                if (companiaAerea == c)
                {
                    companiaExiste = true;
                }
            }
            if (companiaExiste && desBien && diasBien && lugaresBien) {
                Excursion nuevo = new Internacional(descripcion, fechaComienzo, cantDias, lugaresDisponibles, companiaAerea);
                listaExcursiones.Add(nuevo);
                return nuevo;
            }
            else
            {
                return null;
            }
        }

        //AGREGAR DESTINO
        public Destino AgregarDestino(string ciudad, string pais, int costoDiario, int cantidadDeDias) {

            Destino nuevo = new Destino(ciudad, pais, costoDiario, cantidadDeDias);
            listaDestinos.Add(nuevo);
            return nuevo;

        }

        //AGREGAR COMPANIA
        public Compania AgregarCompania(int codigo, string pais)
        {

            Compania nuevo = new Compania(codigo, pais);
            listaCompanias.Add(nuevo);
            return nuevo;

        }

        //AGREGAR COMPRA
        public Compra AgregarCompra(Usuario c, Excursion e, int mayores, int menores) {
            int totalPasajeros;
            double totalPesos;
            totalPasajeros = mayores + menores;

            totalPesos = e.CalcularCostoPesos() * totalPasajeros;
            totalPesos = totalPesos * e.obtenerDescuentoORecargo();

            double totalDolares;

            totalDolares = e.CalcularCostoDolares() * totalPasajeros;
            totalDolares = totalDolares * e.obtenerDescuentoORecargo();
            double pasajeroPesos = e.CalcularCostoPesos();
            double pasajeroDolares = e.CalcularCostoDolares();
            double descAutPesos;
            double descAutDolares;
            descAutDolares = totalDolares - (e.CalcularCostoDolares() * totalPasajeros);
            descAutPesos =  totalPesos -(e.CalcularCostoPesos()*totalPasajeros);

            Compra nuevaCompra = new Compra(c, e, mayores, menores, totalPesos, totalDolares,pasajeroPesos,pasajeroDolares, descAutPesos, descAutDolares);
            listaCompras.Add(nuevaCompra);
            RestarLugaresPorId(e.Id, menores + mayores);
            return nuevaCompra;

        }

        //Generamos un metodo para cambiar la cotizacion del dolar en el sistema
        public double CambiarCotizacionDelDolar(double nuevaCotizacion)
        {
            CotizacionDelDolar = nuevaCotizacion;

            return CotizacionDelDolar;
        }
        //Cambiamos la variable Precarga de false a true

        public void CambiarPrecarga()
        {
            Precargado = true;


        }

        //Metodo que recorre todas las excursiones del sistema y las muestra por pantalla con todos sus datos 
        public string MostrarExcursiones()
        {
            foreach (Excursion ex in listaExcursiones)
            {
                Console.WriteLine(ex.ToString());
            }
            return "=====================";
        }
        //Metodo que recorre todos los destinos del sistema y las muestra por pantalla con todos sus datos 
        public string MostrarDestinos()
        {
            foreach (Destino de in listaDestinos)
            {
                Console.WriteLine(de.ToString());
            }
            return "=====================";
        }


        //metodo que recorre las excursiones para saber si estan dentro de las fechas indicadas y van a un destino indicado

        // recibe el id del destino , la fecha de inicio y finalizacion de la excursion
        public List<Excursion> GetExcursionEntreFechas(int idDestino, DateTime fechaInicio, DateTime fechaFinal)
        {
            //creamos una lista retorno para devolver las excursiones que estan dentro de las fechas ingresadas
            List<Excursion> retorno = new List<Excursion>();
            //recorremos la lista de Excursiones

            foreach (Excursion e in listaExcursiones)
            {
                foreach (Destino D in e.GetlistaDestinosDeExcursion())
                    // si el id del destino y el rango de fechas concuerda con alguna excursion , se guarda esa excursion en la lista retorno
                    if ((D.Id == idDestino) && (e.FechaComienzo >= fechaInicio) && (e.FechaComienzo <= fechaFinal))
                    {
                        retorno.Add(e);
                    }


            }
            //se devuelve la lista con las excursiones encontradas
            return retorno;
        }
        // GET DE COMPRAS POR ID USUARIO 
        public List<Compra> GetComprasPorCliente(int usuario) {
            List<Compra> comprasDeCliente = new List<Compra>();

            foreach (Compra c in listaCompras) {
                if (c.Comprador.NombreUsu == usuario && c.activa) {

                    comprasDeCliente.Add(c);
                }
            }



            return comprasDeCliente;
        }

        //Agregar un Cliente a al Sistema
        public Usuario agregarCliente(string nombre, string apellido, int cedula, string password)
        {
            bool nombreCheck = false;
            bool apellidoCheck = false;
            bool cedulaCheckLargo = false;
            bool cedulaCheckNoExiste = true;
            bool cedulaCheck = false;
            bool passwordCheckLargo = false;
            bool passwordCheckMayuscula = password.Any(c => char.IsUpper(c)); ;
            bool passwordCheckMinuscula = password.Any(c => char.IsLower(c));
            bool passwordCheckNumero = password.Any(c => char.IsDigit(c)); ;
            bool passwordCheck = false;
            if (nombre.Length > 2)
            {

                nombreCheck = true;
            }
            if (apellido.Length > 2)
            {

                apellidoCheck = true;
            }
            if (cedula > 99999 && cedula < 1000000000)
            {
                cedulaCheckLargo = true;
            }
            foreach (Usuario u in listaUsuarios)
            {
                if (u.Cedula == cedula)
                {
                    cedulaCheckNoExiste = false;
                }
            }
            if (cedulaCheckNoExiste && cedulaCheckLargo)
            {
                cedulaCheck = true;
            }
            if (password.Length > 5)
            {
                passwordCheckLargo = true;
            }
            if (passwordCheckLargo && passwordCheckMayuscula && passwordCheckMinuscula && passwordCheckNumero)
            {
                passwordCheck = true;
            }

            if (passwordCheck && nombreCheck && apellidoCheck && cedulaCheck)
            {
                string Nombre = nombre.Substring(0, 1).ToUpper() + nombre.Substring(1);
                string Apellido = apellido.Substring(0, 1).ToUpper() + apellido.Substring(1);
                Usuario Cliente = new Usuario(Nombre, Apellido, cedula, password);
                listaUsuarios.Add(Cliente);
                listaClientes.Add(Cliente);
               
                return Cliente;
            }
            else { 
            
           
            return null;
        }
            
        }

        //Agregar un Operador Al sistema
        public Usuario agregarOperador(int nombreUsu, string password) {
            Usuario Operador = new Usuario(nombreUsu, password);
            listaUsuarios.Add(Operador);
            return Operador;

        }


        //PRECARGA DE DATOS

        public void PrecargaDeDatos() {

            //Precarga de Destinos
            Destino d1 = AgregarDestino("MONTEVIDEO", "URUGUAY", 80, 3);
            Destino d2 = AgregarDestino("RIO DE JANEIRO", "BRASIL", 110, 7);
            Destino d3 = AgregarDestino("AMSTERDAM", "HOLANDA", 95, 4);
            Destino d4 = AgregarDestino("MOSCU", "RUSIA", 65, 6);
            Destino d5 = AgregarDestino("QUITO", "ECUADOR", 55, 5);
            Destino d6 = AgregarDestino("SAN JOSE", "URUGUAY", 45, 3);
            Destino d7 = AgregarDestino("RIO BRANCO", "URUGUAY", 44, 8);
            Destino d8 = AgregarDestino("BEIGIN", "CHINA", 70, 12);
            Destino d9 = AgregarDestino("NEW YORK", "ESTADOS UNIDOS", 120, 7);
            Destino d10 = AgregarDestino("ARTIGAS", "URUGUAY", 36, 6);


            //Precarga de Companiasy y
            Compania c1 = AgregarCompania(123, "Uruguay");
            Compania c2 = AgregarCompania(234, "Brazil");
            Compania c3 = AgregarCompania(345, "EE.UU");
            Compania c4 = AgregarCompania(456, "Rusia");

            //Precarga de Excursiones
            Excursion e1 = AgregarNacional("Estadia de 3 noches en Montevideo y 3 noches en San Jose", DateTime.Parse("2020-12-24"), 6, 100, true, 0.1);
            e1.AgregarDestinosExcursion(d1);
            e1.AgregarDestinosExcursion(d6);
            Excursion e2 = AgregarNacional("Estadia de 3 noches en Montevideo y 8 noches en Rio Branco", DateTime.Parse("2021-01-03"), 11, 1222, false, 0.2);
            e2.AgregarDestinosExcursion(d1);
            e2.AgregarDestinosExcursion(d7);
            Excursion e3 = AgregarNacional("Estadia de 3 noches en Montevideo y 6 noches en Artigas", DateTime.Parse("2021-05-03"), 9, 300, true, 0.15);
            e3.AgregarDestinosExcursion(d1);
            e3.AgregarDestinosExcursion(d10);
            Excursion e4 = AgregarNacional("Estadia de 3 noches en San Jose y 6 noches en Artigas", DateTime.Parse("2020-12-29"), 9, 300, false, 0.25);
            e4.AgregarDestinosExcursion(d6);
            e4.AgregarDestinosExcursion(d10);
            Excursion e5 = AgregarInternacional("Estadia de 3 noches en Montevideo y 6 noches en Moscu", DateTime.Parse("2021-03-10"), 9, 300, c1);
            e5.AgregarDestinosExcursion(d1);
            e5.AgregarDestinosExcursion(d4);
            Excursion e6 = AgregarInternacional("Estadia de 8 noches en Rio de Janeiro y 6 noches en Moscu", DateTime.Parse("2021-01-30"), 14, 200, c2);
            e6.AgregarDestinosExcursion(d7);
            e6.AgregarDestinosExcursion(d4);
            Excursion e7 = AgregarInternacional("Estadia de 3 noches en Montevideo y 7 noches en New York", DateTime.Parse("2021-01-15"), 10, 150, c3);
            e7.AgregarDestinosExcursion(d1);
            e7.AgregarDestinosExcursion(d9);
            Excursion e8 = AgregarInternacional("Estadia de 12 noches en Berlin y 6 noches en Moscu", DateTime.Parse("2020-12-30"), 18, 300, c4);
            e8.AgregarDestinosExcursion(d8);
            e8.AgregarDestinosExcursion(d4);
            CotizacionDelDolar = 42.78;

            Usuario o1 = agregarOperador(1212121, "Op123");
            Usuario o2 = agregarOperador(2323232, "oP123");
            Usuario cl1 = agregarCliente("Juan", "Perez", 1231231, "Jp1234");
            Usuario cl2 = agregarCliente("Diego", "Peras", 1234568, "Dt1234");
            Usuario cl3 = agregarCliente("Carlos", "Perez", 1234569, "Cp1234");
            Usuario cl4 = agregarCliente("Carlos", "Perex", 1234566, "cP1234");


            Compra co1 = AgregarCompra(cl1, e4, 2, 2);
            co1.FechaCompra = DateTime.Parse("2020-10-29");
            Compra co2 = AgregarCompra(cl1, e5, 2, 2);
            co2.FechaCompra = DateTime.Parse("2020-09-29");
            Compra co3 = AgregarCompra(cl1, e3, 2, 2);
            co3.FechaCompra = DateTime.Parse("2020-11-23");
            Compra co4 = AgregarCompra(cl2, e8, 3, 2);
            co4.FechaCompra = DateTime.Parse("2020-07-26");
            Compra co5 = AgregarCompra(cl3, e5, 3, 2);
            co5.FechaCompra = DateTime.Parse("2020-08-12");
            Compra co6 = AgregarCompra(cl4, e6, 3, 2);

            Precargado = false;
        }

        // CONVERTIR INTERNACIONAL DE EXCURSION A INTERNACIONAL 
        public Internacional castInternacional(Excursion e) {

            Internacional nuevo = (Internacional)e;

            return nuevo;
        }

        // CONVERTIR NACIONAL DE EXCURSION A NACIONAL
        public Nacional castNacional(Excursion e) {

            Nacional nuevo = (Nacional)e;
            return nuevo;
        }

        // ENCONTRAR EXCURSION POR ID DE EXCURSION
        public Excursion GetExcursionPorId(int id) {
            Excursion nueva;

            foreach (Excursion e in listaExcursiones) {
                if (e.Id == id) {
                    nueva = e;
                    return nueva;
                }
            }

            return null;

        }

        // ENCONTRRAR USUARIO POR NOMBRE DE USUARIO 
        public Usuario GetUsuarioPorNombreUsu(int id) {
            foreach (Usuario u in listaUsuarios) {
                if (u.NombreUsu == id)
                { return u;

                }

            }
            return null;
        }

        // BAJAR STOCK DE UNA EXCURSION DADO SU ID Y LA CANTIDAD DE STOCK
        public void RestarLugaresPorId(int id, int cantidad) {
            Excursion e = GetExcursionPorId(id);
            e.LugaresDisponibles = e.LugaresDisponibles - cantidad;

        }

        //AGREGAR STOCK A UNA EXCURSION DADO SU ID Y LA CANTIDAD DE STOCK
        public void SumarLugaresPorId(int id, int cantidad)
        {
            Excursion e = GetExcursionPorId(id);
            e.LugaresDisponibles = e.LugaresDisponibles + cantidad;

        }

        //ENCONTRAR COMPRA DADO UN ID
        public Compra GetComprasPorId(int id) {
            foreach (Compra c in listaCompras) {
                if (c.Id == id) {
                    return c;


                }

            }
            return null;

        }

        // CANCELAR COMPRA DADO UN ID
        public void cancelarCompra(int id) {
            Compra c = GetComprasPorId(id);
            c.activa = false;
            int totalLugares = c.CantidadPersonasMayores + c.CantidadPersonasMenores;
            SumarLugaresPorId(c.ExcursionComprada.Id, totalLugares);

        }

        // ENCONTRAR TODAS LAS COMPRAS QUE NO FUERON CANCELADAS
        public List<Compra> GetComprasActivas() {
            List<Compra> comprasActivas = new List<Compra>();
            foreach (Compra c in listaCompras) {
                if (c.activa == true)
                {
                    comprasActivas.Add(c);
                }
            }

            return comprasActivas;
        }
        //ENCONTRAR UNA COMPRA ENTRE DOS FECHAS
        public List<Compra> GetCEntreFechas(DateTime fechaI, DateTime fechaF) {

            List<Compra> comprasEntreFechas = new List<Compra>();
            foreach (Compra c in listaCompras)
            {
                if (c.FechaCompra>fechaI && c.FechaCompra<fechaF)
                {
                    comprasEntreFechas.Add(c);
                }
            }

            return comprasEntreFechas;
        }

        //OBTENER LOS DESTINOS MAS USADOS

        public List<Destino> GetDestinoMasUsado() {
            List<Destino> destinosMasUsados = new List<Destino>();
            int mayorCantDestinos = int.MinValue;
            foreach (Destino d in listaDestinos) {
                bool vuelta = false;
                    if (d.ExcursionesDeEsteDestino.Count > mayorCantDestinos) {
                        destinosMasUsados.Clear();
                        destinosMasUsados.Add(d);
                        mayorCantDestinos = d.ExcursionesDeEsteDestino.Count;
                         vuelta = true;

                    }
                    if (d.ExcursionesDeEsteDestino.Count == mayorCantDestinos && vuelta==false ) {

                    destinosMasUsados.Add(d);
                    }

            }
            

            return destinosMasUsados ;
            ;
        }


        //OBTENER UNA EXCURSION DADO UN DESTINO

        public List<Excursion> GetExcursionesPorDestino(int id) {
            List<Excursion> excursionesPorDestino = new List<Excursion>();

            foreach (Excursion e in listaExcursiones) {
                foreach (Destino de in e.GetlistaDestinosDeExcursion()) {
                    if (de.Id == id) {

                        excursionesPorDestino.Add(e);
                    }
                }
            }
            return excursionesPorDestino;

        }

    }
  }




       
    


