using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;
using Politecnico.Patrones.ProyectoFinal.Web.Models;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class AlbumesController : Controller {
        private readonly IGestorDominio _gestorDominio = Utiles.TraerGestorDominio();

        //
        // GET: /Albumes/
        public ActionResult Index(int pagina = 0, string nombre = "") {
            var lista = _gestorDominio.TraerAlbumes(pagina, nombre);
            if (TempData.ContainsKey("mensaje")) {
                ViewBag.Mensaje = TempData["mensaje"];
            }
            return View(lista);
        }
        //
        // GET: /Albumes/Detalle/5
        public ActionResult Detalle(int id = 0) {
            Album album = _gestorDominio.TraerAlbum(id);
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
                var entrada = new EditarAlbumEntrada {AlbumId = album.Id, Nombre = album.Nombre};
                var salida = _gestorDominio.EditarAlbum(entrada);
                if (salida != SalidaBase.Resultados.Exito) {
                    TempData["mensaje"] = "error: " + salida.Mensaje;
                }
                return RedirectToAction("Index");
            }

            return View(album);
        }
        //
        // GET: /Albumes/Editar/5
        public ActionResult Editar(int id = 0) {
            Album album = _gestorDominio.TraerAlbum(id);
            if (album == null) return HttpNotFound();
            if (TempData.ContainsKey("mensaje")) {
                ViewBag.Mensaje = TempData["mensaje"];
            }

            // cargar interpretes
            var model = new MVAlbumEditar {AlbumId = album.Id, AlbumNombre = album.Nombre};
            var listaInterpretes = TraerListaInterpretes(album);
            model.ListaInterpretes = listaInterpretes;

            return View(model);
        }
        private IEnumerable<MVInterprete> TraerListaInterpretes(Album album) {
            var interpretes = _gestorDominio.TraerInterpretesAlbum(album.Id);
            var listaInterpretes = from i in interpretes select new MVInterprete {Id = i.Id, Nombre = i.Nombre};
            return listaInterpretes;
        }
        //
        // POST: /Albumes/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MVAlbumEditar albumEditar) {
            if (!ModelState.IsValid) return View(albumEditar);

            var album = _gestorDominio.TraerAlbum(albumEditar.AlbumId);
            album.Nombre = albumEditar.AlbumNombre;
            var entrada = new EditarAlbumEntrada {AlbumId = albumEditar.AlbumId, Nombre = albumEditar.AlbumNombre};
            var salida = _gestorDominio.EditarAlbum(entrada);
            if (salida != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + salida.Mensaje;
                return View(albumEditar);
            }

            return RedirectToAction("Index");
        }
        //
        // POST: /Albumes/AsociarInterprete
        public ActionResult AsociarInterprete(int padreId, int interpreteElegidoId) {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                    AlbumId = padreId,
                    Interpretes = new List<int> {interpreteElegidoId}
                };
            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);
            if (salida.Resultado != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + salida.Mensaje;
            }

            return RedirectToAction("Editar", "Albumes", new {id = padreId});
        }
        //
        // POST: /Albumes/DesasociarInterprete
        public ActionResult DesasociarInterprete(int albumId, int interpreteId) {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Eliminar,
                    AlbumId = albumId,
                    Interpretes = new List<int> {interpreteId}
                };
            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);
            if (salida.Resultado != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + salida.Mensaje;
            }

            return RedirectToAction("Editar", "Albumes", new {id = albumId});
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
            var disposable = _gestorDominio as IDisposable;
            if (disposable != null) disposable.Dispose();
            base.Dispose(disposing);
        }
    }
}