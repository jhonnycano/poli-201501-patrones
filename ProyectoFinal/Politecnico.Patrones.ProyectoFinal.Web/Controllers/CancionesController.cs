using System;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class CancionesController : Controller {
        private readonly IGestorDominio _gestorDominio;
        public CancionesController(IGestorDominio gestorDominio) {
            _gestorDominio = gestorDominio;
        }
        // GET: /Canciones/
        public ActionResult Index(int pagina = 0, string nombre = "") {
            var lista = _gestorDominio.TraerCanciones(pagina, nombre);
            return View(lista);
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

            /*
            Cancion cancion = _gestorPersistencia.TraerInterprete(id);
            if (cancion == null) return HttpNotFound();

            return View(cancion);
             * */
        }

        //
        // POST: /Canciones/Borrar/5

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarConfirmado(int id) {
            //Cancion cancion = _gestorPersistencia.TraerCancion(id);
            //db.DbSetInterprete.Remove(cancion);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            var disposable = _gestorDominio as IDisposable;
            if (disposable != null) disposable.Dispose();
            base.Dispose(disposing);
        }
    }
}