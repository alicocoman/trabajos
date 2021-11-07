using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.EntidadesNegocio;
using Repositorios;

namespace MVC.Controllers
{
    public class IpssController : Controller
    {
        RepositorioIpss repoIpss = new RepositorioIpss();
       
        public ActionResult AgregarIpss()
        {
            return View("AgregarIpss");
        }

        [HttpPost]
        public ActionResult AgregarIpss(Models.ModeloIpss unIpss)
        {
            Ipss unaInst = new Ipss
            {
                NroMSP = unIpss.NroMSP,
                Nombre = unIpss.Nombre,
                CantidadMaxComprasMensuales = unIpss.CantidadMaxComprasMensuales,
                CantAfiliados = unIpss.CantAfiliados,
                GastoMaxXAfiliado = unIpss.GastoMaxXAfiliado,
                Telefono = unIpss.Telefono,
                NombreContacto = unIpss.NombreContacto,

            };
            if (unIpss != null) {
                repoIpss.Add(unaInst);


            }





            return View("../Home/Index");
        }
    }
}
