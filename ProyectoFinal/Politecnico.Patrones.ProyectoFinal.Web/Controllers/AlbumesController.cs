using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class AlbumesController : Controller {
        private readonly IGestorDominio _gestorDominio;

        public AlbumesController(IGestorDominio gestorDominio) {
            _gestorDominio = gestorDominio;
        }
        //
        // GET: /Albumes/
        public ActionResult Index(int pagina = 0, string nombre = "", int? interprete = null) {
            var lista = _gestorDominio.TraerAlbumes(pagina, nombre, interprete);
            var listaDetalle = _gestorDominio.DetallarAlbumes(lista);

            if (TempData.ContainsKey("mensaje")) {
                ViewBag.Mensaje = TempData["mensaje"];
            }
            return View(listaDetalle);
        }
        public ActionResult Traer(MVAlbumFiltroLista filtroLista) {
            var lista = _gestorDominio.TraerAlbumes(filtroLista.Pagina, filtroLista.Nombre, filtroLista.Interprete);
            return Json(lista, JsonRequestBehavior.AllowGet);
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
            return View(new MVAlbumDetallado
                {
                    AñoLanzamiento = 2015,
                    Interpretes = new List<MVInterprete>()
                });
        }
        //
        // POST: /Albumes/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(FormCollection form) {
            var editarAlbumEntrada = new EditarAlbumEntrada
                {
                    AlbumId = Convert.ToInt32(form["Id"]),
                    Nombre = form["Nombre"],
                    AñoLanzamiento = Convert.ToInt32(form["AñoLanzamiento"]),
                };
            var editarAlbumSalida = _gestorDominio.EditarAlbum(editarAlbumEntrada);
            if (editarAlbumSalida != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + editarAlbumSalida.Mensaje;
                return RedirectToAction("Index");
            }

            var interpretes = JsonConvert.DeserializeObject<List<MVInterprete>>(form["hidInterpretes"]);
            var relacionarInterpretesAAlbumEntrada = new RelacionarInterpretesAAlbumEntrada
                {
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                    AlbumId = editarAlbumSalida.Album.Id,
                    Interpretes = interpretes.Select(i => i.Id).ToList(),
                };
            var relacionarInterpretesAAlbumSalida =
                _gestorDominio.RelacionarInterpretesAAlbum(relacionarInterpretesAAlbumEntrada);
            if (relacionarInterpretesAAlbumSalida != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + relacionarInterpretesAAlbumSalida.Mensaje;
                return RedirectToAction("Index");
            }

            var canciones = JsonConvert.DeserializeObject<List<MVCancion>>(form["hidCanciones"]);
            var asociarCancionYAlbumEntrada = new AsociarCancionYAlbumEntrada
                {
                    Accion = AsociarCancionYAlbumEntrada.Acciones.Asociar,
                    AlbumId = editarAlbumSalida.Album.Id,
                    Canciones = canciones.Select(i => i.Id).ToList(),
                };
            var asociarCancionYAlbumEntradaSalida =
                _gestorDominio.AsociarCancionYAlbum(asociarCancionYAlbumEntrada);
            if (asociarCancionYAlbumEntradaSalida != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + asociarCancionYAlbumEntradaSalida.Mensaje;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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
            var model = new MVAlbumDetallado {Id = album.Id, Nombre = album.Nombre};
            var listaInterpretes = TraerListaInterpretes(album);
            model.Interpretes = listaInterpretes;
            var listaCanciones = TraerListaCanciones(album);
            model.Canciones = listaCanciones;

            return View(model);
        }
        private IList<MVCancion> TraerListaCanciones(Album album) {
            var canciones = _gestorDominio.TraerCancionesAlbum(album.Id);
            var listaCanciones = (from i in canciones select new MVCancion {Id = i.Id, Nombre = i.Nombre}).ToList();
            return listaCanciones;
        }
        private IList<MVInterprete> TraerListaInterpretes(Album album) {
            var interpretes = _gestorDominio.TraerInterpretesAlbum(album.Id);
            var listaInterpretes =
                (from i in interpretes select new MVInterprete {Id = i.Id, Nombre = i.Nombre}).ToList();
            return listaInterpretes;
        }
        //
        // POST: /Albumes/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MVAlbumDetallado albumDetallado) {
            if (!ModelState.IsValid) return View(albumDetallado);

            var album = _gestorDominio.TraerAlbum(albumDetallado.Id);
            album.Nombre = albumDetallado.Nombre;
            var entrada = new EditarAlbumEntrada {AlbumId = albumDetallado.Id, Nombre = albumDetallado.Nombre};
            var salida = _gestorDominio.EditarAlbum(entrada);
            if (salida != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: " + salida.Mensaje;
                return View(albumDetallado);
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
            if (salida != SalidaBase.Resultados.Exito) {
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
            if (salida != SalidaBase.Resultados.Exito) {
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