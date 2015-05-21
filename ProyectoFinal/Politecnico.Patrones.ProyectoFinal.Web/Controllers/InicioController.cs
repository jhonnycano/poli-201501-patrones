using System.Web.Mvc;
using System.Web.Security;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    public class InicioController : Controller {
        //
        // GET: /Inicio/

        public ActionResult Index() {
            return View();
        }

        public ActionResult Registrar() {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(string nombre, string correo, string clave, string claveRepetida) {
            var autenticador = Utiles.TraerGestorAutenticacion();
            var entrada = new RegistrarUsuarioEntrada
                {
                    Nombre = nombre,
                    Correo = correo,
                    Clave = clave,
                    ClaveRepetida = claveRepetida
                };
            var result = autenticador.RegistrarUsuario(entrada);
            if (result.Resultado != SalidaBase.Resultados.Exito) {
                ModelState.AddModelError("", result.Mensaje);
                return View();
            }

            return RedirectToAction("IniciarSesion", new {correo});
        }
        public ActionResult IniciarSesion() {
            return View();
        }
        [HttpPost]
        public ActionResult IniciarSesion(string correo, string clave, string returnUrl) {
            var autenticador = Utiles.TraerGestorAutenticacion();
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
            Request.RequestContext.HttpContext.Items.Add("usuario", result.Usuario);
            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\")) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Inicio");
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