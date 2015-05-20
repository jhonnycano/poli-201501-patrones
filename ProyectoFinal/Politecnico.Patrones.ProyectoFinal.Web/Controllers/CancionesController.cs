using System.Web.Mvc;

namespace Politecnico.Patrones.ProyectoFinal.Web.Controllers {
    [Authorize]
    public class CancionesController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}