using System.Web.Mvc;

namespace Politecnico.Patrones.ProyectoFinal.Web.Code {
    public class FlixNetController : Controller {
        protected void PasarMensaje(string mensaje, string clase) {
            TempData["mensaje"] = mensaje;
            TempData["claseMensaje"] = clase;
        }
        protected void EnviarMensajeAVista() {
            if (TempData.ContainsKey("mensaje")) {
                ViewData["mensaje"] = TempData["mensaje"];
                ViewData["claseMensaje"] = TempData.ContainsKey("claseMensaje") ? TempData["claseMensaje"] : "msj-error";
            }
        }
    }
}