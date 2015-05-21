using System;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Web.Models;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class AlbumesController : Controller {
        private readonly IGestorPersistencia _gestorPersistencia = Utiles.TraerGestorPersistencia();

        //
        // GET: /Albumes/

        public ActionResult Index(int pagina = 0) {
            var lista = _gestorPersistencia.TraerAlbumes(pagina);
            return View(lista);
        }

        //
        // GET: /Albumes/Detalle/5

        public ActionResult Detalle(int id = 0) {
            Album album = _gestorPersistencia.TraerAlbum(id);
            if (album == null) {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /Albumes/Crear

        public ActionResult Crear() {
            return View();
        }

        //
        // POST: /Albumes/Crear

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Album album) {
            if (ModelState.IsValid) {
                _gestorPersistencia.Guardar(album);
                return RedirectToAction("Index");
            }

            return View(album);
        }

        //
        // GET: /Albumes/Editar/5

        public ActionResult Editar(int id = 0) {
            Album album = _gestorPersistencia.TraerAlbum(id);
            if (album == null) return HttpNotFound();

            var model = new MVAlbumEditar {Album = album};
            //var interpretes = _gestorPersistencia.TraerInterpretes(0, )
            //ViewBag["interpretes"] = Utiles.GenerarItems()
            

            return View(model);
        }

        //
        // POST: /Albumes/Editar/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Album album) {
            if (ModelState.IsValid) {
                _gestorPersistencia.Guardar(album);
                return RedirectToAction("Index");
            }
            return View(album);
        }

        //
        // GET: /Interpretes/Borrar/5

        public ActionResult Borrar(int id = 0) {
            throw new NotSupportedException("No permitido");

            /*
            Album album = _gestorPersistencia.TraerAlbum(id);
            if (album == null) return HttpNotFound();

            return View(album);
             * */
        }

        //
        // POST: /Interpretes/Borrar/5

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarConfirmado(int id) {
            //Album album = _gestorPersistencia.TraerAlbum(id);
            //db.DbSetInterprete.Remove(album);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            var disposable = _gestorPersistencia as IDisposable;
            if (disposable != null) disposable.Dispose();
            base.Dispose(disposing);
        }
    }
}