using System;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class CancionesController : Controller {
        private readonly IGestorDominio _gestorDominio;
        public CancionesController(IGestorDominio gestorDominio) {
            _gestorDominio = gestorDominio;
        }
        // GET: /Canciones/
        public ActionResult Index(int pagina = 0, string nombre = "") {
            var lista = _gestorDominio.TraerCanciones(pagina, nombre, FiltroAlbum.Todas, null);
            return View(lista);
        }
        //
        // GET: /Interpretes/Traer
        public ActionResult Traer(MVCancionFiltroLista filtroLista) {
            var lista = _gestorDominio.TraerCanciones(filtroLista.Pagina, filtroLista.Nombre, filtroLista.FiltroAlbum,
                filtroLista.Album);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MasVotadas() {
            var cancionesMasVotadas = _gestorDominio.TraerCancionesMasVotadas(5);
            return PartialView(cancionesMasVotadas);

        }
        //
        // GET: /Canciones/Detalle/5
        public ActionResult Detalle(int id = 0) {
            Cancion cancion = _gestorDominio.TraerCancion(id);
            if (cancion == null) {
                return HttpNotFound();
            }
            return View(cancion);
        }
        //
        // GET: /Canciones/Crear
        public ActionResult Crear() {
            return View();
        }
        //
        // POST: /Canciones/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Cancion cancion) {
            if (ModelState.IsValid) {
                var entrada = new EditarCancionEntrada {CancionId = cancion.Id, Nombre = cancion.Nombre};
                var salida = _gestorDominio.EditarCancion(entrada);
                if (salida != SalidaBase.Resultados.Exito) {
                    TempData["mensaje"] = "error: " + salida.Mensaje;
                }
                return RedirectToAction("Index");
            }

            return View(cancion);
        }
        //
        // GET: /Canciones/Editar/5
        public ActionResult Editar(int id = 0) {
            Cancion cancion = _gestorDominio.TraerCancion(id);
            if (cancion == null) return HttpNotFound();

            return View(cancion);
        }
        //
        // POST: /Canciones/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cancion cancion) {
            if (ModelState.IsValid) {
                var entrada = new EditarCancionEntrada {CancionId = cancion.Id, Nombre = cancion.Nombre};
                var salida = _gestorDominio.EditarCancion(entrada);
                if (salida != SalidaBase.Resultados.Exito) {
                    TempData["mensaje"] = "error: " + salida.Mensaje;
                }
                return RedirectToAction("Index");
            }
            return View(cancion);
        }
        //
        // GET: /Canciones/Borrar/5
        public ActionResult Borrar(int id = 0) {
            throw new NotSupportedException("No permitido");

        }
        //
        // POST: /Canciones/Borrar/5
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarConfirmado(int id) {
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            var disposable = _gestorDominio as IDisposable;
            if (disposable != null) disposable.Dispose();
            base.Dispose(disposing);
        }
    }

    public class MVCancionFiltroLista {
        public int Pagina { get; set; }
        public string Nombre { get; set; }
        public FiltroAlbum FiltroAlbum { get; set; }
        public int? Album { get; set; }
    }
}