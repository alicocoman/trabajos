using obligatorioProgramacion2;
using Obligatorio2Programacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio2Programacion2.Controllers
{
    public class CompraController : Controller
    {
        Agencia a = Agencia.GetInstancia();
        // GET: Compra
        public ActionResult Index()
        {
            if ((string)Session["logueadoRol"] == null)
            {
                ViewBag.MSG = "Para Ver sus compras inicie sesion";
                return View("../Home/Index");
            }
            // numero de cedula del usuario que es igual a su nombre de usuario 
            else
            {
                int Usuario = (int)Session["logueadoUsuario"];

                return View(a.GetComprasPorCliente(Usuario));
            }
        }

        //Metodo para cancelar compra 
        public ActionResult Cancelar(int id)
        {
            if ((string)Session["logeadoRol"] == "Cliente")
            {
                Compra c = a.GetComprasPorId(id);
                a.cancelarCompra(c.Id);

                ViewBag.Msg = "Compra Cancelada con exito";
                return View("../Home/Index");
            }
            else {
                ViewBag.Msg = "Usted no puede acceder a esta parte del sitio, para Acceder inicie sesion";
                return View("../Home/Index");
            }


        }

        //Get Compra Entre Dos Fechas
        public ActionResult ComprasEntreDosFechas()
        {
            
            if ((string)Session["logueadoRol"] == "Operador")
            {

                return View("ComprasEntreDosFechas");
            }
            else {
                ViewBag.Msg = "Usted no tiene autorizacion para ingresar a este sitio, ingrese como Operador";
                return View("../Home/Index");
            }

        }


        // Metodo para ver las compras entre dos fechas
        [HttpPost]
        public ActionResult ComprasEntreDosFechas(DateTime? FechaInicial, DateTime? FechaFinal)
        {

            DateTime FechaI;
            DateTime FechaF;
            double totalPesos = 0;
            double totalDolares = 0;

            if (FechaInicial != null)
            {
                FechaI = FechaInicial.Value;

            }
            else
            {
                FechaI = DateTime.Today;
            }
            if (FechaFinal != null)
            {
                FechaF = FechaFinal.Value;
            }
            else
            {
                FechaF = DateTime.Today;
            }

            foreach (Compra C in a.GetCEntreFechas(FechaI, FechaF))
            {

                totalPesos = C.costoTotalPesos + totalPesos;
                totalDolares = totalDolares + C.costoTotalDolares;


            }
            ViewBag.Pesos = totalPesos;
            ViewBag.Dolares = totalDolares;
            if (a.GetCEntreFechas(FechaI, FechaF).Count() == 0) {
                ViewBag.comprasFecha = "No hay compras entre esas dos fechas";
            }


            return View(a.GetCEntreFechas(FechaI, FechaF));
        }

    }
}
