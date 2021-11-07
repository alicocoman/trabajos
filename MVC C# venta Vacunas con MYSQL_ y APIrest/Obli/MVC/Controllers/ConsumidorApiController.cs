using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Dominio.EntidadesNegocio;
using MVC.Models;
using System.Net;


namespace MVC.Controllers
{
    public class ConsumidorApiController : Controller
    {
        HttpClient cliente = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();
        Uri productoUri = null;

        public ConsumidorApiController()
        {
            cliente.BaseAddress = new Uri("http://localhost:64769/");
            productoUri = new Uri("http://localhost:64769/api/VacunasApi");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult FindAll()
        {
            response = cliente.GetAsync(productoUri + "/TodasLasVacunas").Result;
            if (response.IsSuccessStatusCode)
            {
                var vacunas = response.Content.ReadAsAsync<IEnumerable<ModeloVacEntero>>().Result;
                return View(vacunas);
            }
            else
            {
                ViewBag.ResultadoOperacion = "No hay vacunas";
                return View("Errorusuario", "Home");
            }
        }

        public ActionResult Detalles(string NombreVacuna)
        {
            
            response = cliente.GetAsync(productoUri +  "/BuscarPorId?NombreVacuna=" + NombreVacuna).Result;
            
           

            if (response.IsSuccessStatusCode)
            {
                var VacunaBuscada = response.Content.ReadAsAsync<ModeloVacEntero>().Result;
                response = cliente.GetAsync(productoUri + "/TodosLosPrestadores" ).Result;
                var prestador = response.Content.ReadAsAsync<IEnumerable<ModeloIpss>>().Result;
                ViewBag.prestadores = prestador;

                return View(VacunaBuscada);
            }
            else
            {
                // hay que "resolver" el tema del viewbag en la lista segun como organizemos la misma 
                ViewBag.ResultadoOperacion = "No se encontro la vacuna: " + NombreVacuna;
                return View("Errorusuario", "Home");
            }



        }
        public ActionResult VacunasMuchosCriterios()
        {
            return View("VacunasMuchosCriterios");
        }

        [HttpPost]
        public ActionResult VacunasMuchosCriterios(int? faseAprobacion, decimal? topeMax, decimal? topeMin, int? idTipoVac, string laboratorio, string pais, bool? todos)
        {
            if (todos == null)
            {
                todos = false;
            }
            response = cliente.GetAsync(productoUri +
                "/BuscarMuchosCriterios?faseAprobacion="+faseAprobacion
                +"&topeMax="+ topeMax
                +"&topeMin="+ topeMin
                +"&idTipoVac="+ idTipoVac
                +"&laboratorio=" + laboratorio
                +"&pais="+pais
                +"&todos="+todos
                ).Result;
            if (response.IsSuccessStatusCode)
            {
                var vacunas = response.Content.ReadAsAsync<IEnumerable<ModeloVacEntero>>().Result;
                return View(vacunas);
            }
            else
            {
                ViewBag.ResultadoOperacion = "No hay vacunas";
                return View("Errorusuario", "Home");
            }
        }

        public ActionResult FindAllIpss()
        {
            response = cliente.GetAsync(productoUri + "/TodosLosPrestadores").Result;
            if (response.IsSuccessStatusCode)
            {
                var prestadores = response.Content.ReadAsAsync<IEnumerable<ModeloIpss>>().Result;
                return View(prestadores);
            }
            else
            {
                ViewBag.ResultadoOperacion = "No hay ninguna institucion prestadora de salud ";
                return View("Errorusuario", "Home");
            }
        }

        public ActionResult FindById(int? id)
        {
            response = cliente.GetAsync(productoUri + "/IpssXId?id="+id).Result;
            if (response.IsSuccessStatusCode)
            {
                var vacunas = response.Content.ReadAsAsync<ModeloIpss>().Result;
                return View(vacunas);
            }
            else
            {
                ViewBag.ResultadoOperacion = "No hay ninguna institucion prestadora de salud ";
                return View("Errorusuario", "Home");
            }
        }
        public ActionResult FindByComprador(int id)
        {
            response = cliente.GetAsync(productoUri + "/CompraXcomprador?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var compras = response.Content.ReadAsAsync<IEnumerable<ModeloCompras>>().Result;
                int contadorCompras = 0;
                
                decimal comprasDelMes = 0;
                foreach (ModeloCompras c in compras) {
                    if (c.FechaCompra.Month == DateTime.Today.Month) {
                        contadorCompras++;
                        comprasDelMes = comprasDelMes + c.TotalCompra;
                        
                    }
                }
                response = cliente.GetAsync(productoUri + "/IpssXId?id=" + id).Result;
                var comprador = response.Content.ReadAsAsync<ModeloIpss>().Result;
                decimal Saldo = comprador.GastoMaxXAfiliado * comprador.CantAfiliados;

                ViewBag.CompraRes = comprador.CantidadMaxComprasMensuales - contadorCompras;
                ViewBag.DineroAuto = Saldo;
                ViewBag.Saldo = Saldo - comprasDelMes;

                return View(compras);
            }
            else
            {
                ViewBag.ResultadoOperacion = "No hay ninguna institucion prestadora de salud ";
                return View("Errorusuario", "Home");
            }
        }

        // Compra
        [HttpPost]
        
        public ActionResult Comprar(string Nombre, decimal Precio,int Cantidad,int opciones )
        {
            Models.ModeloCompras com = new ModeloCompras {
              NombreVacuna = Nombre,
              PrecioUnitVacuna=Precio,
              CantDosisCompradas=Cantidad,
              NroCompradorMSP=opciones,
              TotalCompra=Precio*Cantidad,
              FechaCompra= DateTime.Today,
            };
            if (com!=null)
            {

                //cliente.BaseAddress = productoUri;

                var tareaPost = cliente.PostAsJsonAsync(productoUri, com);

                var result = tareaPost.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["ResultadoOperacion"] = "Agregado el producto ";

                    return RedirectToAction("FindByComprador", new { id = opciones });
                }
                return View("Errorusuario","Home");
            }
            else
            {
                TempData["ResultadoOperacion"] = "Ups! Verifique los datos";

                return RedirectToAction("Index","Home");
            }
        }
        




      
    }
}
