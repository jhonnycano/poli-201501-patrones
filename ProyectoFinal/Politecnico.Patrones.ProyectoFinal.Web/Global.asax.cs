using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Politecnico.Patrones.ProyectoFinal.Lib;
using Politecnico.Patrones.ProyectoFinal.Lib.Entidades;
using Politecnico.Patrones.ProyectoFinal.Web.App_Start;

namespace Politecnico.Patrones.ProyectoFinal.Web {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
		protected void Application_PostAuthenticateRequest(object sender, EventArgs e) {
			if (!Request.IsAuthenticated) return;

		    var usuario = TraerUsuario();
		    var identity = new IdentityUsuario(Context.User.Identity, usuario);
			var principal = new PrincipalUsuario(identity);
			Context.User = principal;
		}
        private Usuario TraerUsuario() {
            var usuarioContexto = Request.RequestContext.HttpContext.Items["usuario"] as Usuario;
            if (usuarioContexto != null) return usuarioContexto;

            var gestorAutenticacion = (IGestorAutenticacion)DependencyResolver.Current.GetService(typeof(IGestorAutenticacion));
            var usuario = gestorAutenticacion.TraerUsuario(User.Identity.Name);

            return usuario;
        }
    }
}