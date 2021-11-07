using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dominio.EntidadesNegocio;
using Repositorios;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        RepositorioUsuario repoUsu = new RepositorioUsuario();
        public ActionResult LogIn()
        {
            return View("LogIn");

        }
        [HttpPost]
        public ActionResult LogIn(Models.LogIn logIn)
        {
            Usuario unUsu = repoUsu.FindByCedula(logIn.Cedula);
            string pass = unUsu.Password;
            string encriptada = Encriptar.GetSHA256(logIn.Password);
            if (pass == encriptada)
            {  Session["Cedula"] = logIn.Cedula;
                if (unUsu.PrimeraVes)
                {
                   
                    return View("ConfirmaPassword");
                }
                else
                {
                    return View("../Home/Index");
                }

            }
            return View("../Home/Index");

        }
        public ActionResult ConfirmaPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmaPassword(Models.ModeloPassword pass)
        {
            
            string cedula = (string)Session["Cedula"];
            Usuario unUsu = repoUsu.FindByCedula(cedula);
            string encriptada = Encriptar.GetSHA256(pass.Pass1);
            Usuario usu = new Usuario
            {
                Cedula = cedula,
                Password = pass.Pass1,
                PrimeraVes = false,
                
            };
            bool ok = repoUsu.Update(usu);
            if (ok)
            {
                return View("../Home/Index");
            }
            else {
                Session["Cedula"] = "";
                    return View("../Home/Index");
            }
                
        }

        public ActionResult LogOut()
        {
            Session["Cedula"] = null;
            return View("LogIn");

        }



    }
}
