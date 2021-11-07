using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio2Programacion2.Models
{
    public class Usuario: IComparable<Usuario>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        public int NombreUsu { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }


        public Usuario(string nombre, string apellido, int cedula, string password) {
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NombreUsu = cedula;
            Password = password;
            Rol = "Cliente";


        }
        public Usuario() { }

        public Usuario(int nombreUsu, string password) {
            NombreUsu = nombreUsu;
            Password = password;
            Rol = "Operador";

        }

       
       public int CompareTo(Usuario other)
       {
          if (this.Apellido.CompareTo(other.Apellido) > 0) {
              return 1;
            }
            else if (this.Apellido.CompareTo(other.Apellido) < 0) {
               return -1;
            }
           else {
               
                   if (this.Nombre.CompareTo(other.Nombre) > 0) {
                    return 1; }
                    else if (this.Nombre.CompareTo(other.Nombre) < 0) {
                   return -1; }
                    else {
                    return 0;
                }
              

            }
        }

    }

}