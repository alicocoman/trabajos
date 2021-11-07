using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio.EntidadesNegocio;
using Repositorios;
using System.Data.SqlClient;




namespace apiV.Controllers
{
    [RoutePrefix("api/VacunasApi")]
    public class VacunaApiController : ApiController
    {
        RepositorioCompra repoCompra = new RepositorioCompra();
        RepositorioVacuna repoVacuna = new RepositorioVacuna();
        RepositorioLaboratorio repoLab = new RepositorioLaboratorio();
        RepositorioTipoVacuna repoTVac = new RepositorioTipoVacuna();
        RepositorioIpss repoIpss = new RepositorioIpss();

        [Route("TodasLasVacunas")]
      
        public IHttpActionResult GetTodas()
        {
            var listaVacunas = repoVacuna.FindAll();
            if (listaVacunas != null)
            {
                return Ok(listaVacunas.Select(q => new Models.ModeloVacEntero
                {

                    Nombre = q.Nombre,
                    CantDosis = q.CantDosis,
                    DiasEntreDosis = q.DiasEntreDosis,
                    EdadMinima = q.EdadMinima,
                    EdadMaxima = q.EdadMaxima,
                    EficaciaVsCovid = q.EficaciaVsCovid,
                    PrevenirHospitalizacion = q.PrevenirHospitalizacion,
                    PrevenirCTI = q.PrevenirCTI,
                    TempMinima = q.TempMinima,
                    TempMaxima = q.TempMaxima,
                    FaseClinicaAprobacion = q.FaseClinicaAprobacion,
                    AprovacionDeEmergencia = q.AprovacionDeEmergencia,
                    Precio = q.Precio,
                    EfectosAdversos = q.EfectosAdversos,
                    ProduccionAnual = q.ProduccionAnual,
                    CedulaRegistrador = q.CedulaRegistrador,
                    FormaParteCovax = q.FormaParteCovax,
                    FechaUltimaEdicion = q.FechaUltimaEdicion,
                    PaisesQueAprobaronLaVacuna = q.PaisesQueAprobaronLaVacuna,
                    IdTipoDeVacuna = q.IdTipoDeVacuna,
                    TipoDeVacuna = q.TipoDeVacuna,
                    NombreLaboratorios = string.Join(",", q.Laboratorios.Select(p => p.Nombre)),

                }).ToList());
            }
            else { 
            return NotFound();
        }

        }

        [HttpGet]
        [Route("BuscarPorId")]
        public IHttpActionResult GetVacXId(string NombreVacuna) {
            var q = repoVacuna.FindByName(NombreVacuna);
            if (q != null) {

                string NombreLabs = "";
                foreach (Laboratorio l in q.Laboratorios)
                {
                    NombreLabs = NombreLabs + l.Nombre + " |";
                }


                return Ok(new Models.ModeloVacEntero
                {

                    Nombre = q.Nombre,
                    CantDosis = q.CantDosis,
                    DiasEntreDosis = q.DiasEntreDosis,
                    EdadMinima = q.EdadMinima,
                    EdadMaxima = q.EdadMaxima,
                    EficaciaVsCovid = q.EficaciaVsCovid,
                    PrevenirHospitalizacion = q.PrevenirHospitalizacion,
                    PrevenirCTI = q.PrevenirCTI,
                    TempMinima = q.TempMinima,
                    TempMaxima = q.TempMaxima,
                    FaseClinicaAprobacion = q.FaseClinicaAprobacion,
                    AprovacionDeEmergencia = q.AprovacionDeEmergencia,
                    Precio = q.Precio,
                    EfectosAdversos = q.EfectosAdversos,
                    ProduccionAnual = q.ProduccionAnual,
                    CedulaRegistrador = q.CedulaRegistrador,
                    FormaParteCovax = q.FormaParteCovax,
                    FechaUltimaEdicion = q.FechaUltimaEdicion,
                    PaisesQueAprobaronLaVacuna = q.PaisesQueAprobaronLaVacuna,
                    IdTipoDeVacuna = q.IdTipoDeVacuna,
                    TipoDeVacuna = q.TipoDeVacuna,
                    NombreLaboratorios = NombreLabs,

                });

            }
            return NotFound();

        }


        [HttpGet]
        [Route("BuscarMuchosCriterios")]
        public IHttpActionResult GetVacunasMuchosCriterios(int? faseAprobacion, decimal? topeMax, decimal? topeMin, int? idTipoVac, string laboratorio, string pais, bool todos)
        {
            if (todos)
            {
                var vacunas = repoVacuna.FindByTodos(faseAprobacion, topeMax, topeMin, idTipoVac, laboratorio, pais);
                if (vacunas != null)
                {
                    return Ok(vacunas.Select(q => new Models.ModeloVacEntero

                    {
                        Nombre = q.Nombre,
                        CantDosis = q.CantDosis,
                        DiasEntreDosis = q.DiasEntreDosis,
                        EdadMinima = q.EdadMinima,
                        EdadMaxima = q.EdadMaxima,
                        EficaciaVsCovid = q.EficaciaVsCovid,
                        PrevenirHospitalizacion = q.PrevenirHospitalizacion,
                        PrevenirCTI = q.PrevenirCTI,
                        TempMinima = q.TempMinima,
                        TempMaxima = q.TempMaxima,
                        FaseClinicaAprobacion = q.FaseClinicaAprobacion,
                        AprovacionDeEmergencia = q.AprovacionDeEmergencia,
                        Precio = q.Precio,
                        EfectosAdversos = q.EfectosAdversos,
                        ProduccionAnual = q.ProduccionAnual,
                        CedulaRegistrador = q.CedulaRegistrador,
                        FormaParteCovax = q.FormaParteCovax,
                        FechaUltimaEdicion = q.FechaUltimaEdicion,
                        PaisesQueAprobaronLaVacuna = q.PaisesQueAprobaronLaVacuna,
                        IdTipoDeVacuna = q.IdTipoDeVacuna,
                        TipoDeVacuna = q.TipoDeVacuna,
                        NombreLaboratorios = string.Join(",", q.Laboratorios.Select(l => l.Nombre)),

                    })
                    .ToList());

                }
            }
            else
            {
                var vacunas = repoVacuna.FindByAlgunos(faseAprobacion, topeMax, topeMin, idTipoVac, laboratorio, pais);
                if (vacunas != null)
                {
                    return Ok(vacunas.Select(q => new Models.ModeloVacEntero
                    {
                        Nombre = q.Nombre,
                        CantDosis = q.CantDosis,
                        DiasEntreDosis = q.DiasEntreDosis,
                        EdadMinima = q.EdadMinima,
                        EdadMaxima = q.EdadMaxima,
                        EficaciaVsCovid = q.EficaciaVsCovid,
                        PrevenirHospitalizacion = q.PrevenirHospitalizacion,
                        PrevenirCTI = q.PrevenirCTI,
                        TempMinima = q.TempMinima,
                        TempMaxima = q.TempMaxima,
                        FaseClinicaAprobacion = q.FaseClinicaAprobacion,
                        AprovacionDeEmergencia = q.AprovacionDeEmergencia,
                        Precio = q.Precio,
                        EfectosAdversos = q.EfectosAdversos,
                        ProduccionAnual = q.ProduccionAnual,
                        CedulaRegistrador = q.CedulaRegistrador,
                        FormaParteCovax = q.FormaParteCovax,
                        FechaUltimaEdicion = q.FechaUltimaEdicion,
                        PaisesQueAprobaronLaVacuna = q.PaisesQueAprobaronLaVacuna,
                        IdTipoDeVacuna = q.IdTipoDeVacuna,
                        TipoDeVacuna = q.TipoDeVacuna,
                        NombreLaboratorios = string.Join(",", q.Laboratorios.Select(l => l.Nombre)),

                    })
                .ToList());

                }

            }
            return NotFound();
        }

        [HttpGet]
        [Route("TodosLosPrestadores")]
        public IHttpActionResult GetTodosLosIpss() {

            var listaIpss = repoIpss.FindAll();
            if (listaIpss != null)
            {
                return Ok(listaIpss.Select(q => new Models.ModeloIpss
                {
                    NroMSP = q.NroMSP,
                    Nombre = q.Nombre,
                    CantidadMaxComprasMensuales = q.CantidadMaxComprasMensuales,
                    CantAfiliados = q.CantAfiliados,
                    GastoMaxXAfiliado = q.GastoMaxXAfiliado,
                    NombreContacto = q.NombreContacto,
                    Telefono = q.Telefono,
                })
                .ToList());

            }


            return NotFound();
        }

        [HttpGet]
        [Route("IpssXId")]
        public IHttpActionResult GetIpssXId(int id)
        {

            var Ipss = repoIpss.FindById(id);
            if (Ipss != null)
            {
                return Ok(new Models.ModeloIpss
                {
                    NroMSP = Ipss.NroMSP,
                    Nombre = Ipss.Nombre,
                    CantidadMaxComprasMensuales = Ipss.CantidadMaxComprasMensuales,
                    CantAfiliados = Ipss.CantAfiliados,
                    GastoMaxXAfiliado = Ipss.GastoMaxXAfiliado,
                    NombreContacto = Ipss.NombreContacto,
                    Telefono = Ipss.Telefono,
                });
               

            }


            return NotFound();
        }

        // logica de la compra en api
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] Models.ModeloCompras Com)
        {     if (ModelState.IsValid)
           {
            Ipss comprador = repoIpss.FindById(Com.NroCompradorMSP);
            IEnumerable<Compra> comprasXcomprador = repoCompra.FindByComprador(Com.NroCompradorMSP);
            decimal comprasDelMes = 0;
                int cantidadCompras = 0;    
          
            foreach (Compra c in comprasXcomprador)
            {
                if (c.FechaCompra.Month == DateTime.Today.Month)
                {
                    comprasDelMes = comprasDelMes + c.TotalCompra;
                        cantidadCompras++;
                }
            }
                decimal saldoAfavor = (comprador.CantAfiliados*comprador.GastoMaxXAfiliado )- comprasDelMes;
             
                decimal precio = repoVacuna.FindByName(Com.NombreVacuna).Precio;
                
                Compra q = new Compra
                {
                  
                    NombreVacuna = Com.NombreVacuna,
                    NroCompradorMSP = Com.NroCompradorMSP,
                    CantDosisCompradas = Com.CantDosisCompradas,
                    FechaCompra = DateTime.Today,
                    PrecioUnitVacuna = precio,
                    
                };
                decimal tot = q.CalcularTotal();
                q.TotalCompra = tot;
                if (q.TotalCompra <= saldoAfavor && cantidadCompras<comprador.CantidadMaxComprasMensuales)
                {


                    if (repoCompra.Add(q))
                    {
                        return Ok(new Models.ModeloCompras
                        {

                           
                            NombreVacuna = q.NombreVacuna,
                            NroCompradorMSP = q.NroCompradorMSP,
                            CantDosisCompradas = q.CantDosisCompradas,
                            FechaCompra = DateTime.Today,
                            PrecioUnitVacuna = precio,


                        });
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
            }
            return (BadRequest(ModelState));
        }
        [HttpGet]
        [Route("CompraXcomprador")]
        public IHttpActionResult GetCompraXcomprador(int id)
        {
            IEnumerable<Compra> comprasXcomprador = repoCompra.FindByComprador(id);
            
            if (comprasXcomprador != null)
            {
                return Ok(comprasXcomprador.Select(q => new Models.ModeloCompras
                {
                    Id = q.Id,
                    CantDosisCompradas=q.CantDosisCompradas,
                    FechaCompra=q.FechaCompra,
                    NombreVacuna=q.NombreVacuna,
                    NroCompradorMSP=q.NroCompradorMSP,
                    PrecioUnitVacuna=q.PrecioUnitVacuna,
                    TotalCompra=q.TotalCompra,
                })
               .ToList()); ;


            }


            return NotFound();
        }







        private Vacuna MaterializarVacuna(Models.ModeloVacEntero vac)
            {
            if (vac== null)
            {
                return null;
            }
            else
            {
                string NombreLabs = "";
                foreach (Laboratorio l in vac.Laboratorios)
                {
                    NombreLabs = NombreLabs + l.Nombre + " |";
                }

                Vacuna unaVac = null;

                unaVac = new Vacuna();
                {
                    unaVac.Nombre = vac.Nombre;
                    unaVac.CantDosis = vac.CantDosis;
                    unaVac.DiasEntreDosis =vac.DiasEntreDosis;
                    unaVac.EdadMinima = vac.EdadMinima;
                    unaVac.EdadMaxima = vac.EdadMaxima;
                    unaVac.TempMinima = vac.TempMinima;
                    unaVac.TempMaxima = vac.TempMaxima;
                    unaVac.EficaciaVsCovid = vac.EficaciaVsCovid;
                    unaVac.PrevenirHospitalizacion = vac.PrevenirHospitalizacion;
                    unaVac.PrevenirCTI = vac.PrevenirCTI;
                    unaVac.FaseClinicaAprobacion = vac.FaseClinicaAprobacion;
                    unaVac.AprovacionDeEmergencia = vac.AprovacionDeEmergencia;
                    unaVac.Precio = vac.Precio;
                    unaVac.EfectosAdversos = vac.EfectosAdversos ;
                    unaVac.ProduccionAnual = vac.ProduccionAnual;
                    unaVac.CedulaRegistrador = vac.CedulaRegistrador;
                    unaVac.FormaParteCovax = vac.FormaParteCovax;
                    unaVac.FechaUltimaEdicion = vac.FechaUltimaEdicion;
                    unaVac.PaisesQueAprobaronLaVacuna = vac.PaisesQueAprobaronLaVacuna;
                    unaVac.TipoDeVacuna = repoTVac.FindById(vac.IdTipoDeVacuna);
                  


                };


                return unaVac;
            }
        }
    }
}
