using System;
using System.Web.Mvc;
using Politecnico.Patrones.Fabrica.DistribucionCurules;
using Politecnico.Patrones.Web.Models;

namespace Politecnico.Patrones.Web.Controllers
{
    public class StartController : Controller
    {
        //
        // GET: /Start/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ElegirAlgoritmo(string data)
        {
            FabricaDistribucion.AlgoritmoDistribucion algo;
            if (!Enum.TryParse(data, true, out algo))
            {
                TempData["mensaje"] = "Algoritmo no encontrado";
                return RedirectToAction("Index");

            }
            return RedirectToAction("PedirDatos",
                new InsumoDistribucion {Algoritmo = data, CurulesDisponibles = 10, ResultadosVotacion = ""});
        }
        public ActionResult PedirDatos(InsumoDistribucion insumo)
        {
            return View(insumo);
        }
        public ActionResult MostrarDatos(InsumoDistribucion insumo)
        {
            if (string.IsNullOrEmpty(insumo.ResultadosVotacion))
            {
                return RedirectToAction("PedirDatos", insumo);
            }

            var infoPartidos = UtilInfo.TraerInfoPartidos(insumo.ResultadosVotacion);
            if (infoPartidos.Count == 0)
            {
                return RedirectToAction("PedirDatos", insumo);
            }
            

            // procesar datos
            var algo = new DistribucionHondt();
            algo.Calcular(infoPartidos, insumo.CurulesDisponibles);
            insumo.ResultadosCalculados = infoPartidos;
            return View(insumo);
        }
    }
}