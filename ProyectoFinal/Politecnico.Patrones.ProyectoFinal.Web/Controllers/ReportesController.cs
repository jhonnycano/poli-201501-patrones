using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Web.Models;
using Rotativa;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    public class ReportesController : Controller {
        private readonly IGestorDominio _gestorDominio;
        public ReportesController(IGestorDominio gestorDominio) {
            _gestorDominio = gestorDominio;
        }
        //
        // GET: /Reportes/

        public ActionResult Index() {
            if (TempData.ContainsKey("mensaje")) {
                ViewBag.Mensaje = TempData["mensaje"];
            }

            var definicion = TraerDefinicionReportes();
            return View(definicion);
        }
        public ActionResult Reporte(TipoReporte tipo, int dest = 0) {
            var vistaParametros = TraerVistaParametros(tipo);
            var definicion = TraerDefinicionReportes();
            ViewData["Tipo"] = tipo;
            ViewData["Destino"] = dest;
            ViewData["ParametrosReporte"] = vistaParametros;
            ViewData["Nombre"] = definicion.First(r => r.Tipo == tipo).Etiqueta;
            return View();
        }
        public ActionResult Traer(FormCollection form) {
            var tipo = form["tipo"];
            var destino = int.Parse(form["destino"]);

            TipoReporte tipoReporte;
            if (!Enum.TryParse(tipo, out tipoReporte))
                return RedirectToAction("Index");

            var llavesOmitir = new[] {"tipo"};
            var parametros = form.Keys
                .Cast<string>()
                .Where(llave => !llavesOmitir.Contains(llave))
                .ToDictionary<string, string, object>(llave => llave, llave => form[llave]);

            var entrada = new GenerarReporteEntrada
                {
                    Tipo = tipoReporte,
                    Parametros = parametros,
                };
            var salida = _gestorDominio.GenerarReporte(entrada);
            if (salida != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + salida.Mensaje;
                return RedirectToAction("Index");
            }

            var vista = salida.Consulta.Vista;
            dynamic objeto = salida.Consulta.Objeto;

            if (destino == 0) {
                return View(vista, objeto);
            }

            ViewData["destino"] = destino;
            var fch = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            string archivo = tipoReporte + "_" + fch + ".pdf";
            return new ViewAsPdf(vista, objeto) {FileName = archivo};
        }
        private string TraerVistaParametros(TipoReporte tipo) {
            return "_Params" + tipo;
        }
        private static List<ReporteDefinicion> TraerDefinicionReportes() {
            var modelo = new List<ReporteDefinicion>
                {
                    new ReporteDefinicion {Etiqueta = "Sencillos por rango de tiempo", Tipo = TipoReporte.ListaCanciones},
                    new ReporteDefinicion {Etiqueta = "Álbumes por rango de tiempo", Tipo = TipoReporte.ListaAlbumes},
                    new ReporteDefinicion {Etiqueta = "Detalle de intérprete", Tipo = TipoReporte.InterpreteDetalle},
                    new ReporteDefinicion {Etiqueta = "Sencillos de un álbum", Tipo = TipoReporte.ListaCancionesAlbum},
                };
            return modelo;
        }
    }
}