using Obligatorio2Programacion2.Models;
using obligatorioProgramacion2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio2Programacion2.Controllers
{
    public class HomeController : Controller
    {
        Agencia a = Agencia.GetInstancia();

            public ActionResult Index()
            {
            
            if (a.GetPrecarga() == false)
            {
                a.PrecargaDeDatos();
                a.CambiarPrecarga();

            }
        
            if (Session["logueadoRol"] != null)
            {
                if ((string)Session["logueadoRol"] == "Operador")
                {
                    ViewBag.Msg = "Bienvenido Operador";

                }
                if ((string)Session["logueadoRol"] == "Cliente") {
                    ViewBag.Msg = "Bienvenid@ "+ Session["logueadoNombre"] + " " + Session["logueadoApellido"];
                }


            }
            else {
                ViewBag.Msg = "Inicie sesion para entrar en agencia";
            }
            return View("Index");
            
            }

       

        public ActionResult Registrarse()
        {
          //  ViewBag.Message = "Your contact page.";

            return View("../Usuario/Registrarse");
        }

        public ActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel L )
        {
            foreach (Usuario u in a.GetUsuarios())
            {
                if (u.NombreUsu == L.Usuario && u.Password == L.Password) {
                    Session["logueadoRol"] =u.Rol;

                    if (u.Rol == "Cliente") {
                        Session["logueadoNombre"] = u.Nombre;
                        Session["logueadoApellido"] = u.Apellido;
                        Session["logueadoUsuario"] = u.NombreUsu;
                    }
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            Session["logueadoRol"] = null;
            Session["logueadoNombre"] = null;
            Session["logueadoApellido"] = null;
            Session["logueadoUsuario"] = null;
            ViewBag.Msg = "Bienvenido futuro cliente";
            return View("Index");
        }


    }
}