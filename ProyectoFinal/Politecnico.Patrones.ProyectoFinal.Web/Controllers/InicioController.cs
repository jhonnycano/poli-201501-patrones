using System.Web.Mvc;
using System.Web.Security;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;
using Politecnico.Patrones.ProyectoFinal.Web.Models;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    public class InicioController : Controller {
        //
        // GET: /Inicio/

        public ActionResult Index() {
            var modelo = new MdIndex();


            modelo.Autenticado = User.Identity.IsAuthenticated;
            modelo.Usuario = User.Identity.Name;

            return View(modelo);
        }
        public ActionResult Registrar() {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(string correo, string clave, string claveRepetida)
        {
            var autenticador = TraerGestorAutenticacion();
            var entrada = new RegistrarUsuarioEntrada {Correo = correo, Clave = clave, ClaveRepetida = claveRepetida};
            var result = autenticador.RegistrarUsuario(entrada);
            if (result.Resultado != SalidaBase.Resultados.Exito) {
                ModelState.AddModelError("", result.Mensaje);
                return View();
            }

            return RedirectToAction("IniciarSesion", new {correo});
        }
        public ActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IniciarSesion(string correo, string clave, string returnUrl) {
            var autenticador = TraerGestorAutenticacion();
            var entrada = new IdentificarUsuarioEntrada
                {
                    Correo = correo,
                    Clave = clave
                };
            var result = autenticador.IdentificarUsuario(entrada);
            if (result.Resultado != SalidaBase.Resultados.Exito) {
                ModelState.AddModelError("", result.Mensaje);
                return View();
            }

            FormsAuthentication.SetAuthCookie(correo, false);
            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\")) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Inicio");
        }
        private IGestorAutenticacion TraerGestorAutenticacion() {
            var gd = HttpContext.Application["dependencias"] as GestorDependencias;
            if (gd == null) {
                gd = new GestorDependencias();
                HttpContext.Application["dependencias"] = gd;
            }
            var autenticador = gd.TraerGestorAutenticacion();
            return autenticador;
        }
        public ActionResult CerrarSesion() {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Inicio");
        }
        [Authorize]
        public ActionResult Privado() {
            ViewBag.Mensaje = "Acción privada";

            return View();
        }
    }
}