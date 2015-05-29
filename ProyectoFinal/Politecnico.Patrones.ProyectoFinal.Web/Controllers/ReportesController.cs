using System;
using System.Linq;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

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
            return View();
        }

        public ActionResult Reporte(TipoReporte tipo) {
            var vistaParametros = TraerVistaParametros(tipo);
            ViewBag.Tipo = tipo;
            ViewBag.ParametrosReporte = vistaParametros;
            return View();
        }
        public ActionResult Traer(FormCollection form) {
            var tipo = form["tipo"];
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

            return View(vista, objeto);
        }
        private string TraerVistaParametros(TipoReporte tipo) {
            return "_" + tipo;
        }
    }
}