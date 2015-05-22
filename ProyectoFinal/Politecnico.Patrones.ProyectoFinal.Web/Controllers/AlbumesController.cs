﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;
using Politecnico.Patrones.ProyectoFinal.Web.Models;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class AlbumesController : Controller {
        private readonly IGestorPersistencia _gestorPersistencia = Utiles.TraerGestorPersistencia();
        private readonly IGestorDominio _gestorDominio = Utiles.TraerGestorDominio();

        //
        // GET: /Albumes/
        public ActionResult Index(int pagina = 0, string nombre = "") {
            var lista = _gestorPersistencia.TraerAlbumes(pagina, nombre);
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
            if (TempData.ContainsKey("mensaje")) {
                ViewBag.Mensaje = TempData["mensaje"];
            }

            // cargar interpretes
            var model = new MVAlbumEditar {AlbumId = album.Id, AlbumNombre = album.Nombre };
            var listaInterpretes = TraerListaInterpretes(album);
            model.ListaInterpretes = listaInterpretes;

            return View(model);
        }
        private IEnumerable<MVInterprete> TraerListaInterpretes(Album album) {
            var interpretes = _gestorPersistencia.TraerInterpretesAlbum(album.Id);
            var listaInterpretes = from i in interpretes select new MVInterprete {Id = i.Id, Nombre = i.Nombre};
            return listaInterpretes;
        }
        //
        // POST: /Albumes/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MVAlbumEditar albumEditar) {
            if (ModelState.IsValid) {
                var album = _gestorPersistencia.TraerAlbum(albumEditar.AlbumId);
                album.Nombre = albumEditar.AlbumNombre;
                _gestorPersistencia.Guardar(album);
                return RedirectToAction("Index");
            }

            return View(albumEditar);
        }

        public ActionResult AgregarInterprete(int padreId, int interpreteElegidoId) {
            var entrada = new RelacionarInterpretesAAlbumEntrada
                {
                    Accion = RelacionarInterpretesAAlbumEntrada.Acciones.Agregar,
                    AlbumId = padreId,
                    Interpretes = new List<int> {interpreteElegidoId}
                };
            var salida = _gestorDominio.RelacionarInterpretesAAlbum(entrada);
            if (salida.Resultado != SalidaBase.Resultados.Exito) {
                TempData["mensaje"] = "error: "  + salida.Mensaje;
            }
            
            //var album = _gestorPersistencia.TraerAlbum(padreId);
            //var listaInterpretes = TraerListaInterpretes(album);
            return RedirectToAction("Editar", "Albumes", padreId);
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
        public ActionResult DesasociarInterprete(string s) {
            return Json(null);
        }
    }
}