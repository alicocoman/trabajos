using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Archvos;
using Dominio.EntidadesNegocio;
using Repositorios;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        
        RepositorioUsuario repoUsu = new RepositorioUsuario();
        RepositorioTipoVacuna repoTVac = new RepositorioTipoVacuna();
        RepositorioLaboratorio repoLab = new RepositorioLaboratorio();
        RepositorioVacuna repoVac = new RepositorioVacuna();
        Importador impo = new Importador();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult volcadoArchivos()
        {
            //importados correctamente
            List<Usuario> usuImportados = new List<Usuario>();
            List<Models.Vacuna_Nombre_Tipo_Precio> vacImportadas = new List<Models.Vacuna_Nombre_Tipo_Precio>();

            IEnumerable<Usuario> usu = impo.UsuDeTexto();
            IEnumerable<Laboratorio> lab = impo.LabDeTexto();
            IEnumerable<TipoVacuna> TVac = impo.TVacDeTexto();
            IEnumerable<Vacuna> Vac = impo.VacDeTexto();

            foreach (Usuario u in usu)
            {
                Usuario usuSinEncriptar= new Usuario
                {
                    Cedula=u.Cedula,
                    Password = u.Password,
                   

                };
                bool ok = repoUsu.Add(u);
                if (ok)
                {

                    usuImportados.Add(usuSinEncriptar);
                    
                        
                }

            }
            foreach (TipoVacuna TV in TVac)
            {
                repoTVac.Add(TV);
            }
            foreach (Laboratorio L in lab)
            {
                repoLab.Add(L);
            }

            foreach (Vacuna v in Vac)
            {
                bool ok = repoVac.Add(v);
                if (ok)
                {
                    Models.Vacuna_Nombre_Tipo_Precio vacuna = new Models.Vacuna_Nombre_Tipo_Precio
                    {
                        Nombre = v.Nombre,
                        Precio = v.Precio,
                        IdTipoVacuna = v.IdTipoDeVacuna.ToString(),
                    };

                    vacImportadas.Add(vacuna);
                       
                }
            }

            ViewBag.Usuarios = usuImportados;
            
            return View("volcadoArchivos",vacImportadas);
        }


        public ActionResult Details(string Nombre) {
            Vacuna vac = repoVac.FindByName(Nombre);


            return View("Detalle",vac);
        }
       




    }
}