using System.Web.Mvc;
using System.Web.Security;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.VO;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    public class InicioController : Controller {
        private readonly IGestorAutenticacion _gestorAutenticacion;
        public InicioController(IGestorAutenticacion gestorAutenticacion) {
            _gestorAutenticacion = gestorAutenticacion;
        }
        public ActionResult Index() {
            return View();
        }
        public ActionResult Registrar() {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(string nombre, string correo, string clave, string claveRepetida) {
            var entrada = new RegistrarUsuarioEntrada
                {
                    Nombre = nombre,
                    Correo = correo,
                    Clave = clave,
                    ClaveRepetida = claveRepetida
                };
            var result = _gestorAutenticacion.RegistrarUsuario(entrada);
            if (result != SalidaBase.Resultados.Exito) {
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
            var entrada = new IdentificarUsuarioEntrada
                {
                    Correo = correo,
                    Clave = clave
                };
            var result = _gestorAutenticacion.IdentificarUsuario(entrada);
            if (result != SalidaBase.Resultados.Exito) {
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