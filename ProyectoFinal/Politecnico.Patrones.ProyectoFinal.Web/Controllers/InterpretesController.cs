using System;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Web.Models;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class InterpretesController : Controller {
        private readonly IGestorDominio _gestorDominio;
        public InterpretesController(IGestorDominio gestorDominio) {
            _gestorDominio = gestorDominio;
        }
        //
        // GET: /Interpretes/
        public ActionResult Index(int pagina = 0, string nombre = "") {
            var lista = _gestorDominio.TraerInterpretes(pagina, nombre);
            if (TempData.ContainsKey("mensaje")) {
                ViewBag.Mensaje = TempData["mensaje"];
            }
            return View(lista);
        }

        //
        // GET: /Interpretes/Traer
        public ActionResult Traer(MVInterpreteFiltroLista filtroLista) {
            var lista = _gestorDominio.TraerInterpretes(filtroLista.Pagina, filtroLista.Nombre);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Interpretes/Detalle/5
        public ActionResult Detalle(int id = 0) {
            Interprete interprete = _gestorDominio.TraerInterprete(id);
            if (interprete == null) {
                return HttpNotFound();
            }
            
            var albumesInterprete = _gestorDominio.TraerAlbumesInterprete(id);
            var albumesDetallados = _gestorDominio.DetallarAlbumes(albumesInterprete);

            var modelo = new MVInterpreteDetallado
                {
                    Id = interprete.Id,
                    Nombre = interprete.Nombre,
                    Albumes = albumesDetallados,
                    CancionesSinAlbum = new MVCancionLista
                        {
                            MostrarAlbum = false,
                            MostrarCabecera = false,
                            Canciones = _gestorDominio.TraerCancionesInterprete(id)
                        }
                };

            return View(modelo);
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
                var entrada = new EditarInterpreteEntrada
                    {
                        InterpreteId = interprete.Id,
                        Nombre = interprete.Nombre
                    };
                var salida = _gestorDominio.EditarInterprete(entrada);
                if (salida != SalidaBase.Resultados.Exito) {
                    TempData["mensaje"] = "error: " + salida.Mensaje;
                }

                return RedirectToAction("Index");
            }

            return View(interprete);
        }

        //
        // GET: /Interpretes/Editar/5
        public ActionResult Editar(int id = 0) {
            Interprete interprete = _gestorDominio.TraerInterprete(id);
            if (interprete == null) return HttpNotFound();

            return View(interprete);
        }

        //
        // POST: /Interpretes/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Interprete interprete) {
            if (ModelState.IsValid) {
                var entrada = new EditarInterpreteEntrada
                {
                    InterpreteId = interprete.Id,
                    Nombre = interprete.Nombre
                };
                var salida = _gestorDominio.EditarInterprete(entrada);
                if (salida != SalidaBase.Resultados.Exito) {
                    TempData["mensaje"] = "error: " + salida.Mensaje;
                }

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
            var disposable = _gestorDominio as IDisposable;
            if (disposable != null) disposable.Dispose();
            base.Dispose(disposing);
        }
    }
}