using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Archvos.UtilidadBd;

namespace Archvos
{
    internal class Manejo
    {
        private static string ArchivoUsu = AppDomain.CurrentDomain.BaseDirectory + "\\UsuariosGuardados.txt";
        private const int cantidadAtributosUsu = 2;

        private static Usuario LeerTextoUsu(string dato, string delimitador)
        {
            //Cramos un sub string para saber que dia de la semana es para imprimir al final de la contraseña
            string diaSemana = "";
            DateTime numerodia= DateTime.Today;
           byte dia = (byte)numerodia.DayOfWeek;
            
            if (dia == 0) {
                diaSemana = "Dom";
            }
            if (dia == 1) {
                diaSemana = "Lun";

            }
            if (dia == 2) {
                diaSemana = "Mar";

            }
            if (dia == 3) {
                diaSemana = "Mie";

            }
            if (dia == 4) {
                diaSemana = "Jue";

            }
            if (dia == 5) {
                diaSemana = "Vie";
            }
            if (dia == 6) {
                diaSemana = "Sab";
            }


            string[] fila = dato.Split(delimitador.ToCharArray());
            if (fila.Length == cantidadAtributosUsu)

            {
                return new Usuario
                {
                    //Nos quedamos solo con la cedula ya que la contraseña nueva es generada por el sistema             
                    Cedula = fila[0],
                    //Generamos contraseña a partire de la cedula y el dia de la semana
                    Password = fila[0].Substring(0,4 ) + "-" + diaSemana,
                    PrimeraVes = true
                   
                };
            }
            else
                return null;
        }

        public static List<Usuario> crearListaUsu()
        {
            List<Usuario> retorno = new List<Usuario>();
            using (StreamReader sr = File.OpenText(ArchivoUsu))
            {
                string linea = sr.ReadLine();
                while ((linea != null))
                {
                    Usuario unUsu = LeerTextoUsu(linea, "|");
                    if (linea.IndexOf("|") > 0)
                    {
                        if (!retorno.Contains(unUsu) )
                        {
                            retorno.Add(unUsu);
                        }

                    }
                    linea = sr.ReadLine();
                }

            }
            return retorno;

        }


        //Leer laboratorios
        private static string ArchivoLab = AppDomain.CurrentDomain.BaseDirectory + "\\LaboratoriosGuardados.txt";
        private const int cantidadAtributosLab = 4;

        private static Laboratorio LeerLab(string dato, string delimitador)
        {


            string[] fila = dato.Split(delimitador.ToCharArray());


            if (fila.Length == cantidadAtributosLab) 

            {
                return new Laboratorio
                {

                    Id = Int32.Parse(fila[0].ToString()),
                    Nombre = fila[1].ToString(),
                    PaisDeOrigen = fila[3].ToString(),
                    ExpEnFabricacionDeVacunas = Convert.ToBoolean(fila[2]),
                    
                };
            }
            else
                return null;
        }

        public static List<Laboratorio> crearListaLab()
        {
            List<Laboratorio> retorno = new List<Laboratorio>();
            using (StreamReader sr = File.OpenText(ArchivoLab))
            {
                string linea = sr.ReadLine();
                while ((linea != null))
                {
                    Laboratorio unLab = LeerLab(linea, "|");
                    if (linea.IndexOf("|") > 0)
                    {
                        if (!retorno.Contains(unLab))
                        {
                            retorno.Add(unLab);
                        }

                    }
                    linea = sr.ReadLine();
                }

            }
            return retorno;

        }
        //Leer Tipos de vacuna

        private static string ArchivoTiposVacuna = AppDomain.CurrentDomain.BaseDirectory + "\\TipoVacunasGuardados.txt";
        private const int cantidadAtributosTVac = 3;

        private static TipoVacuna LeerTVac(string dato, string delimitador)
        {


            string[] fila = dato.Split(delimitador.ToCharArray());


            if (fila.Length == cantidadAtributosTVac) 

            {
                return new TipoVacuna
                {
                    Id = Int32.Parse(fila[0].ToString()),
                    Tipo = fila[1].ToString(),
                    Descripcion =fila[2].ToString()
                    

                };
            }
            else
                return null;
        }

        public static List<TipoVacuna> crearListaTVac()
        {
            List<TipoVacuna> retorno = new List<TipoVacuna>();
            using (StreamReader sr = File.OpenText(ArchivoTiposVacuna))
            {
                string linea = sr.ReadLine();
                while ((linea != null))
                {
                    TipoVacuna unTipoVac = LeerTVac(linea, "|");
                    if (linea.IndexOf("|") > 0)
                    {
                        if (!retorno.Contains(unTipoVac))
                        {
                            retorno.Add(unTipoVac);
                        }

                    }
                    linea = sr.ReadLine();
                }

            }
            return retorno;

        }

        //Leer Vacunas

        private static string ArchivoVacuna = AppDomain.CurrentDomain.BaseDirectory + "\\VacunasGuardadas.txt";
        private const int cantidadAtributosVacunas= 20;

        private static Vacuna LeerVacuna(string dato, string delimitador)
        {


            string[] fila = dato.Split(delimitador.ToCharArray());
            List<TipoVacuna> losTipos = crearListaTVac();
            TipoVacuna unTipo = new TipoVacuna();
            foreach (TipoVacuna t in losTipos)
            {
                if (t.Id == Int32.Parse(fila[19]))
                {
                    unTipo = t;
                }
            }
            if (fila.Length == cantidadAtributosVacunas) 

            {
                return new Vacuna
                {
                    Nombre = fila[0].ToString(),
                    CantDosis = Int32.Parse(fila[1].ToString()),
                 DiasEntreDosis = Int32.Parse(fila[2].ToString()),
                  EdadMinima = Int32.Parse(fila[3].ToString()),
                    EdadMaxima = Int32.Parse(fila[4].ToString()),
                    EficaciaVsCovid = Decimal.Parse(fila[7].ToString()),
                    PrevenirHospitalizacion=Decimal.Parse(fila[8].ToString()),
                    PrevenirCTI= Int32.Parse(fila[9].ToString()),
                    TempMinima = Int32.Parse(fila[5].ToString()),
                    TempMaxima = Int32.Parse(fila[6].ToString()),
                    FaseClinicaAprobacion = Int32.Parse(fila[10].ToString()),
                    AprovacionDeEmergencia = Convert.ToBoolean(fila[11].ToString()),
                    Precio = Decimal.Parse(fila[12].ToString()),
                     EfectosAdversos = fila[13].ToString(),
                    ProduccionAnual = Int32.Parse(fila[14].ToString()),
                    CedulaRegistrador= fila[15].ToString(), 
                     FormaParteCovax = Convert.ToBoolean(fila[16].ToString()),
                    FechaUltimaEdicion = DateTime.Parse(fila[17].ToString()),
                    PaisesQueAprobaronLaVacuna= fila[18].ToString(),
                    IdTipoDeVacuna = unTipo.Id,
                   TipoDeVacuna = unTipo,
                    Laboratorios = LeerVacunasXLab(fila[0].ToString())

                };
            }
            else
                return null;
        }

        public static List<Vacuna> crearListaVac()
        {
            List<Vacuna> retorno = new List<Vacuna>();
            using (StreamReader sr = File.OpenText(ArchivoVacuna))
            {
                string linea = sr.ReadLine();
              
                while ((linea != null) && linea != "")
                {
                   
                    if (linea.IndexOf("|") > 0)
                    {
                        
                         Vacuna unaVac = LeerVacuna(linea, "|");
                        retorno.Add(unaVac);
                       if (!retorno.Contains(unaVac) && unaVac.Validar())
                        {
                       retorno.Add(unaVac);
                         }

                    }
                    linea = sr.ReadLine();
                }

            }
            return retorno;

        }

        private static string ArchivoVacXLab = AppDomain.CurrentDomain.BaseDirectory + "\\Vacunas_Laboratorios.txt";




        public static ICollection<Laboratorio> LeerVacunasXLab(string unNombreVacuna)
        {
            List<Laboratorio> listaLaboratorios = crearListaLab();
            List<Laboratorio> LabXVac = new List<Laboratorio>();
            using (StreamReader sr = File.OpenText(ArchivoVacXLab))
            {
                string linea = sr.ReadLine();
                string delimitador = "|";
                while ((linea != null) && linea != "")
                {
                    string[] vecDatos = linea.Split(delimitador.ToCharArray());
                    
                    if (unNombreVacuna.Equals(vecDatos[0].ToString()))
                    {
                        foreach (Laboratorio lab in listaLaboratorios)
                        {
                            if (lab.Id == Int32.Parse(vecDatos[1].ToString()))
                            {
                                LabXVac.Add(lab);
                            }
                        }

                    }

                    linea = sr.ReadLine();
                }
            }
            return LabXVac;

        }



    }
}
