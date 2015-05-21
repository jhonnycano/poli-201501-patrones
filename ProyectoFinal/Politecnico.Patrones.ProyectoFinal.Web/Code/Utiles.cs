using System.Web;
using Politecnico.Patrones.ProyectoFinal.Lib;

namespace Politecnico.Patrones.ProyectoFinal.Web {
    public static class Utiles {
        public static GestorDependencias TraerGestorDependencias() {
            var gd = HttpContext.Current.Application["dependencias"] as GestorDependencias;
            if (gd == null) {
                gd = new GestorDependencias();
                HttpContext.Current.Application["dependencias"] = gd;
            }
            return gd;
        }
        public static IGestorAutenticacion TraerGestorAutenticacion() {
            var gd = TraerGestorDependencias();
            var autenticador = gd.TraerGestorAutenticacion();
            return autenticador;
        }
        public static IGestorPersistencia TraerGestorPersistencia() {
            var gd = TraerGestorDependencias();
            var gestorPersistencia = gd.TraerGestorPersistencia();
            return gestorPersistencia;
        }
    }
}