using System.Data;
using System.Linq;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class InterpretesController : Controller {
        private readonly GestorPersistenciaEF db = new GestorPersistenciaEF();

        //
        // GET: /Interpretes/

        public ActionResult Index() {
            return View(db.DbSetInterprete.ToList());
        }

        //
        // GET: /Interpretes/Details/5

        public ActionResult Details(int id = 0) {
            Interprete interprete = db.DbSetInterprete.Find(id);
            if (interprete == null) {
                return HttpNotFound();
            }
            return View(interprete);
        }

        //
        // GET: /Interpretes/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Interpretes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Interprete interprete) {
            if (ModelState.IsValid) {
                db.DbSetInterprete.Add(interprete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interprete);
        }

        //
        // GET: /Interpretes/Edit/5

        public ActionResult Edit(int id = 0) {
            Interprete interprete = db.DbSetInterprete.Find(id);
            if (interprete == null) {
                return HttpNotFound();
            }
            return View(interprete);
        }

        //
        // POST: /Interpretes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Interprete interprete) {
            if (ModelState.IsValid) {
                db.Entry(interprete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interprete);
        }

        //
        // GET: /Interpretes/Delete/5

        public ActionResult Delete(int id = 0) {
            Interprete interprete = db.DbSetInterprete.Find(id);
            if (interprete == null) {
                return HttpNotFound();
            }
            return View(interprete);
        }

        //
        // POST: /Interpretes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Interprete interprete = db.DbSetInterprete.Find(id);
            db.DbSetInterprete.Remove(interprete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}