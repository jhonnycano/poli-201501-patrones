using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Politecnico.Patrones.ProyectoFinal.Contratos.MV;

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
        public static string ResumenInterpretes(IList<MVInterprete> interpretes) {
            if (interpretes == null || interpretes.Count == 0) return null;
            return interpretes.Aggregate("", (s, interprete) => s + (", " + interprete.Nombre),
                s => s.Length > 2 ? s.Remove(0, 2) : s);
        }
        /*
        public static string RenderViewToString(HttpContextBase mvcContext, string area, string controllerName,
            string viewName, object model) {
         // http://stackoverflow.com/questions/779430/asp-net-mvc-how-to-get-view-to-generate-pdf/26637290#26637290
            var context = HttpContext.Current;
            var contextBase = mvcContext;
            var routeData = new RouteData();
            if (area == null) area = "";

            routeData.DataTokens.Add("area", area);

            routeData.Values.Add("controller", controllerName);

            var controllerContext = new ControllerContext(contextBase,
                routeData,
                new EmptyController());

            var razorViewEngine = new RazorViewEngine();
            var razorViewResult = razorViewEngine.FindView(controllerContext,
                viewName,
                "",
                false);

            var writer = new StringWriter();
            var viewContext = new ViewContext(controllerContext,
                razorViewResult.View,
                new ViewDataDictionary(model),
                new TempDataDictionary(),
                writer);
            razorViewResult.View.Render(viewContext, writer);

            string hostAddress = context.Request.Url.Scheme + "://" + context.Request.Url.Authority;

            return writer.ToString()
                .Replace("src=\"/", "src=\"" + hostAddress + "/")
                .Replace("<link href=\"/", "<link href=\"" + hostAddress + "/");
        }
         * */
    }
}