using Obligatorio2Programacion2.Models;
using obligatorioProgramacion2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio2Programacion2.Controllers
{
    public class UsuarioController : Controller
    {
        Agencia a = Agencia.GetInstancia();
        // GET: Usuario
        public ActionResult Index()
        {
            if ((string)Session["logueadoRol"] == "Operador")
            {
                if (a.GetClientes().Count() == 0) {
                    ViewBag.noHayC = "No hay clientes";
                }

                return View(a.GetClientes());
            }
            else {
                ViewBag.Msg = "Ingrese como Operador Para Acceder a esta funcion";
                return View("../Home/Index");
            }

        }
        public ActionResult Registrarse()
        {
            return View();
        }

        // POST: Usuario/Registrarse
        [HttpPost]
        public ActionResult Registrarse(Usuario u)
        {

            try
            {
                Usuario Usu =  a.agregarCliente(u.Nombre, u.Apellido, u.Cedula, u.Password);
                a.agregarCliente(u.Nombre, u.Apellido, u.Cedula, u.Password);
                if (Usu != null)
                {
                    

                    ViewBag.Msg = "Bienvenido " + Usu.Nombre + " " + Usu.Apellido + " Inicie sesion para continuar";

                }
                else {
                    ViewBag.Msg = "No se pudo Registrar su usuario, verifique sus datos";
                }
                
                return View("../Home/Index");
                
            }
            catch
            {
                return View();
            }
        }

    }
}
