using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Repositorios.UtilidadBd;
using Repositorios.Context;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesNegocio;
using System.Data.Entity;

namespace Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        /*Pronto*/
        public bool Add(Usuario usu)
        {
            if (usu != null && usu.Validar())
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                   
                        if (db.Usuarios.Find(usu.Cedula)==null)
                        {
                            string PassEncriptada = Encriptar.GetSHA256(usu.Password);
                            usu.Password = PassEncriptada;
                            db.Usuarios.Add(usu);
                            db.SaveChanges();
                            return true;
                        }
                        else { return false; }
                    }
                }
                catch { return false; }
            }
            else { return false; }
        }
        /*No se usa*/
        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }
        // mirar ala busqueda de usuario 
        /*Pronto*/
        public Usuario FindByCedula(string cedula)
        {
            if (cedula != null)
            {
                try
                {
                    using (ObliContext db = new ObliContext())
                    {
                        var usuBuscado = db.Usuarios.Where(c => c.Cedula == cedula);
                        if (usuBuscado.Count() == 1)
                        {
                            Usuario unUsu = usuBuscado.ToList()[0];
                            return unUsu;
                        }
                        else { return null; }
                    }

                }
                catch { return null; }
            }
            else { return null; }
        }
        /*No se usa*/
        public bool Remove(Usuario usu)
        {
            throw new NotImplementedException();
        }
        /*No se usa*/
        public bool Update(Usuario usu)
        {
            if (FindByCedula(usu.Cedula) != null &&usu.Validar())
            {
               
                    string PassEncriptada = Encriptar.GetSHA256(usu.Password);
                    try
                    {
                        using (ObliContext db = new ObliContext())
                        {
                            usu.Password = PassEncriptada;
                            db.Usuarios.Attach(usu);
                            db.Entry(usu).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            return true;


                        }
                    }
                    catch { return false; }
               }
            return false;
        }
    }
}

