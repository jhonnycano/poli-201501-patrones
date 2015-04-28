using System.Web.Mvc;
using System.Web.Routing;

namespace Politecnico.Patrones.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{data}",
                defaults: new { controller = "Start", action = "Index", data = UrlParameter.Optional }
            );
        }
    }
}