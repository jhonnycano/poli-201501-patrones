using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Politecnico.Patrones.ProyectoFinal.Contratos;
using Politecnico.Patrones.ProyectoFinal.Contratos.Entidades;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;
using Politecnico.Patrones.ProyectoFinal.Contratos.VO;
using Politecnico.Patrones.ProyectoFinal.Web.Code;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class CancionesController : FlixNetController {
        private readonly IGestorDominio _gestorDominio;
        public CancionesController(IGestorDominio gestorDominio) {
            _gestorDominio = gestorDominio;
        }
        // GET: /Canciones/
        public ActionResult Index(int pagina = 0, string nombre = "") {
            var lista = _gestorDominio.TraerCanciones(pagina, nombre, FiltroAlbum.Todas, null);
            EnviarMensajeAVista();
            ViewBag.Paginador = Utiles.CrearPaginador("Canciones", "Index", pagina, lista);
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
            var cancion = _gestorDominio.TraerCancion(id);
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
                var entrada = new EditarCancionEntrada
                    {
                        CancionId = cancion.Id,
                        Nombre = cancion.Nombre,
                        AlbumId = cancion.AlbumId
                    };
                var salida = _gestorDominio.EditarCancion(entrada);
                if (salida != SalidaBase.Resultados.Exito) {
                    PasarMensaje(salida.Mensaje, "msj-error");
                }
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
        //
        // GET: /Canciones/Editar/5
        public ActionResult Editar(int id = 0) {
            var cancion = _gestorDominio.TraerCancion(id);
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
                    PasarMensaje(salida.Mensaje, "msj-error");
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        //
        // GET: /Canciones/Votar
        public ActionResult Votar(string v, bool d = false) {
            IList<int> canciones;
            try {
                var json = JArray.Parse(v);
                canciones = new List<int>(json.Values<int>());
            } catch (Exception) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Votos incorrectos");
            }
            var accion = d
                ? RegistrarVotoCancionesEntrada.Acciones.Desasociar
                : RegistrarVotoCancionesEntrada.Acciones.Asociar;

            var entrada = new RegistrarVotoCancionesEntrada
                {
                    Accion = accion,
                    UsuarioId = User.APrincipalUsuario().IdentityUsuario.Id,
                    Canciones = canciones
                };
            var salida = _gestorDominio.RegistrarVotoCanciones(entrada);
            if (salida != SalidaBase.Resultados.Exito) {
                PasarMensaje(salida.Mensaje, "msj-error");
                return RedirectToAction("Index");
            }

            PasarMensaje("Muchas gracias por votar", "msj-exito");
            return RedirectToAction("Index");
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
}