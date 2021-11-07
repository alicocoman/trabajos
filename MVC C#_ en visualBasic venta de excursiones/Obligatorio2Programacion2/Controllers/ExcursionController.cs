using obligatorioProgramacion2;
using Obligatorio2Programacion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio2Programacion2.Controllers
{
    public class ExcursionController : Controller
    {
        Agencia a = Agencia.GetInstancia();
        // GET: Excursion
        public ActionResult Index()
        {
            if (a.GetExcursiones().Count() == 0) {
                ViewBag.noHay = "No hay excursiones para mostrar";
            }
            return View(a.GetExcursiones());
            
        }

        public ActionResult VerExcursiones()
        {
            ViewBag.Message = "Excursiones Disponibles";

            return View("../Excursion/Index");
        }


        // mostrar los detalles de la compra al cliente y ofrecer comprarlo 
        // GET: Excursion/Comprar/5
        public ActionResult ComprarExcursion(int id)
        {
            if ((string)Session["logueadoRol"] == "Cliente")
            {
                Session["idExcursion"] = id;

                Excursion buscada = a.GetExcursionPorId(id);
                ViewBag.Nacional = null;
                ViewBag.Internacional = null;

                if (buscada.Tipo == "Nacional")
                {
                    Nacional n = a.castNacional(buscada);
                    if (n.InteresNacional)
                    {
                        ViewBag.Nacional = "Es de interes nacional";
                    }
                    else
                    {
                        ViewBag.Nacional = "No es de interes nacional";
                    }


                }
                else
                {
                    Internacional i = a.castInternacional(buscada);
                    ViewBag.Internacional = i.CompaniaAerea;
                }
                ViewBag.ExcursionBuscada = buscada;



                return View("../Excursion/ComprarExcursion");
            }
            else {
                ViewBag.MSG = "Para comprar excursiones debe estar ingresado como cliente";
                return View("../Home/Index");
            }

        }
        // comprar una Excursion

        [HttpPost]
        public ActionResult ComprarExcursion( int Mayores, int Menores)
        {
            try
            {
                Usuario u = a.GetUsuarioPorNombreUsu((int)Session["logueadoUsuario"]);
                int totalPasajeros;
                bool hayLugar = false;
                totalPasajeros = Mayores + Menores;

                Excursion e = a.GetExcursionPorId((int) Session["idExcursion"]);

                if (e.LugaresDisponibles >= totalPasajeros) {
                    hayLugar = true;
                }
                
             
                if (hayLugar == true)
                {
                    a.AgregarCompra(u, e, Mayores, Menores);
                   
                    ViewBag.Msg = "Compra realizada con exito";
                }
                else {
                    ViewBag.Msg = "No se pudo realizar su compra Sr. " + Session["logueadoNombre"];
                }


                

                return View("../Home/Index");
            }
            catch {
                return View();
            }
        }


        //Get de la vista de Estadisticas
        public ActionResult Estadisticas()
        {
            if ((string)Session["logueadoRol"] == "Operador")
            {
                ViewBag.TipoBusqueda = "@model obligatorioProgramacion2.Excursion";
                return View();
            }
            else {
                ViewBag.MSG = "Usted no tiene autorizacion para entrar en esta pagina, ingrese session como Operador";
                return View("../Home/Index");
            }
        }

        //Metodos para el boton buscar por destino y buscar el destino mas usado
        [HttpPost]
        public ActionResult Estadisticas(int? Destino,int? boton) {
           
            bool destinoExiste = false;
            int DestinoBuscado=0;
            if (Destino != null)
            {
                DestinoBuscado = Convert.ToInt32(Destino);

                foreach (Destino d in a.GetDestinos())
                {
                    if (d.Id == Destino)
                    { 
                        destinoExiste = true;
                    }

                }
                if (a.GetExcursionesPorDestino(DestinoBuscado).Count() == 0) {
                        ViewBag.noHayD = "No hay Resulatdos";
                    }
                if (destinoExiste == true) { 
                        ViewBag.TipoBusqueda = "Excursion";
                    ViewBag.Excursion = a.GetExcursionesPorDestino(DestinoBuscado);
                    

                return View();
            }
                }
            if(boton == 1)
            {
                ViewBag.TipoBusqueda = "Destino";
               ViewBag.Destinos = a.GetDestinoMasUsado();
                if (a.GetDestinoMasUsado().Count() == 0) {
                    ViewBag.noHayD = "No hay Resulatdos";
                }
                    return View();

            }
            


            return View();



          
        }

    }


}
