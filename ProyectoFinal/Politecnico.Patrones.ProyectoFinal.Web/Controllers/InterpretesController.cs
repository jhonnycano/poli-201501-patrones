using System;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class InterpretesController : Controller {
        private readonly IGestorPersistencia _gestorPersistencia = Utiles.TraerGestorPersistencia();
        //
        // GET: /Interpretes/

        public ActionResult Index(int pagina = 0) {
            var lista = _gestorPersistencia.TraerInterpretes(pagina);
            return View(lista);
        }

        //
        // GET: /Interpretes/Detalle/5

        public ActionResult Detalle(int id = 0) {
            Interprete interprete = _gestorPersistencia.TraerInterprete(id);
            if (interprete == null) {
                return HttpNotFound();
            }
            return View(interprete);
        }

        //
        // GET: /Interpretes/Crear

        public ActionResult Crear() {
            return View();
        }

        //
        // POST: /Interpretes/Crear

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Interprete interprete) {
            if (ModelState.IsValid) {
                _gestorPersistencia.Guardar(interprete);
                return RedirectToAction("Index");
            }

            return View(interprete);
        }

        //
        // GET: /Interpretes/Editar/5

        public ActionResult Editar(int id = 0) {
            Interprete interprete = _gestorPersistencia.TraerInterprete(id);
            if (interprete == null) return HttpNotFound();

            return View(interprete);
        }

        //
        // POST: /Interpretes/Editar/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Interprete interprete) {
            if (ModelState.IsValid) {
                _gestorPersistencia.Guardar(interprete);
                return RedirectToAction("Index");
            }
            return View(interprete);
        }

        //
        // GET: /Interpretes/Borrar/5

        public ActionResult Borrar(int id = 0) {
            throw new NotSupportedException("No permitido");

            /*
            Interprete interprete = _gestorPersistencia.TraerInterprete(id);
            if (interprete == null) return HttpNotFound();

            return View(interprete);
             * */
        }

        //
        // POST: /Interpretes/Borrar/5

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarConfirmado(int id) {
            //Interprete interprete = _gestorPersistencia.TraerInterprete(id);
            //db.DbSetInterprete.Remove(interprete);
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