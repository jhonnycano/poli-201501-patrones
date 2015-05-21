using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public static IList<SelectListItem> GenerarItems<T>(IList<T> origen, Func<T, string> funcValor, Func<T, string> funcTexto) {
            var query = (from o in origen
                let valor = funcValor(o)
                let texto = funcTexto(o)
                select new SelectListItem {Value = valor, Text = texto});

            return query.ToList();


        }
    }
}