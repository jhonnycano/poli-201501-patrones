using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Politecnico.Patrones.ProyectoFinal.Web {
    public static class Utiles {
        public static IList<SelectListItem> GenerarItems<T>(IList<T> origen, Func<T, string> funcValor,
            Func<T, string> funcTexto) {
            var query = (from o in origen
                let valor = funcValor(o)
                let texto = funcTexto(o)
                select new SelectListItem {Value = valor, Text = texto});

            return query.ToList();
        }
    }
}